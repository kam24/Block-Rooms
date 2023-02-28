using BlockRooms.Model;
using UnityEngine;

public class UpdatableCellPresenter : CellPresenter
{
    private IUpdatable updatable;
    private bool IsPaused => Root.Instance.PauseController.IsPaused;

    public override void Init(TransformableCell cell)
    {
        base.Init(cell);
        updatable = (IUpdatable)cell;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        updatable.Update(Time.deltaTime);
    }
}

