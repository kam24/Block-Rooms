using BlockRooms.Model;
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Rigidbody2D))]
[RequireComponent(typeof(FloorBehaviorPresenter), typeof(PushableCellPresenter))]
public class MovableBlockPresenter : AttachableCellPresenter
{
    [SerializeField] private Sprite movableBlock;
    [SerializeField] private Sprite blockInPit;
    private SpriteRenderer _spriteRenderer;

    private MovableBlock model;

    private PushableCellPresenter pushable;
    private FloorBehaviorPresenter floor;
    private Behaviour currentType;

    private void Awake()
    {
        model = new MovableBlock(transform.position);

        if (IsAttachable)
            model.SetAttachable();

        Init(model);

        pushable = GetComponent<PushableCellPresenter>();
        pushable.Init(model, model.MovableType);

        floor = GetComponent<FloorBehaviorPresenter>();
        floor.Init(model, model.FloorType);

        SetBehaviorPresenter(pushable);

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Enable()
    {
        base.Enable();
        model.BehaviorChanged += TrySetType;
    }

    protected override void Disable() 
    {
        base.Disable();
        model.BehaviorChanged -= TrySetType;
    }

    private void TrySetType(ICellBehavior behavior)
    {
        if (behavior is IMovable)
        {
            SwitchBehaviorPresenter(pushable);
            _spriteRenderer.sprite = movableBlock;
        }
        else if (behavior is IFloor)
        {
            SwitchBehaviorPresenter(floor);
            _spriteRenderer.sprite = blockInPit;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private void SetBehaviorPresenter(BehaviorPresenter typePresenter)
    {
        currentType = typePresenter;
        currentType.enabled = true;
    }

    private void SwitchBehaviorPresenter(BehaviorPresenter typePresenter)
    {
        currentType.enabled = false;
        SetBehaviorPresenter(typePresenter);
    }
}
