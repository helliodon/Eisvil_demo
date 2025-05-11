using System;
using UnityEngine;

[Serializable]
public class Level: BaseLevel, ILevel
{
    public Vector3 AnchorSpawnPoint;
    public bool LevelComplete
    {
        get 
        {
            bool levelComplete = true;
            if (Quests != null && Quests.Length > 0)
            {
                foreach(var item in Quests)
                {
                    if (!item.IsCompleted)
                        levelComplete = false;
                }
            }
            return levelComplete;
        }
    }

}
