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

        public void ChangePosition(Vector3 position)
        {
            Position = position;
            PositionChanged?.Invoke();
        }
    }
}
