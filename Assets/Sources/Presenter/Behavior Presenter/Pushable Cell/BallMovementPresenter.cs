using BlockRooms.Model;

public class BallMovementPresenter : PushableCellPresenter
{
    public new BallMovement Movement => base.Movement as BallMovement;

    public override bool TryPush(Direction direction)
    {
        bool pushDone = base.TryPush(direction);

        if (pushDone)
            Movement.TryEnableContinuePush(direction);
        else
            Movement.DisableContinuePush();

        return pushDone;
    }
}

