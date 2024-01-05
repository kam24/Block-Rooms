using BlockRooms.Model.Units.Extensions.Interfaces;
using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public class MovableBlock : UpdatableUnit, IChangableBehavior
    {
        public BlockMovement MovableType { get; private set; }
        public FloorBehavior FloorType { get; private set; }

        public MovableBlock(Vector3 position) : base(position)
        {
            MovableType = new BlockMovement(this);
            FloorType = new FloorBehavior();

            SetBehavior(MovableType);
        }

        public void SwitchBehavior()
        {
            if (Behavior is BlockMovement)
            {
                Extensions.Remove<IAttachable>();
                SetBehavior(FloorType);
            }
            else if (Behavior is FloorBehavior)
            {
                SetBehavior(MovableType);
            }
        }
    }
}
