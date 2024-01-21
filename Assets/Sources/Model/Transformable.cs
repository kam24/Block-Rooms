using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class Transformable
    {
        public Vector3 Position { get; private set; }

        public event Action PositionChanged;

        public Transformable(Vector3 position)
        {
            Position = position;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
            PositionChanged?.Invoke();
        }

        public void SetPosition2D(Vector3 position)
        {
            Position = new Vector3()
            {
                x = position.x,
                y = position.y,
                z = Position.z,
            };
            PositionChanged?.Invoke();
        }
    }
}
