using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Quests.Templates;
using AAEmu.Game.Models.StaticValues;

namespace AAEmu.Game.Models.Game.Quests.Acts;

public class QuestActSupplyLivingPoint(QuestComponentTemplate parentComponent) : QuestActTemplate(parentComponent)
{
    public int Point { get; set; }

    /// <summary>
    /// Gain living points (vocation)
    /// </summary>
    /// <param name="quest"></param>
    /// <param name="questAct"></param>
    /// <param name="currentObjectiveCount"></param>
    /// <returns></returns>
    public override bool RunAct(Quest quest, QuestAct questAct, int currentObjectiveCount)
    {
        Logger.Debug($"{QuestActTemplateName}({DetailId}).RunAct: 任务：{quest.TemplateId}，所有者 {quest.Owner.Name} ({quest.Owner.Id})，点数 {Point}");
        var player = quest.Owner as Character;
        player?.ChangeGamePoints(GamePointKind.Vocation, Point);
        return true;
    }
}
