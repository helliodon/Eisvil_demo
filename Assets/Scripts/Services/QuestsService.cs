using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using Zenject;
using System.Collections.Generic;

public class QuestsService
{
    private DiContainer container;
    private Quest[] quests;
    private List<QuestItemPresenter> questPresenters = new List<QuestItemPresenter>();
    public QuestsService(Quest[] quests, DiContainer container)
    {
        this.quests = quests;
        this.container = container;
        InitQuests();
    }

    private async Task InitQuests()
    {
        var questListPrefab = Addressables.LoadAssetAsync<GameObject>("QuestList");
        await questListPrefab.Task;
        var questList = container.InstantiatePrefab(questListPrefab.Result);
        var questListView = questList.GetComponent<QuestListView>();

        var questItemPrefab = Addressables.LoadAssetAsync<GameObject>("QuestItem");
        await questItemPrefab.Task;

        foreach (var item in quests)
        {
            var questView = container.InstantiatePrefab(questItemPrefab.Result);
            var questViewComponent = questView.GetComponent<QuestView>();
            questView.transform.SetParent(questListView.QuestListTransform);
            container.Bind<QuestView>().FromInstance(questViewComponent).AsTransient().NonLazy();
            var presenter = new QuestItemPresenter(questViewComponent, item);
            container.BindInstance(presenter).AsTransient();
            questPresenters.Add(presenter);
        }
    }

    public void UpdateQuests(Unit.UnitType unitType)
    {
        foreach(var item in questPresenters)
        {
            item.UpdateQuest(unitType);
        }
    }
}
