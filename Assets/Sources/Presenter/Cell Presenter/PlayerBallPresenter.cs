using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(PlayerMovementPresenter))]
[RequireComponent(typeof(AttachmentGunPresenter))]
public class PlayerBallPresenter : CellPresenter
{
    private void Awake()
    {
        var model = new PlayerBall(transform.position);
        var pushable = GetComponent<PlayerMovementPresenter>();
        pushable.Init(model);
        Init(model);
        GetComponent<AttachmentGunPresenter>().enabled = true;
    }
}
