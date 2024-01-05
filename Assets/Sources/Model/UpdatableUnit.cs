using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class UpdatableUnit : Unit, IUpdatable
    {
        private IUpdatable _updatableBehavior;

        protected UpdatableUnit(Vector3 position) : base(position) { }

        public virtual void Update(float deltaTime)
        {
            _updatableBehavior?.Update(deltaTime);
        }

        protected override void SetBehavior(IUnitBehavior behavior)
        {
            base.SetBehavior(behavior);
            _updatableBehavior = behavior as IUpdatable;
        }
    }
}
