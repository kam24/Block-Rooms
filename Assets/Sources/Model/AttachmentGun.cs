using UnityEngine;

namespace BlockRooms.Model
{
    public class AttachmentGun : IUpdatable
    {
        public Transformable Point { get; private set; }
        public Vector2 Position => Point.Position;
        public bool Attached { get; private set; }

        private Transformable block;
        private IMovable blockMovement;
        private IAttachable attachable;
        private Direction direction;

        public AttachmentGun(Transformable point)
        {
            this.Point = point;
            Attached = false;
        }

        public void Set(TransformableCell block, Direction direction)
        {
            if (Attached)
                Reset();

            Attached = true;
            this.block = block;
            this.direction = direction;
            blockMovement = (IMovable)block.Behavior;
            attachable = (IAttachable)block;
            attachable.SetAttached();
            attachable.BecomesNonAttachable += Reset;
        }

        public void Reset()
        {
            if (Attached)
            {
                Attached = false;
                attachable.BecomesNonAttachable -= Reset;
                attachable.SetDetached();
                block = null;
                blockMovement = null;
                attachable = null;
            }
        }

        public void TryPushBlock(Direction direction)
        {
            if (Attached)
                blockMovement.TryStartPush(direction);
        }

        public bool CanBeAttached(TransformableCell block, Direction direction)
        {
            bool isBlockClose = Direction.Compare(Position, block.Position, direction, Direction.OperationType.Equals);

            return isBlockClose && block is IAttachable attachable && attachable.Enabled;
        }

        public void Update(float deltaTime)
        {
            CheckAttachedBlock();
        }

        private void CheckAttachedBlock()
        {
            if (Attached && Direction.Compare(Position, block.Position, direction, Direction.OperationType.Equals) == false)
                Reset();
        }
    }
}
