using BlockRooms.Model;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Rigidbody2D))]
[RequireComponent(typeof(FloorBehaviorPresenter), typeof(PushableUnitPresenter), typeof(AttachablePresenter))]
public class MovableBlockPresenter : UnitPresenter
{
    [SerializeField] private Sprite _movableBlockSprite;
    [SerializeField] private Sprite _blockInPitSprite;
    private SpriteRenderer _spriteRenderer;

    private MovableBlock _movableBlock;

    private PushableUnitPresenter _pushable;
    private FloorBehaviorPresenter _floor;
    private Behaviour _currentType;

    private void Awake()
    {
        _movableBlock = new MovableBlock(transform.position);

        var attachablePresenter = GetComponent<AttachablePresenter>();
        if (attachablePresenter.IsEnabled)
            attachablePresenter.IncludeExtension(_movableBlock);

        Init(_movableBlock);

        _pushable = GetComponent<PushableUnitPresenter>();
        _pushable.Init(_movableBlock, _movableBlock.MovableType);

        _floor = GetComponent<FloorBehaviorPresenter>();
        _floor.Init(_movableBlock, _movableBlock.FloorType);

        SetBehaviorPresenter(_pushable);

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Enable()
    {
        base.Enable();
        _movableBlock.BehaviorChanged += SetType;
    }

    protected override void Disable()
    {
        base.Disable();
        _movableBlock.BehaviorChanged -= SetType;
    }

    private void SetType(IUnitBehavior behavior)
    {
        if (behavior is IMovable)
        {
            SwitchBehaviorPresenter(_pushable);
            _spriteRenderer.sprite = _movableBlockSprite;
        }
        else if (behavior is IFloor)
        {
            SwitchBehaviorPresenter(_floor);
            _spriteRenderer.sprite = _blockInPitSprite;
        }
    }

    private void SetBehaviorPresenter(BehaviorPresenter typePresenter)
    {
        _currentType = typePresenter;
        _currentType.enabled = true;
    }

    private void SwitchBehaviorPresenter(BehaviorPresenter typePresenter)
    {
        _currentType.enabled = false;
        SetBehaviorPresenter(typePresenter);
    }
}
