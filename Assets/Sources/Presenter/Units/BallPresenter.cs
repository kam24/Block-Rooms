using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(BallMovementPresenter))]
[RequireComponent(typeof(AttachablePresenter))]
public class BallPresenter : UnitPresenter
{
    private void Awake()
    {
        var model = new Ball(transform.position);

        var attachablePresenter = GetComponent<AttachablePresenter>();
        if (attachablePresenter.IsEnabled)
            attachablePresenter.IncludeExtension(model);

        var pushable = GetComponent<BallMovementPresenter>();
        pushable.Init(model);

        Init(model);
    }
}