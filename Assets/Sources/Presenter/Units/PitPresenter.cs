using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PitPresenter : UpdatableUnitPresenter
{
    private Pit _pit;

    private void Awake()
    {
        _pit = new Pit(transform.position);
        Init(_pit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_pit.Filled)
        {
            bool isUnit = collision.transform.TryGetComponent(out UnitPresenter presenter);
            if (isUnit && presenter.Model is IChangableBehavior changable && presenter.Behavior is IMovable movable)
                _pit.TrySetTrackedBlock(changable, movable);
        }
    }
}
