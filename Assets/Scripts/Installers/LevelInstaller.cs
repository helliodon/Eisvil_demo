using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [Header("Level Configuration")]
    public LevelConfig Level;
    public override void InstallBindings()
    {
        InitQuestsService();
        InitUnits();
        InitShooter();
        InitTimerService();
    }
    private void InitQuestsService()
    {
        if (Level != null)
        {
            if (Level.Quests != null)
            {
                List<Quest> quests = new List<Quest>();
                foreach (var item in Level.Quests)
                {
                    var quest = new Quest(item);
                    quests.Add(quest);
                }
                Level.Level.Quests = quests.ToArray();
                Container.Bind<QuestsService>().AsSingle().WithArguments(Level.Level.Quests).NonLazy();
            }
        }
    }

    private void InitUnits()
    {
        Container.Bind<UnitService>().AsSingle().WithArguments(Level.Level).NonLazy();
    }

    private void InitShooter()
    {
        Container.Bind<ShooterService>().AsSingle().NonLazy();
    }

    private void InitTimerService()
    {
        Container.BindInterfacesAndSelfTo<TimerService>().AsSingle().NonLazy();
    }
}