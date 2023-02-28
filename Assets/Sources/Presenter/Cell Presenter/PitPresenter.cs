using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PitPresenter : UpdatableCellPresenter
{
    private Pit pit;

    private void Awake()
    {
        pit = new Pit(transform.position);
        Init(pit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pit.Filled)
        {
            bool isCell = collision.transform.TryGetComponent<CellPresenter>(out var presenter) ;

            if (isCell && presenter.Model is IChangableBehavior changable && presenter.Behavior is IMovable movable)
                pit.TrySetTrackedBlock(changable, movable);
        }
    }
}
