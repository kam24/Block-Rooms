using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(FloorBehaviorPresenter))]
public class FloorPresenter : UnitPresenter
{
    protected IFloor floor;

    private void Awake()
    {
        var model = new Floor(transform.position);
        var floorType = GetComponent<FloorBehaviorPresenter>();
        floor = (IFloor)model.Behavior;
        floorType.Init(model);
        Init(model);
    }

    private void Start()
    {
        if (UnitFinder.TryGetTopUnit(transform.position, out UnitPresenter presenter) && presenter.Behavior is IMovable movable)
            floor.SetOutgoingBlock(movable);
    }
}
