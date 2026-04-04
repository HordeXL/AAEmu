using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Packets.G2C;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Chat;
using AAEmu.Game.Models.StaticValues;
using AAEmu.Game.Utils.Scripts;

namespace AAEmu.Game.Scripts.Commands;

public class TestChatChannel : ICommand
{
    public string[] CommandNames { get; set; } = ["testchatchannel", "test_chat_channel", "testchat"];

    public void OnLoad()
    {
        CommandManager.Instance.Register(CommandNames, this);
    }

    public string GetCommandLineHelp()
    {
        return "<list||clean||<<join||leave> <chatTypeId> <chatSubType> <chatFaction>>";
    }

    public string GetCommandHelpText()
    {
        return "用于手动向自己发送加入/离开频道数据包的测试命令\r" +
               "你也可以使用 list 显示所有当前聊天频道的列表，或使用 clean 移除任何没有用户的非系统频道。";
    }

    public void Execute(Character character, string[] args, IMessageOutput messageOutput)
    {
        if (args.Length == 1 && args[0].Equals("list", StringComparison.CurrentCultureIgnoreCase))
        {
            CommandManager.SendNormalText(this, messageOutput, $"列出所有频道");
            var channels = ChatManager.Instance.ListAllChannels();
            foreach (var c in channels)
            {
                CommandManager.SendNormalText(this, messageOutput,
                    $"T:{c.ChatType} ST:{c.SubType} F:{c.Faction} => {c.InternalId} - {c.InternalName} ({c.Members.Count})");
            }

            CommandManager.SendNormalText(this, messageOutput, $"列表结束");
            return;
        }

        if (args.Length == 1 && args[0].Equals("clean", StringComparison.CurrentCultureIgnoreCase))
        {
            var removed = ChatManager.Instance.CleanUpChannels();
            CommandManager.SendNormalText(this, messageOutput, $"已移除 {removed} 个空频道");
            return;
        }

        if (args.Length < 4)
        {
            CommandManager.SendDefaultHelpText(this, messageOutput);
            return;
        }

        if (!Enum.TryParse<ChatType>(args[1], true, out var chatType) ||
            !byte.TryParse(args[2], out var chatSubType) ||
            !Enum.TryParse<FactionsEnum>(args[1], true, out var chatFaction)
           )
        {
            CommandManager.SendErrorText(this, messageOutput, $"解析错误");
            return;
        }

        if (args[0].Equals("join", StringComparison.CurrentCultureIgnoreCase))
        {
            character.SendPacket(new SCJoinedChatChannelPacket(chatType, chatSubType, chatFaction));
        }

        if (args[0].Equals("leave", StringComparison.CurrentCultureIgnoreCase))
        {
            character.SendPacket(new SCLeavedChatChannelPacket(chatType, chatSubType, chatFaction));
        }
    }
}
