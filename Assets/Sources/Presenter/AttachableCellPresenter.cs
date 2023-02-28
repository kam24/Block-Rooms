using BlockRooms.Model;
using System;
using UnityEngine;

public class AttachableCellPresenter : CellPresenter
{
    [SerializeField] private bool isAttachable = true;
    [SerializeField] private Sprite attached;

    protected bool IsAttachable => isAttachable;
    private AttachableCell AttachableCell => Model as AttachableCell;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer markRenderer;
    private Sprite normal;

    private readonly string attachableName = "Attachable";

    protected override void Enable()
    {
        base.Enable();

        spriteRenderer = GetComponent<SpriteRenderer>();
        normal = spriteRenderer.sprite;

        OnValidate();

        AttachableCell.Attached += OnAttached;
        AttachableCell.Detached += OnDetached;
        AttachableCell.BecomesNonAttachable += ResetMark;
    }

    protected override void Disable()
    {
        base.Disable();
        AttachableCell.Attached -= OnAttached;
        AttachableCell.Detached -= OnDetached;
        AttachableCell.BecomesNonAttachable -= ResetMark;
    }

    private void OnValidate()
    {
        TryFindMark();
        UpdateMark();
    }

    private void TryFindMark()
    {
        Transform attachmentChild = gameObject.transform.GetChild(0);
        if (attachmentChild != null && attachmentChild.name == attachableName)
            markRenderer = attachmentChild.GetComponent<SpriteRenderer>();
        else
            throw new InvalidOperationException();
    }

    private void UpdateMark() => markRenderer.enabled = isAttachable;

    private void ResetMark()
    {
        isAttachable = false;
        UpdateMark();
    }

    private void OnAttached() => spriteRenderer.sprite = attached;

    private void OnDetached() => spriteRenderer.sprite = normal;
}

