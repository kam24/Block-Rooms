using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class CellMovement : IMovable
    {
        public Cell.LayerPosition Layer => Cell.LayerPosition.MovableBlock;

        public event Action AchievedTarget;
        public event Action<Direction> TryingStartPush;
        public event Action<Direction> GoingToMove;

        public TransformableCell Model { get; private set; }
        public Direction Direction { get; private set; }
        protected Vector3 Position => Model.Position;
        protected Vector3 TargetPosition { get; private set; }

        public enum CheckingResult
        {
            MovementAllowed,
            MovementDenied,
            CheckNextCell,
            TypeDoesNotMatch
        }

        public CellMovement(TransformableCell cell)
        {
            Model = cell;
            Model.SetLayer(Layer);
            TargetPosition = Position;
        }

        public virtual void Update(float deltaTime)
        {
            MoveToTarget(deltaTime);

            if (InTargetPosition())
                AchievedTarget?.Invoke();
        }

        public bool IsMoving() => Position != TargetPosition;

        public bool InTargetPosition() => Position == TargetPosition;

        public void Push(Direction direction)
        {
            Vector3 newTarget = Position + (Vector3)direction.Position;
            TargetPosition = newTarget;
            Direction = direction;
            GoingToMove?.Invoke(direction);
        }

        public void TryStartPush(Direction direction)
        {
            if (InTargetPosition())
                TryingStartPush?.Invoke(direction);
        }

        public CheckingResult CheckMoveAbility(Stack<ICellBehavior> nextTypeStack, Direction direction)
        {
            if (IsMoving())
                return CheckingResult.MovementDenied;

            return CheckNextCellStack(nextTypeStack, direction);
        }

        protected virtual CheckingResult CheckCell(ICellBehavior behavior, Direction direction)
        {
            if (behavior is IMovable movable && movable.IsMoving() == false)
                return CheckingResult.CheckNextCell;
            else if (behavior is IFloor floor && floor.IsAvailiable(direction))
                return CheckingResult.MovementAllowed;
            else
                return CheckingResult.MovementDenied;
        }

        private CheckingResult CheckNextCellStack(Stack<ICellBehavior> behaviorStack, Direction direction)
        {
            foreach (var behavior in behaviorStack)
            {
                CheckingResult result = CheckCell(behavior, direction);
                if (result != CheckingResult.MovementDenied)
                    return result;
            }

            return CheckingResult.MovementDenied;
        }

        private void MoveToTarget(float deltaTime)
        {
            Model.ChangePosition(Vector3.MoveTowards(Position, TargetPosition, deltaTime * Config.MovableCellSpeed));
        }
    }
}
