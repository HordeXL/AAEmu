using AAEmu.Game.Core.Managers;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Utils.Scripts;

namespace AAEmu.Game.Scripts.Commands;

public class ResetSkillCooldowns : ICommand
{
    public string[] CommandNames { get; set; } = ["resetcd", "resetskillcooldowns", "rcd"];

    public void OnLoad()
    {
        CommandManager.Instance.Register(CommandNames, this);
    }

    public string GetCommandLineHelp()
    {
        return "";
    }

    public string GetCommandHelpText()
    {
        return "重置技能冷却时间。";
    }

    public void Execute(Character character, string[] args, IMessageOutput messageOutput)
    {
        character.ResetAllSkillCooldowns(false);
    }
}
