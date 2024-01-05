using BlockRooms.Model;
using System.Collections.Generic;
using UnityEngine;

public class FloorDebugger : FloorPresenter
{
    [SerializeField] private SpriteRenderer _upMark;
    [SerializeField] private SpriteRenderer _leftMark;
    [SerializeField] private SpriteRenderer _downMark;
    [SerializeField] private SpriteRenderer _rightMark;
    [SerializeField] private Sprite _allowed;
    [SerializeField] private Sprite _banned;

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
                _upMark.sprite = direction.Allowed ? _allowed : _banned;
            if (direction.Value == Direction.Left)
                _leftMark.sprite = direction.Allowed ? _allowed : _banned;
            if (direction.Value == Direction.Down)
                _downMark.sprite = direction.Allowed ? _allowed : _banned;
            if (direction.Value == Direction.Right)
                _rightMark.sprite = direction.Allowed ? _allowed : _banned;
        }
    }

}
