using BlockRooms.Model.Units.Extensions.Interfaces;
using UnityEngine;
using static BlockRooms.Model.Direction;

namespace BlockRooms.Model
{
    public class AttachmentGun : IUpdatable
    {
        public Transformable Point { get; private set; }
        public Vector2 Position => Point.Position;
        public bool Attached { get; private set; }

        private Transformable _block;
        private IMovable _blockMovement;
        private IAttachable _attachable;
        private Direction _direction;

        public AttachmentGun(Transformable point)
        {
            this.Point = point;
            Attached = false;
        }

        public void Set(Unit block, Direction direction)
        {
            ResetIfAttached();

            Attached = true;
            _block = block;
            _direction = direction;
            _blockMovement = (IMovable)block.Behavior;
            _attachable = block.Extensions.Get<IAttachable>();
            _attachable.SetAttached();
            _attachable.Disabled += ResetIfAttached;
        }

        public void ResetIfAttached()
        {
            if (Attached)
            {
                Attached = false;
                _attachable.Disabled -= ResetIfAttached;
                _attachable.SetDetached();
                _attachable = null;
                _block = null;
                _blockMovement = null;
            }
        }

        public void TryPushBlock(Direction direction)
        {
            if (Attached)
                _blockMovement.TryStartPush(direction);
        }

        public bool CanBeAttached(Unit block, Direction direction)
        {            
            bool isBlockClose = VectorExtension.Equals(Position + direction.Position, block.Position);
            bool isBlockAttachable = block.Extensions.Has<IAttachable>();

            return isBlockClose && isBlockAttachable;
        }

        public void Update(float deltaTime)
        {
            ResetAttachedBlockIfNotClose();
        }

        private void ResetAttachedBlockIfNotClose()
        {
            if (!Attached)
                return;

            bool isAttachedBlockClose = VectorExtension.Equals(Position + _direction.Position, _block.Position);
            if (!isAttachedBlockClose)
                ResetIfAttached();
        }
    }
}
