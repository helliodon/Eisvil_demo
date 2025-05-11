using UnityEngine;

public class UnitView: MonoBehaviour
{
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private Material RedMaterial;
    [SerializeField] private Material BlueMaterial;
    [SerializeField] private Material DeadMaterial;
    [SerializeField] private BoxCollider Collider;
    public Unit.UnitType Type { get; private set; }
    public bool IsDead { get; private set; }

    public void InitUnit(Unit.UnitType type)
    {
        Type = type;
        Renderer.material = type == Unit.UnitType.Blue ? BlueMaterial :  RedMaterial;
    }

    public void DisableUnit()
    {
        IsDead = true;
        Renderer.material = DeadMaterial;
        Collider.enabled = false;
    }
}
