using BlockRooms.Model;
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FlowPresenter : UpdatableUnitPresenter
{
    [SerializeField] private Direction.Angle _direction;
    private Flow _flow;

    private void OnValidate()
    {
        float angle = (float)_direction;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Awake()
    {
        Direction direction = GetDirection(transform.rotation.eulerAngles.z);
        _flow = new Flow(transform.position, direction);
        Init(_flow);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCell = collision.transform.TryGetComponent<UnitPresenter>(out var cellPresenter);

        if (isCell && cellPresenter.Behavior is IMovable movableBlock)
            _flow.SetTrackedBlock(movableBlock);
    }

    private Direction GetDirection(float eulerAngles)
    {
        return eulerAngles switch
        {
            0 => Direction.Up,
            90 => Direction.Left,
            180 => Direction.Down,
            270 => Direction.Right,
            _ => throw new ArgumentOutOfRangeException(eulerAngles.ToString()),
        };
    }
}
