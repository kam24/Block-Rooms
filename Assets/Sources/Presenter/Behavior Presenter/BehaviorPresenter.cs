using BlockRooms.Model;
using UnityEngine;

public abstract class BehaviorPresenter : MonoBehaviour
{
    public TransformableCell Model { get; private set; }
    private IUpdatable updatable;
    private bool IsPaused => Root.Instance.PauseController.IsPaused;

    public void Init(TransformableCell model)
    {
        InitModel(model);
        InitBehavior(model.Behavior);
        enabled = true;
    }

    public void Init(TransformableCell model, ICellBehavior behavior)
    {
        InitModel(model);
        InitBehavior(behavior);
    }

    public abstract void InitBehavior(ICellBehavior behavior);

    private void InitModel(TransformableCell model)
    {
        this.Model = model;
        updatable = (IUpdatable)model;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        updatable.Update(Time.deltaTime);
    }
}

