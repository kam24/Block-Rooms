using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(PlayerMovementPresenter))]
[RequireComponent(typeof(AttachmentGunPresenter))]
public class PlayerPresenter : UnitPresenter
{
    private void Awake()
    {
        var model = new Player(transform.position);

        var pushable = GetComponent<PlayerMovementPresenter>();
        pushable.Init(model);

        Init(model);
        GetComponent<AttachmentGunPresenter>().enabled = true;
    }
}
