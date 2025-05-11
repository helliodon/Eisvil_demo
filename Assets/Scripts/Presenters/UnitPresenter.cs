using System.Threading;
using UnityEngine;
using DG.Tweening;

public class UnitPresenter
{
    private float moveDuration = 3f;
    private float xRange = 0.1f;
    private float zRange = 0.1f;
    private Sequence movementSequence;

    private UnitView unitView;
    public UnitPresenter(UnitView unitView)
    {
        this.unitView = unitView;
        StartRandomMovement();
    }

    private void StartRandomMovement()
    {
        movementSequence = DOTween.Sequence();
        Vector3 strength = new Vector3(0.2f, 0f, 0.2f);

        Tweener conditionTween = DOTween.To(
        () => 0,
        x => { },
        1f,
        0.1f)
        .SetLoops(-1)
        .OnStepComplete(() => {
            if (unitView.IsDead)
            {
                movementSequence.Kill();
            }
        });

        movementSequence.Append(unitView.transform.DOShakePosition(500, strength, 2, fadeOut: false));
        movementSequence.Join(conditionTween);
    }
}
