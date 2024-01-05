using BlockRooms.Model;
using UnityEngine;

public class UnitPresenter : MonoBehaviour
{
    public Unit Model => _model;
    public IUnitBehavior Behavior => _model.Behavior;

    private Unit _model;

    public virtual void Init(Unit unit)
    {
        _model = unit;
        enabled = true;

        OnPositionChanged();
    }

    private void OnEnable() => Enable();

    private void OnDisable() => Disable();

    protected virtual void Enable() => _model.PositionChanged += OnPositionChanged;

    protected virtual void Disable() => _model.PositionChanged -= OnPositionChanged;

    private void OnPositionChanged() => transform.position = _model.Position;
}
