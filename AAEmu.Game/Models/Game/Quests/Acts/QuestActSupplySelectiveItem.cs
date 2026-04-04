using AAEmu.Game.Models.Game.Items;
using AAEmu.Game.Models.Game.Quests.Templates;

namespace AAEmu.Game.Models.Game.Quests.Acts;

public class QuestActSupplySelectiveItem(QuestComponentTemplate parentComponent) : QuestActTemplate(parentComponent)
{
    public uint ItemId { get; set; }
    public byte GradeId { get; set; }

    /// <summary>
    /// Does a selective item reward
    /// </summary>
    /// <param name="quest"></param>
    /// <param name="questAct"></param>
    /// <param name="currentObjectiveCount"></param>
    /// <returns>Always returns true to allow progress even if this isn't the selected reward</returns>
    public override bool RunAct(Quest quest, QuestAct questAct, int currentObjectiveCount)
    {
        Logger.Debug($"{QuestActTemplateName}({DetailId}).RunAct: 任务：{quest.TemplateId}，所有者 {quest.Owner.Name} ({quest.Owner.Id})，物品 ID {ItemId}，数量 {Count}，品质 ID {GradeId}，已选择 {quest.SelectedRewardIndex}，当前索引 {ThisSelectiveIndex}");

        // Only add reward if it was this selection
        if (quest.SelectedRewardIndex == ThisSelectiveIndex)
            quest.QuestRewardItemsPool.Add(new ItemCreationDefinition(ItemId, Count, GradeId));

        return true;
    }
}
