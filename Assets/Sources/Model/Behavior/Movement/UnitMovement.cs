using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class UnitMovement : IMovable
    {
        public UnitLayer Layer => UnitLayer.MovableBlock;

        public event Action AchievedTarget;
        public event Action<Direction> TryingStartPush;
        public event Action<Direction> GoingToMove;

        public Unit Model { get; private set; }
        public Direction Direction { get; private set; }
        public bool InTargetPosition => VectorExtension.Equals(Position, TargetPosition);
        public bool IsMoving => !InTargetPosition;

        protected Vector3 Position => Model.Position;
        protected Vector3 TargetPosition { get; private set; }

        public enum CheckingResult
        {
            MovementAllowed,
            MovementDenied,
            CheckNextCell,
            TypeDoesNotMatch,
        }

        public UnitMovement(Unit unit)
        {
            Model = unit;
            Model.SetLayer(Layer);
            TargetPosition = Position;
        }

        public virtual void Update(float deltaTime)
        {
            MoveToTarget(deltaTime);
            if (InTargetPosition)
                AchievedTarget?.Invoke();
        }

        public void Push(Direction direction)
        {
            Vector3 newTarget = TargetPosition + (Vector3)direction.Position;
            TargetPosition = newTarget;
            Direction = direction;
            GoingToMove?.Invoke(direction);
        }

        public void TryStartPush(Direction direction)
        {
            if (InTargetPosition)
                TryingStartPush?.Invoke(direction);
        }

        public CheckingResult CheckMoveAbility(Stack<IUnitBehavior> nextUnitsStack, Direction movingDirection)
        {
            return InTargetPosition
                ? CheckNextUnitsStack(nextUnitsStack, movingDirection)
                : CheckingResult.MovementDenied;
        }

        protected CheckingResult CheckUnitToMove(IUnitBehavior behavior, Direction direction)
        {
            CheckingResult result = default;
            return UnitMatchesMovingRules(behavior, direction, ref result)
                ? result
                : CheckingResult.MovementDenied;
        }

        protected virtual bool UnitMatchesMovingRules(IUnitBehavior behavior, Direction direction, ref CheckingResult result)
        {
            return IsUnitNotMoving(behavior, ref result)
                || IsUnitAvailableFloor(behavior, direction, ref result);
        }

        protected bool IsUnitNotMoving(IUnitBehavior behavior, ref CheckingResult result)
        {
            if (behavior is IMovable movable && !movable.IsMoving)
            {
                result = CheckingResult.CheckNextCell;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsUnitAvailableFloor(IUnitBehavior behavior, Direction direction, ref CheckingResult result)
        {
            if (behavior is IFloor floor && floor.IsAvailiable(direction))
            {
                result = CheckingResult.MovementAllowed;
                return true;
            }
            else
            {
                return false;
            }
        }

        private CheckingResult CheckNextUnitsStack(Stack<IUnitBehavior> behaviors, Direction movingDirection)
        {
            foreach (IUnitBehavior behavior in behaviors)
            {
                CheckingResult result = CheckUnitToMove(behavior, movingDirection);
                if (result != CheckingResult.MovementDenied)
                    return result;
            }

            return CheckingResult.MovementDenied;
        }

        private void MoveToTarget(float deltaTime)
        {
            var newPosition = Vector3.MoveTowards(Position, TargetPosition, deltaTime * Config.MOVABLE_UNIT_SPEED);
            Model.SetPosition(newPosition);
        }
    }
}
