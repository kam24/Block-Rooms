using BlockRooms.Model;
using System.Collections.Generic;
using UnityEngine;

public class CellFinder
{
    public static bool TryGetCell(Vector2 position, LayerMask layer, out CellPresenter presenter)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector3.zero, float.PositiveInfinity, layer);
        presenter = null;

        if (hit.transform != null)
            return hit.transform.TryGetComponent(out presenter);
        else
            return false;
    }

    public static bool TryGetTopCell<T>(Vector2 position, out T presenter)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector3.zero);
        presenter = default;

        if (hit.transform != null)
            return hit.transform.TryGetComponent(out presenter);
        else
            return false;
    }

    public static Stack<ICellBehavior> GetCellsStack(Vector2 position)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.zero);

        return GetSortedStack(hits);
    }

    private static Stack<ICellBehavior> GetSortedStack(RaycastHit2D[] hits)
    {
        Stack<ICellBehavior> behaviors = new();
        Dictionary<int, ICellBehavior> behaviorsDict = new();
        ICellBehavior behavior;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.TryGetComponent<CellPresenter>(out CellPresenter presenter))
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

    private static int GetNumberOfLayer(ICellBehavior type)
    {
        if (type is IBlock)
            return 5;
        if (type is IMovable)
            return 4;
        if (type is IFlooring)
            return 3;
        if (type is IFloor)
            return 2;
        if (type is IPit)
            return 1;

        return 0;
    }
}

