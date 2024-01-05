using BlockRooms.Model;

public class BallMovementPresenter : PushableUnitPresenter
{
    public new BallMovement Movement => base.Movement as BallMovement;

    public override bool TryPush(Direction direction)
    {
        bool pushDone = base.TryPush(direction);

        if (pushDone)
            Movement.TryEnableContinuingMove(direction);
        else
            Movement.DisableContinuingMove();

        return pushDone;
    }
}

