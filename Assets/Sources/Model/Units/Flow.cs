using UnityEngine;

namespace BlockRooms.Model
{
    public class Flow : UpdatableUnit
    {
        private IMovable IncomingBlockMovement;
        private Direction direction;
        private bool processTrackedBlock = false;

        public Flow(Vector3 position, Direction direction) : base(position)
        {
            this.direction = direction;
            SetBehavior(new FlooringBehavior());
        }

        public override void Update(float deltaTime)
        {
            ProcessTrackedBlock();
        }

        public void SetTrackedBlock(IMovable movement)
        {
            IncomingBlockMovement = movement;
            IncomingBlockMovement.AchievedTarget += OnIncomingBlock_AchievedTarget;
            IncomingBlockMovement.GoingToMove += ResetTrackedBlock;
        }

        private void ResetTrackedBlock(Direction dir)
        {
            IncomingBlockMovement.AchievedTarget -= OnIncomingBlock_AchievedTarget;
            IncomingBlockMovement.GoingToMove -= ResetTrackedBlock;
            IncomingBlockMovement = null;
            processTrackedBlock = false;
        }

        private void OnIncomingBlock_AchievedTarget()
        {
            processTrackedBlock = true;
        }

        private void ProcessTrackedBlock()
        {
            if (processTrackedBlock)
            {
                IncomingBlockMovement.TryStartPush(direction);
            }
        }
    }
}
