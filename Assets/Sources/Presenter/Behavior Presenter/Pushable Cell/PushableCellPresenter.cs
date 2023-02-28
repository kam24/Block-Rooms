using BlockRooms.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using static BlockRooms.Model.CellMovement;

public class PushableCellPresenter : BehaviorPresenter, IPushable
{
    public IMovable Movement { get; private set; }

    public override void InitBehavior(ICellBehavior type)
    {
        Movement = (IMovable)type;
    }

    public virtual bool TryPush(Direction direction)
    {
        Vector2 nextPostion = (Vector2)Model.Position + direction.Position;
        Stack<ICellBehavior> cellTypes = CellFinder.GetCellsStack(nextPostion);

        if (cellTypes.Count == 0)
            return false;

        CheckingResult result = Movement.CheckMoveAbility(cellTypes, direction);

        switch (result)
        {
            case CheckingResult.MovementAllowed:
                Movement.Push(direction);
                return true;
            case CheckingResult.MovementDenied:
                return false;
            case CheckingResult.CheckNextCell:
                if (cellTypes.Peek() is IMovable && CellFinder.TryGetTopCell(nextPostion, out IPushable pushable) && pushable.TryPush(direction))
                {
                    Movement.Push(direction);
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(result));
        }
    }

    private void OnEnable()
    {
        Movement.TryingStartPush += OnTryingStartPush;
        gameObject.layer = LayerMask.NameToLayer("Movable Block");
    }

    private void OnDisable()
    {
        Movement.TryingStartPush -= OnTryingStartPush;
    }

    private void OnTryingStartPush(Direction direction) => TryPush(direction);
}

