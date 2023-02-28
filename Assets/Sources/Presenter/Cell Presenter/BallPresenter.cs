using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(BallMovementPresenter))]
public class BallPresenter : AttachableCellPresenter
{
    private void Awake()
    {
        var model = new Ball(transform.position);

        if (IsAttachable)
            model.SetAttachable();

        var pushable = GetComponent<BallMovementPresenter>();
        pushable.Init(model);

        Init(model);
    }

}
