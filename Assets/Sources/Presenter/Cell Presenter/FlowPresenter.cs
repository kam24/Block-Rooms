using BlockRooms.Model;
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FlowPresenter : UpdatableCellPresenter
{
    [SerializeField] private Direction.Angle direction;
    private Flow flow;

    private void OnValidate()
    {
        float angle = (float)direction;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Awake()
    {
        Direction direction = GetDirection(transform.rotation.eulerAngles.z);
        flow = new Flow(transform.position, direction);
        Init(flow);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCell = collision.transform.TryGetComponent<CellPresenter>(out var cellPresenter);

        if (isCell && cellPresenter.Behavior is IMovable movableBlock)
            flow.SetTrackedBlock(movableBlock);
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
