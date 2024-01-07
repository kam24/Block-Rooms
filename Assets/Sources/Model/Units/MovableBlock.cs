using BlockRooms.Model.Units.Extensions.Interfaces;
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
                if (Extensions.Has(out IAttachable attachable))
                {
                    attachable.Disable();
                    Extensions.Remove<IAttachable>();
                }
                SetBehavior(FloorType);
            }
            else if (Behavior is FloorBehavior)
            {
                SetBehavior(MovableType);
            }
        }
    }
}
