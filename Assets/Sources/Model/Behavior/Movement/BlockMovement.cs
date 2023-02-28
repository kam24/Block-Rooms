using System;
using System.Collections.Generic;

namespace BlockRooms.Model
{
    public class BlockMovement : CellMovement
    {
        /// <summary>
        /// Принимает блок только с изменяемым типом (он изменится при попадании в яму)
        /// </summary>
        /// <param name="cell"></param>
        /// <exception cref="InvalidCastException"></exception>
        public BlockMovement(TransformableCell cell) : base(cell)
        {
            if (cell is not IChangableBehavior)
                throw new InvalidCastException(nameof(cell));
        }

        protected override CheckingResult CheckCell(ICellBehavior behavior, Direction direction)
        {
            CheckingResult result = base.CheckCell(behavior, direction);

            if (result == CheckingResult.MovementDenied && behavior is IPit)
                return CheckingResult.MovementAllowed;

            return result;
        }
    }
}
