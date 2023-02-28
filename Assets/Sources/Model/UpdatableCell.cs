using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class UpdatableCell : TransformableCell, IUpdatable
    {
        private IUpdatable updatableBehavior;

        protected UpdatableCell(Vector3 position) : base(position) { }

        public virtual void Update(float deltaTime)
        {
            updatableBehavior?.Update(deltaTime);
        }

        protected override void SetBehavior(ICellBehavior behavior)
        {
            base.SetBehavior(behavior);
            if (Behavior is IUpdatable updatable)
                updatableBehavior = updatable;
            else
                updatableBehavior = null;
        }
    }
}
