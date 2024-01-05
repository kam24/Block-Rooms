using System;
using System.Collections.Generic;
using static BlockRooms.Model.UnitMovement;

namespace BlockRooms.Model
{
    public interface IMovable : IUnitBehavior, IUpdatable
    {
        public event Action AchievedTarget;
        public event Action<Direction> TryingStartPush;
        public event Action<Direction> GoingToMove;

        public bool IsMoving { get; }
        public bool InTargetPosition { get; }

        /// <summary>
        /// Предназначен для вызова из презентера.
        /// Вызывается только после успешной проверки на возможность перемещения
        /// </summary>
        public void Push(Direction direction);

        /// <summary>
        /// Начинает толчок, который будет обработан в презентере
        /// </summary>
        public void TryStartPush(Direction direction);

        public CheckingResult CheckMoveAbility(Stack<IUnitBehavior> nextCellType, Direction direction);
    }
}