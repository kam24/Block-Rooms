using BlockRooms.Model;
using UnityEngine;

public class UpdatableUnitPresenter : UnitPresenter
{
    private IUpdatable _updatable;
    private bool IsPaused => Root.Instance.PauseController.IsPaused;

    public void Init(UpdatableUnit unit)
    {
        base.Init(unit);
        _updatable = (IUpdatable)unit;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        _updatable.Update(Time.deltaTime);
    }
}

