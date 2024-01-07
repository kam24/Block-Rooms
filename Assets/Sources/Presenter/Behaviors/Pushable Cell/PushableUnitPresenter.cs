using BlockRooms.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using static BlockRooms.Model.UnitMovement;

public class PushableUnitPresenter : BehaviorPresenter, IPushable
{
    public IMovable Movement { get; private set; }

    public override void InitBehavior(IUnitBehavior type)
    {
        Movement = (IMovable)type;
    }

    public virtual bool TryPush(Direction direction)
    {
        Vector2 nextPostion = (Vector2)Model.Position + direction.Position;
        Stack<IUnitBehavior> nextCellUnits = UnitFinder.GetUnitsStack(nextPostion);

        if (nextCellUnits.Count == 0)
            return false;

        CheckingResult result = Movement.CheckMoveAbility(nextCellUnits, direction);

        switch (result)
        {
            case CheckingResult.MovementAllowed:
                Movement.Push(direction);
                return true;
            case CheckingResult.MovementDenied:
                return false;
            case CheckingResult.CheckNextCell:
                bool unitCanBePushed = nextCellUnits.Peek() is IMovable 
                                        && UnitFinder.TryGetTopUnit(nextPostion, out IPushable pushable) 
                                        && pushable.TryPush(direction);
                if (unitCanBePushed)
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

