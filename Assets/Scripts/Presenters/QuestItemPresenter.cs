using UnityEngine;

public class QuestItemPresenter
{
    private QuestView view;
    private Quest quest;
    public QuestItemPresenter(QuestView view, Quest quest)
    {
        this.view = view;
        this.quest = quest;
        view.SetQuestItemView(quest.questName, quest.description, quest.targetValue, quest.Passed);
    }

    public void UpdateQuest(Unit.UnitType unitType)
    {
        if(quest != null && !quest.IsCompleted)
        {
            if((quest.specificType == Unit.UnitType.None && unitType != Unit.UnitType.Timer) || quest.specificType == unitType)
            {
                quest.UpdateProgress(1);
                view.SetQuestItemView(quest.questName, quest.description, quest.targetValue, quest.Passed);
            }
        }
    }
}
