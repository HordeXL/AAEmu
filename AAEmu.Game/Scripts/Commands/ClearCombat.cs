using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Packets.G2C;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Utils.Scripts;

namespace AAEmu.Game.Scripts.Commands;

public class ClearCombat : ICommand
{
    public string[] CommandNames { get; set; } = ["clearcombat", "clear_combat", "cc"];

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
        return "强制发送清除战斗状态的数据包。实际上并不会清除服务器上的战斗标志！";
    }

    public void Execute(Character character, string[] args, IMessageOutput messageOutput)
    {
        character.SendPacket(new SCCombatClearedPacket(character.ObjId));
    }
}
