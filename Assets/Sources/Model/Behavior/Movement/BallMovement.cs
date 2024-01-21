using BlockRooms.Model.Units.Extensions.Interfaces;
using System;

namespace BlockRooms.Model
{
    public class BallMovement : UnitMovement, IDisposable
    {
        private IAttachable _attachable;
        private Direction _direction;
        private bool _continueMoving = false;

        public BallMovement(Ball ball) : base(ball)
        {
            ball.Extensions.Added += OnExtensionAdded;
        }

        private void OnExtensionAdded(IExtension e)
        {
            if (e is IAttachable attachable)
            {
                _attachable = attachable;
               // _attachable.Attached += DisableContinuingMove;
                _attachable.Detached += TryEnableContinuingMove;
            }
        }

        public override void Update(float deltaTime)
        {
            TryContinueMove();
            base.Update(deltaTime);
        }

        public void TryEnableContinuingMove(Direction direction)
        {
            bool attached = _attachable != null && _attachable.IsAttached;

            if (!attached)
            {
                _continueMoving = true;
                _direction = direction;
            }
        }

        public void DisableContinuingMove()
        {
            _continueMoving = false;
        }

        public void Dispose()
        {
            if (_attachable != null)
            {
                _attachable.Attached -= DisableContinuingMove;
                _attachable.Detached -= TryEnableContinuingMove;
            }
        }

        private void TryContinueMove()
        {
            if (InTargetPosition && _continueMoving)
                TryStartPush(_direction);
        }

        private void TryEnableContinuingMove()
        {
            if (IsMoving)
                TryEnableContinuingMove(Direction);
        }

    }
}
