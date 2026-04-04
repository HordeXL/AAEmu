using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Managers.UnitManagers;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Utils.Scripts;

namespace AAEmu.Game.Scripts.Commands;

public class Help : ICommand
{
    public string[] CommandNames { get; set; } = ["help", "?"];

    public void OnLoad()
    {
        CommandManager.Instance.Register(CommandNames, this);
    }

    public string GetCommandLineHelp()
    {
        return "[topic]";
    }

    public string GetCommandHelpText()
    {
        return
            "显示关于命令 <topic> 的帮助。如果未提供 <topic>，将显示所有 GM 命令列表";
    }

    public void Execute(Character character, string[] args, IMessageOutput messageOutput)
    {
        if (args.Length > 0)
        {
            var thisCommand = args[0].ToLower();
            if (AccessLevelManager.Instance.GetLevel(CommandManager.Instance.GetCommandNameBase(thisCommand)) >
                character.AccessLevel)
            {
                // deliberately the same error as command not found 
                character.SendMessage("关于以下命令的帮助不可用：|cFFFFFFFF" + CommandManager.CommandPrefix + thisCommand +
                                      "|r");
            }
            else
            {
                var cmd = CommandManager.Instance.GetCommandInterfaceByName(thisCommand);
                if (cmd == null)
                {
                    // deliberately the same error as insufficient rights 
                    character.SendMessage("关于以下命令的帮助不可用：|cFFFFFFFF" + CommandManager.CommandPrefix + thisCommand +
                                          "|r");
                    return;
                }

                var helpLineText = cmd.GetCommandLineHelp();
                var helpText = cmd.GetCommandHelpText();
                character.SendMessage("关于以下命令的帮助：|cFFFFFFFF" + CommandManager.CommandPrefix + thisCommand + " " +
                                      helpLineText + "|r\n|cFF999999" + helpText + "|r");
            }

            return;
        }

        character.SendMessage("|cFF80FFFF可用 GM 命令列表|r\n-------------------------\n");
        var list = CommandManager.Instance.GetCommandKeys();
        list.Sort();
        var characterAccessLevel = CharacterManager.Instance.GetEffectiveAccessLevel(character);
        foreach (var command in list)
        {
            if (command == "help")
            {
                continue;
            }

            if (AccessLevelManager.Instance.GetLevel(command) > characterAccessLevel)
            {
                continue;
            }

            var cmd = CommandManager.Instance.GetCommandInterfaceByName(command);
            if (cmd == null)
            {
                continue; // should never happen
            }

            var helpLineText = cmd.GetCommandLineHelp();
            if (helpLineText != string.Empty)
            {
                character.SendMessage(CommandManager.CommandPrefix + command + " |cFF999999" + helpLineText + "|r");
            }
            else
            {
                character.SendMessage(CommandManager.CommandPrefix + command);
            }
        }
    }
}
