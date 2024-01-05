using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PitPresenter : UpdatableUnitPresenter
{
    private Pit _model;

    private void Awake()
    {
        _model = new Pit(transform.position);
        Init(_model);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_model.Filled)
        {
            bool isCell = collision.transform.TryGetComponent(out UnitPresenter presenter);
            if (isCell && presenter.Model is IChangableBehavior changable && presenter.Behavior is IMovable movable)
                _model.TrySetTrackedBlock(changable, movable);
        }
    }
}
