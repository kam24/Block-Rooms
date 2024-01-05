using BlockRooms.Model.Units.Extensions.Interfaces;

namespace BlockRooms.Model
{
    public class BallMovement : UnitMovement
    {
        private IAttachable _attachable;
        private Direction _direction;
        private bool _continueMoving = false;

        public BallMovement(Ball ball) : base(ball)
        {
            _attachable = ball.Extensions.Get<IAttachable>();
        }

        public override void Update(float deltaTime)
        {
            TryContinueMove();
            base.Update(deltaTime);
        }

        public void TryEnableContinuingMove(Direction direction)
        {
            bool isNotAttached = _attachable == null || !_attachable.IsAttached;

            if (isNotAttached)
            {
                _continueMoving = true;
                _direction = direction;
            }
        }

        public void DisableContinuingMove()
        {
            _continueMoving = false;
        }

        private void TryContinueMove()
        {
            if (InTargetPosition && _continueMoving)
                TryStartPush(_direction);
        }
    }
}
