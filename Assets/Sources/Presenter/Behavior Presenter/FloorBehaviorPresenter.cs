using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FloorBehaviorPresenter : BehaviorPresenter
{
    private BoxCollider2D boxCollider;
    private IFloor floor;

    public override void InitBehavior(ICellBehavior type)
    {
        floor = (IFloor)type;
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        floor.SetIncomingBlockForNextFloor += OnSetIncomingBlockForNextFloor;
        boxCollider.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Floor");
    }

    private void OnDisable()
    {
        floor.SetIncomingBlockForNextFloor -= OnSetIncomingBlockForNextFloor;
        boxCollider.isTrigger = false;
    }

    private void OnSetIncomingBlockForNextFloor(Direction direction, IMovable movableBlock)
    {
        Vector2 nextFloorPosition = (Vector2)Model.Position + direction.Position;
        if (CellFinder.TryGetCell(nextFloorPosition, LayerMask.GetMask("Floor"), out CellPresenter presenter) && presenter.Behavior is IFloor nextFloor)
            nextFloor.SetIncomingBlock(movableBlock, direction);
    }
}
