using System;
using System.Collections.Generic;
using static BlockRooms.Model.CellMovement;

namespace BlockRooms.Model
{
    public interface IMovable : ICellBehavior, IUpdatable
    {
        event Action AchievedTarget;
        event Action<Direction> TryingStartPush;
        event Action<Direction> GoingToMove;
        bool IsMoving();
        bool InTargetPosition();

        /// <summary>
        /// Предназначен для вызова из презентера.
        /// Вызывается только после успешной проверки на возможность перемещения
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        void Push(Direction direction);
        /// <summary>
        /// Начинает толчок, который будет обработан в презентере
        /// </summary>
        /// <param name="direction"></param>
        void TryStartPush(Direction direction);
        CheckingResult CheckMoveAbility(Stack<ICellBehavior> nextCellType, Direction direction);

    }
}