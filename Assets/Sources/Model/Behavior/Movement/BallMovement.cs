namespace BlockRooms.Model
{
    public class BallMovement : CellMovement
    {
        private IAttachable attachable;
        private Direction direction;
        private bool continueMoving = false;

        public BallMovement(TransformableCell cell) : base(cell)
        {
            attachable = (IAttachable)cell;
        }

        public override void Update(float deltaTime)
        {
            TryContinueMove();
            base.Update(deltaTime);
        }

        public void TryEnableContinuePush(Direction direction)
        {
            if (attachable.IsAttached == false)
            {
                continueMoving = true;
                this.direction = direction;
            }
        }

        public void DisableContinuePush()
        {
            continueMoving = false;
        }

        private void TryContinueMove()
        {
            if (InTargetPosition() && continueMoving)
                TryStartPush(direction);
        }
    }
}
