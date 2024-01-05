using BlockRooms.Model;
using UnityEngine;

public abstract class BehaviorPresenter : MonoBehaviour
{
    public Unit Model { get; private set; }
    private IUpdatable _updatable;
    private bool IsPaused => Root.Instance.PauseController.IsPaused;

    public abstract void InitBehavior(IUnitBehavior behavior);

    public void Init(Unit model)
    {
        InitModel(model);
        InitBehavior(model.Behavior);
        enabled = true;
    }

    public void Init(Unit model, IUnitBehavior behavior)
    {
        InitModel(model);
        InitBehavior(behavior);
    }

    private void InitModel(Unit model)
    {
        this.Model = model;
        _updatable = (IUpdatable)model;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        _updatable.Update(Time.deltaTime);
    }
}

