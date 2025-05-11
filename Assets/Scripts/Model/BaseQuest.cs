using UnityEngine;

public class BaseQuest
{
    public enum QuestType
    {
        TimeQuest,
        DestroyAnyQuest,
        DestroySpecificQuest
    }
    public string questName;
    public string description;
    public QuestType questType;
    public int targetValue;
    public Unit.UnitType specificType;
}
