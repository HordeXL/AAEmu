using AAEmu.Commons.Utils.Updater;
using AAEmu.Login.Core.Controllers;
using AAEmu.Login.Core.Network.Internal;
using AAEmu.Login.Models;
using AAEmu.Login.Utils;
using Microsoft.Extensions.Options;

namespace AAEmu.Login;

public sealed class LoginService(
    IGameController gameController,
    IRequestController requestController,
    IInternalNetwork internalNetwork,
    IMySqlConnectionFactory connectionFactory,
    IOptions<DBConnectionsConfig> dbConnectionsConfig,
    ILogger<LoginService> logger) : IHostedService, IDisposable
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("启动守护进程：AAEmu.Login");

        // Check for updates
        await using (var connection = connectionFactory.CreateConnection())
        {
            if (!MySqlDatabaseUpdater.Run(connection, "aaemu_login",
                    dbConnectionsConfig.Value.MySQLProvider.Database,
                    dbConnectionsConfig.Value.AutoApplyUpdates))
            {
                logger.LogCritical("数据库更新失败！");
                logger.LogCritical("按 Ctrl+C 退出");
                return;
            }
        }

        requestController.Initialize();
        gameController.Load();
        internalNetwork.Start();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("停止守护进程。");
        internalNetwork.Stop();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        logger.LogInformation("正在处置...");
    }
}
