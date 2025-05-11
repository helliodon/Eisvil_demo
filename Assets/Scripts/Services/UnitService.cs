using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class UnitService : IUnitService
{
    private GameObject unitPrefab;
    private DiContainer container;
    public UnitService(DiContainer container, Level level)
    {
        this.container = container;
        InitUnits(level);
    }
    public IUnit CreateUnit(Unit.UnitType unitType)
    {
        return null;
    }

    private async Task InitUnits(Level level)
    {
        var prefab = Addressables.LoadAssetAsync<GameObject>("Unit");
        await prefab.Task;
        unitPrefab = prefab.Result;
        Vector3 anchorSpawnPoint = level.AnchorSpawnPoint;

        //TODO: wrap to config, just for demo
        int rows = 5;
        int columns = 6;
        float spacing = 1f;


        List<Unit.UnitType> units = new List<Unit.UnitType>();
        foreach(var item in level.Participants)
        {
            units.AddRange(Enumerable.Repeat(item.UnitType, item.Count));
        }

        System.Random rng = new System.Random();
        units = units.OrderBy(x => rng.Next()).ToList();

        int unitIndex = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (unitIndex >= units.Count)
                    break; 

                Vector3 position = new Vector3(
                    anchorSpawnPoint.x + col * spacing,
                    anchorSpawnPoint.y,
                    anchorSpawnPoint.z + row * spacing
                );

                var unitView = container.InstantiatePrefab(unitPrefab, position, Quaternion.identity, null);
                var unitViewComponent = unitView.GetComponent<UnitView>();
                container.Bind<UnitView>().FromInstance(unitViewComponent).AsTransient().NonLazy();
                var presenter = new UnitPresenter(unitViewComponent);
                container.BindInstance(presenter).AsTransient();
                unitViewComponent.InitUnit(units[unitIndex]);
                unitIndex++;
            }
        }
    }
}
