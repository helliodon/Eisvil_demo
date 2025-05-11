using System;
using UnityEngine;

[Serializable]
public class Quest : BaseQuest, IQuest
{
    public Quest(QuestConfig conf)
    {
        questName = conf.Quest.questName;
        description = conf.Quest.description;
        questType = conf.Quest.questType;
        targetValue = conf.Quest.targetValue;
        specificType = conf.Quest.specificType;
    }
    public bool IsCompleted
    {
        get
        {
            return Passed == targetValue;
        }
    }

    public int Progress => throw new NotImplementedException();

    public int Passed { get; set; }

    public void UpdateProgress(int value)
    {
        Passed+= value;
    }
}
