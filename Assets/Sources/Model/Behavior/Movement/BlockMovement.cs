using System;
using System.Collections.Generic;

namespace BlockRooms.Model
{
    public class BlockMovement : UnitMovement
    {
        /// <summary>
        /// Принимает блок только с изменяемым типом (он изменится при попадании в яму)
        /// </summary>
        public BlockMovement(Unit cell) : base(cell)
        {
            if (cell is not IChangableBehavior)
                throw new InvalidCastException(nameof(cell));
        }

        protected override bool UnitMatchesMovingRules(IUnitBehavior behavior, Direction direction, ref CheckingResult result)
        {
            return base.UnitMatchesMovingRules(behavior, direction, ref result)
                  || IsUnitPit(behavior, ref result);
        }

        protected bool IsUnitPit(IUnitBehavior behavior, ref CheckingResult result) 
        {
            if (behavior is IPit)
            {
                result = CheckingResult.MovementAllowed;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
