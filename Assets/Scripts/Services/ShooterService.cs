using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class ShooterService
{
    private DiContainer container;
    public ShooterService(DiContainer container)
    {
        this.container = container;
        InitShooter();
    }

    private async Task InitShooter()
    {
        var prefab = Addressables.LoadAssetAsync<GameObject>("Shooter");
        await prefab.Task;
        var shooterPrefab = container.InstantiatePrefab(prefab.Result);

        var shooter = container.InstantiatePrefab(shooterPrefab);
        var shooterComponent = shooter.GetComponent<Shooter>();
        container.Bind<Shooter>().FromInstance(shooterComponent).AsSingle().NonLazy();
    }
}
