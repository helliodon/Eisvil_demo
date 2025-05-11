using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Image Cross;
    [SerializeField] private LayerMask unitLayer;

    private QuestsService questsService;

    [Inject]
    public void Construct(QuestsService questsService)
    {
        this.questsService = questsService;

#if UNITY_EDITOR
        // Force focus the Game view in Editor
        UnityEditor.EditorWindow.FocusWindowIfItsOpen(typeof(UnityEditor.EditorWindow).Assembly
            .GetType("UnityEditor.GameView"));
#endif
    }
    private void Update()
    {
        UpdateCrosshairPosition();
        HandleShot();
    }

    private void HandleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool unitHit = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, unitLayer);
            if(unitHit) 
            {
                UnitView unit = hit.collider.GetComponent<UnitView>();
                unit.DisableUnit();
                questsService.UpdateQuests(unit.Type);
            }
        }
    }

    private void UpdateCrosshairPosition()
    {
        Cross.transform.position = Input.mousePosition;
    }
}
