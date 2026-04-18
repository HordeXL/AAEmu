using System.Diagnostics;

using AAEmu.Commons.Utils;
using AAEmu.Commons.Utils.DB;
using AAEmu.Commons.Utils.Updater;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Managers.Id;
using AAEmu.Game.Core.Managers.Stream;
using AAEmu.Game.Core.Managers.UnitManagers;
using AAEmu.Game.Core.Managers.World;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Core.Network.Login;
using AAEmu.Game.Core.Network.Stream;
using AAEmu.Game.GameData.Framework;
using AAEmu.Game.IO;
using AAEmu.Game.Models;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Utils.Scripts;

using Microsoft.Extensions.Hosting;

using NLog;

namespace AAEmu.Game;

public sealed class GameService : IHostedService, IDisposable
{
    private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
    private static TimeProvider s_timeProvider = TimeProvider.System;
    public static DateTime StartTime { get; private set; } = DateTime.UtcNow;
    public static TimeSpan TimeSinceStart => s_timeProvider.GetUtcNow().UtcDateTime.Subtract(StartTime);

    private readonly ManagerOrchestrator _orchestrator;

    public GameService(IServiceProvider serviceProvider, ManagerOrchestrator orchestrator, TimeProvider timeProvider)
    {
        SingletonContainer.ServiceProvider = serviceProvider;
        _orchestrator = orchestrator;
        s_timeProvider = timeProvider;
        StartTime = timeProvider.GetUtcNow().UtcDateTime;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Logger.Info("启动守护进程：AAEmu.Game");

        // Check for updates
        using (var connection = MySQL.CreateConnection())
        {
            if (!MySqlDatabaseUpdater.Run(connection, "aaemu_game", AppConfiguration.Instance.Connections.MySQLProvider.Database,
                    AppConfiguration.Instance.Connections.AutoApplyUpdates))
            {
                Logger.Fatal("数据库更新失败！");
                Logger.Fatal("按 Ctrl+C 退出");
                return;
            }
        }

        ClientFileManager.Initialize();
        if (ClientFileManager.Sources.Count == 0)
        {
            Logger.Fatal($"客户端文件加载失败！({string.Join(", ", AppConfiguration.Instance.ClientData.Sources)})");
            Logger.Fatal("按 Ctrl+C 退出");
            return;
        }

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // --- ID managers ---
        // All ID managers implement ILoadable and are handled by the orchestrator in Stage 2.
        // SkillTlIdManager.Instance.Initialize(); // static class, not migrated

        // --- Stage 2: Orchestrated parallel Load() ---
        // Managers implementing ILoadable are sorted by constructor dep graph and run in parallel batches.
        await _orchestrator.RunLoadAsync();

        // --- Stage 3: Post-load special steps ---
        GameDataManager.Instance.PostLoadGameData();
        CashShopManager.Instance.EnabledShop();

        // --- Scripts ---
        if (AppConfiguration.Instance.Scripts.LoadStrategy == ScriptsConfig.LoadStrategyType.Compilation)
        {
            ScriptCompiler.Compile();
        }
        else
        {
            // (Preferred for debugging)
            // Use reflection to load scripts
            ScriptReflector.Reflect();
        }

        TimeManager.Instance.Start();
        TaskManager.Instance.Start();

        // --- Stage 4: Orchestrated parallel Initialize() ---
        await _orchestrator.RunInitializeAsync();

        // --- Stage 5: World creation + network ---
        // Start main_world and other static instances
        WorldManager.Instance.CreateStaticInstances();
        WorldManager.Instance.Initialize();

        CharacterManager.Instance.CheckForDeletedCharacters();
        CharacterManager.Instance.StartOnlineTracking();

        GameNetwork.Instance.Start();
        StreamNetwork.Instance.Start();
        LoginNetwork.Instance.Start();

        stopWatch.Stop();
        Logger.Info($"服务器启动完成！耗时 {stopWatch.Elapsed}");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Logger.Info("停止守护进程...");

        await SaveManager.Instance.StopAsync();

        // SpawnManager.Instance.Stop(); Moved to World Instance
        TaskManager.Instance.Stop();
        GameNetwork.Instance.Stop();
        StreamNetwork.Instance.Stop();
        LoginNetwork.Instance.Stop();

        /*
        HousingManager.Instance.Save();
        MailManager.Instance.Save();
        ItemManager.Instance.Save();
        */
        AIManager.Instance.Stop();
        WorldManager.Instance.Stop();

        TickManager.Instance.Stop();
        TimeManager.Instance.Stop();

        ClientFileManager.ClearSources();
    }

    public void Dispose()
    {
        Logger.Info("正在处置...");

        LogManager.Flush();
    }
}
