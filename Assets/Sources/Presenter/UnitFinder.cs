using BlockRooms.Model;
using System.Collections.Generic;
using UnityEngine;

public class UnitFinder
{
    public static bool TryGetUnit(Vector2 position, LayerMask layer, out UnitPresenter presenter)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector3.zero, float.PositiveInfinity, layer);
        presenter = default;

        return hit.transform != null && hit.transform.TryGetComponent(out presenter);
    }

    public static bool TryGetTopUnit<T>(Vector2 position, out T presenter) where T : class
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector3.zero);
        presenter = default;

        return hit.transform != null && hit.transform.TryGetComponent(out presenter);
    }

    public static Stack<IUnitBehavior> GetUnitsStack(Vector2 position)
    {
        RaycastHit2D[] hits = default;
        try
        {
            hits = Physics2D.RaycastAll(position, Vector2.zero);
        }
        catch
        {

        }

        return GetSortedStack(hits);
    }

    private static Stack<IUnitBehavior> GetSortedStack(RaycastHit2D[] hits)
    {
        Stack<IUnitBehavior> behaviors = new();
        Dictionary<int, IUnitBehavior> behaviorsDict = new();
        IUnitBehavior behavior;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.TryGetComponent(out UnitPresenter presenter))
                behavior = presenter.Behavior;
            else
                continue;

            int layer = GetNumberOfLayer(behavior);
            if (layer > 0)
                behaviorsDict.Add(layer, behavior);
        }

        for (int i = 1; i <= 5; i++)
            if (behaviorsDict.ContainsKey(i))
                behaviors.Push(behaviorsDict[i]);

        behaviorsDict.Clear();

        return behaviors;
    }

    private static int GetNumberOfLayer(IUnitBehavior type)
    {
        return type switch
        {
            (IBlock) => 5,
            (IMovable) => 4,
            (IFlooring) => 3,
            (IFloor) => 2,
            (IPit) => 1,
            _ => 0,
        };
    }
}

