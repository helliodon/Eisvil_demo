using System;
using UnityEngine;

[Serializable]
public abstract class BaseLevel
{
    [Serializable]
    public class Participant
    {
        public Unit.UnitType UnitType;
        public int Count;
    }
    [HideInInspector]
    public Quest[] Quests;
    public int Level;
    public Participant[] Participants;
}
