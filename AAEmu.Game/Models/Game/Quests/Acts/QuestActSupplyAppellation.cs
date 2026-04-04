using AAEmu.Game.Models.Game.Quests.Templates;

namespace AAEmu.Game.Models.Game.Quests.Acts;

public class QuestActSupplyAppellation(QuestComponentTemplate parentComponent) : QuestActTemplate(parentComponent)
{
    public uint AppellationId { get; set; }

    /// <summary>
    /// Gives a new Title
    /// </summary>
    /// <param name="quest"></param>
    /// <param name="questAct"></param>
    /// <param name="currentObjectiveCount"></param>
    /// <returns></returns>
    public override bool RunAct(Quest quest, QuestAct questAct, int currentObjectiveCount)
    {
        Logger.Debug($"{QuestActTemplateName}({DetailId}).RunAct: 任务：{quest.TemplateId}，所有者 {quest.Owner.Name} ({quest.Owner.Id})，称号 ID {AppellationId}");
        quest.Owner.Appellations.Add(AppellationId);
        return true;
    }
}
