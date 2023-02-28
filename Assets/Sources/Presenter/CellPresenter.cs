using BlockRooms.Model;
using UnityEngine;

public class CellPresenter : MonoBehaviour
{
    public TransformableCell Model => model;
    public ICellBehavior Behavior => model.Behavior;
    private TransformableCell model;

    public virtual void Init(TransformableCell cell)
    {
        model = cell;
        enabled = true;

        OnPositionChanged();
    }

    protected virtual void Enable()
    {
        model.PositionChanged += OnPositionChanged;
    }

    protected virtual void Disable()
    {
        model.PositionChanged -= OnPositionChanged;
    }

    private void OnEnable() => Enable();

    private void OnDisable() => Disable();

    private void OnPositionChanged() => transform.position = model.Position;
}
