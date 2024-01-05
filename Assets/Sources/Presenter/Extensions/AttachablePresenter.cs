using BlockRooms.Model;
using BlockRooms.Model.Units.Extensions;
using System;
using UnityEngine;

public class AttachablePresenter : ExtensionPresenter
{
    [SerializeField] private Sprite _attached;

    private AttachableExtension _attachable;

    private SpriteRenderer _unitRenderer;
    private SpriteRenderer _markRenderer;
    private Sprite _commonSprite;

    private readonly string _attachableName = "Attachable";

    public override void IncludeExtension(Unit unit)
    {
        var attachableUnit = new AttachableExtension();
        unit.Extensions.Add(attachableUnit);
        Init(attachableUnit);
    }

    private void Init(AttachableExtension attachable)
    {
        _attachable = attachable;
        enabled = true;
    }

    private void OnEnable()
    {
        _unitRenderer = GetComponent<SpriteRenderer>();
        _commonSprite = _unitRenderer.sprite;

        OnValidate();

        _attachable.Attached += OnAttached;
        _attachable.Detached += OnDetached;
        _attachable.BecomesNonAttachable += ResetMark;
    }

    private void OnDisable()
    {
        _attachable.Attached -= OnAttached;
        _attachable.Detached -= OnDetached;
        _attachable.BecomesNonAttachable -= ResetMark;
    }

    private void OnValidate()
    {
        TryFindMark();
        UpdateMark();
    }

    private void TryFindMark()
    {
        Transform attachmentChild = gameObject.transform.GetChild(0);
        _markRenderer = attachmentChild != null && attachmentChild.name == _attachableName
            ? attachmentChild.GetComponent<SpriteRenderer>()
            : throw new InvalidOperationException();
    }

    private void ResetMark()
    {
        isEnabled = false;
        UpdateMark();
    }

    private void UpdateMark() => _markRenderer.enabled = isEnabled;

    private void OnAttached() => _unitRenderer.sprite = _attached;

    private void OnDetached() => _unitRenderer.sprite = _commonSprite;
}

