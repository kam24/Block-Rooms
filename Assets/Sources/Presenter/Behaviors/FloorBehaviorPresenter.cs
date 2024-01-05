using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FloorBehaviorPresenter : BehaviorPresenter
{
    private BoxCollider2D _boxCollider;
    private IFloor _floor;

    public override void InitBehavior(IUnitBehavior type)
    {
        _floor = (IFloor)type;
    }

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _floor.SetIncomingBlockForNextFloor += OnSetIncomingBlockForNextFloor;
        _boxCollider.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Floor");
    }

    private void OnDisable()
    {
        _floor.SetIncomingBlockForNextFloor -= OnSetIncomingBlockForNextFloor;
        _boxCollider.isTrigger = false;
    }

    private void OnSetIncomingBlockForNextFloor(Direction direction, IMovable movableBlock)
    {
        Vector2 nextFloorPosition = (Vector2)Model.Position + direction.Position;
        if (UnitFinder.TryGetUnit(nextFloorPosition, LayerMask.GetMask("Floor"), out UnitPresenter presenter) && presenter.Behavior is IFloor nextFloor)
            nextFloor.SetIncomingBlock(movableBlock, direction);
    }
}
