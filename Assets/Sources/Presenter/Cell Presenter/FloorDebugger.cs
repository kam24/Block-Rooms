using BlockRooms.Model;
using System.Collections.Generic;
using UnityEngine;

public class FloorDebugger : FloorPresenter
{
    [SerializeField] private SpriteRenderer upMark;
    [SerializeField] private SpriteRenderer leftMark;
    [SerializeField] private SpriteRenderer downMark;
    [SerializeField] private SpriteRenderer rightMark;
    [SerializeField] private Sprite allowed;
    [SerializeField] private Sprite banned;

    protected override void Enable()
    {
        base.Enable();
        floor.ChangedAllowedDirections += OnChangedAllowedDirections;
    }

    protected override void Disable()
    {
        base.Disable();
        floor.ChangedAllowedDirections -= OnChangedAllowedDirections;
    }

    private void OnChangedAllowedDirections(List<FloorDirection> obj)
    {
        foreach (var direction in obj)
        {
            if (direction.Value == Direction.Up)
                upMark.sprite = direction.Allowed ? allowed : banned;
            if (direction.Value == Direction.Left)
                leftMark.sprite = direction.Allowed ? allowed : banned;
            if (direction.Value == Direction.Down)
                downMark.sprite = direction.Allowed ? allowed : banned;
            if (direction.Value == Direction.Right)
                rightMark.sprite = direction.Allowed ? allowed : banned;
        }
    }

}
