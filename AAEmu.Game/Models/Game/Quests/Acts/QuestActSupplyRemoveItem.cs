using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Items;
using AAEmu.Game.Models.Game.Items.Actions;
using AAEmu.Game.Models.Game.Quests.Templates;

namespace AAEmu.Game.Models.Game.Quests.Acts;

public class QuestActSupplyRemoveItem(QuestComponentTemplate parentComponent) : QuestActTemplate(parentComponent)
{
    public uint ItemId { get; set; }

    /// <summary>
    /// Removes Count amount of Item
    /// </summary>
    /// <param name="quest"></param>
    /// <param name="questAct"></param>
    /// <param name="currentObjectiveCount"></param>
    /// <returns></returns>
    public override bool RunAct(Quest quest, QuestAct questAct, int currentObjectiveCount)
    {
        Logger.Debug($"{QuestActTemplateName}({DetailId}).RunAct: 任务：{quest.TemplateId}，所有者 {quest.Owner.Name} ({quest.Owner.Id})，物品 ID {ItemId}，数量 {Count}");

        if (quest.Owner is Character player)
        {
            _ = player.Inventory.GetAllItemsByTemplate([SlotType.Inventory], ItemId, -1, out _, out var unitsCount);

            var toRemove = Math.Min(unitsCount, Count);
            var removed = player.Inventory.ConsumeItem(null, ItemTaskType.QuestRemoveSupplies, ItemId, toRemove, null);
            if (removed < Count)
                Logger.Debug($"{QuestActTemplateName}({DetailId}).RunAct: 没有足够的物品来移除 任务：{quest.TemplateId}，所有者 {quest.Owner.Name} ({quest.Owner.Id})，物品 ID {ItemId}，数量 {removed}/{toRemove}(拥有 {unitsCount})");

            return true;
        }

        return false;
    }
}
