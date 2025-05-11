using UnityEngine;
using Zenject;

public class TimerService: ITickable
{
    private QuestsService questsService;
    private float timer;
    private const float UpdateInterval = 1f;
    [Inject]
    public void Construct(QuestsService questsService)
    {
        this.questsService = questsService;
    }
    public void Tick()
    {
        if ((timer -= Time.deltaTime) > 0f) return;

        timer = UpdateInterval;
        questsService.UpdateQuests(Unit.UnitType.Timer);
    }
}
