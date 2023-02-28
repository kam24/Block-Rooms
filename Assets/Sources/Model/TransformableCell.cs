using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class TransformableCell : Transformable
    {
        public event Action<ICellBehavior> BehaviorChanged;

        public ICellBehavior Behavior { get; private set; }

        public TransformableCell(Vector3 position) : base(position) { }

        public TransformableCell(Vector3 position, ICellBehavior cellBehavior) : base(position)
        {
            Behavior = cellBehavior;
        }

        public void SetLayer(Cell.LayerPosition layer)
        {
            var newPosition = new Vector3(Position.x, Position.y, (float)layer);
            ChangePosition(newPosition);
        }

        protected virtual void SetBehavior(ICellBehavior behavior)
        {
            Behavior = behavior;
            SetLayer(behavior.Layer);
            BehaviorChanged?.Invoke(Behavior);
        }
    }
}
