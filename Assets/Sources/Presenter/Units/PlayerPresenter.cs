using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(PushableUnitPresenter))]
[RequireComponent(typeof(AttachmentGunPresenter))]
public class PlayerPresenter : UnitPresenter
{
    private void Awake()
    {
        var model = new Player(transform.position);

        var pushable = GetComponent<PushableUnitPresenter>();
        pushable.Init(model);

        Init(model);
        GetComponent<AttachmentGunPresenter>().enabled = true;
    }
}
