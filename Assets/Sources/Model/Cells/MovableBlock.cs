using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public class MovableBlock : AttachableCell, IChangableBehavior
    {
        public BlockMovement MovableType { get; private set; }
        public FloorBehavior FloorType { get; private set; }

        public MovableBlock(Vector3 position) : base(position)
        {
            MovableType = new BlockMovement(this);
            FloorType = new FloorBehavior();

            SetBehavior(MovableType);
        }

        public void SwitchCellType()
        {
            if (Behavior is BlockMovement)
            {
                SetNonAttachable();
                SetBehavior(FloorType);
            }
            else if (Behavior is FloorBehavior)
            {
                SetBehavior(MovableType);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
