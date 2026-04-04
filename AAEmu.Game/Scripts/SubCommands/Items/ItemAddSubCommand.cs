using System.Drawing;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Managers.World;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Items;
using AAEmu.Game.Models.Game.Items.Actions;
using AAEmu.Game.Utils.Converters;
using AAEmu.Game.Utils.Scripts;
using AAEmu.Game.Utils.Scripts.SubCommands;

namespace AAEmu.Game.Scripts.SubCommands.Items;

public class ItemAddSubCommand : SubCommandBase
{
    public ItemAddSubCommand()
    {
        Title = "[Item]";
        Description =
            "向自己、玩家名称或选中的目标添加特定 [grade] 的特定物品模板。";
        CallPrefix = $"{CommandManager.CommandPrefix}item add";
        AddParameter(new StringSubCommandParameter("target", "player name||target||self", true));
        AddParameter(new NumericSubCommandParameter<uint>("templateId", "template id", true));
        AddParameter(new NumericSubCommandParameter<int>("amount", "amount=1", false, 1, 1000) { DefaultValue = 1 });
        AddParameter(
            new NumericSubCommandParameter<byte>("grade", "item grade=0", false, (byte)ItemGrade.Crude,
                (byte)ItemGrade.Mythic)
            { DefaultValue = (byte)ItemGrade.Crude });
    }

    public override void Execute(ICharacter character, string triggerArgument,
        IDictionary<string, ParameterValue> parameters, IMessageOutput messageOutput)
    {
        Character addTarget;
        var selfCharacter = (Character)character;

        string firstArgument = parameters["target"];
        if (firstArgument == "target")
        {
            if (selfCharacter.CurrentTarget is null || selfCharacter.CurrentTarget is not Character)
            {
                SendColorMessage(messageOutput, Color.Red, "请选择一个有效的角色玩家");
                return;
            }

            addTarget = selfCharacter.CurrentTarget as Character;
        }
        else if (firstArgument == "self")
        {
            addTarget = selfCharacter;
        }
        else
        {
            var player = WorldManager.Instance.GetCharacter(firstArgument);
            if (player is null)
            {
                SendColorMessage(messageOutput, Color.Red, $"未找到玩家：{firstArgument}。");
                return;
            }

            addTarget = player;
        }

        uint templateId = parameters["templateId"];
        int itemAmount = parameters["amount"];
        byte itemGrade = parameters["grade"];

        var itemTemplate = ItemManager.Instance.GetTemplate(templateId);
        if (itemTemplate is null)
        {
            SendColorMessage(messageOutput, Color.Red, $"物品模板 ID {templateId} 不存在！");
            return;
        }

        if (ItemManager.Instance
            .IsAutoEquipTradePack(itemTemplate
                .Id)) // .Category_Id == 133) || (itemTemplate.Category_Id == 122)) // Speciality Packs or Tradepacks
        {
            var currentBackpack = addTarget.Equipment.GetItemBySlot((int)EquipmentItemSlot.Backpack);
            if (currentBackpack != null)
            {
                SendColorMessage(messageOutput, Color.Red, "背包插槽没有空间放置贸易包！");
                return;
            }

            if (!addTarget.Equipment.AcquireDefaultItem(ItemTaskType.Gm, templateId, itemAmount, itemGrade))
            {
                SendColorMessage(messageOutput, Color.Red, "无法创建贸易包！");
                return;
            }
        }
        else if (!addTarget.Inventory.Bag.AcquireDefaultItem(ItemTaskType.Gm, templateId, itemAmount, itemGrade))
        {
            SendColorMessage(messageOutput, Color.Red, "无法创建物品！");
            return;
        }

        if (selfCharacter.Id != addTarget.Id)
        {
            SendMessage(messageOutput,
                $"Added item {ChatConverter.ConvertAsChatMessageReference(templateId, itemGrade)} to {addTarget.Name}'s inventory");
            SendMessage(addTarget, messageOutput,
                $"[GM] {selfCharacter.Name} added {ChatConverter.ConvertAsChatMessageReference(templateId, itemGrade)} to your inventory");
        }
    }
}
