using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public class Pit : UpdatableUnit
    {
        public bool Filled { get; private set; }

        private bool processTrackedBlock = false;

        private IChangableBehavior changableCell;
        private IMovable incomingBlockMovement = null;

        public Pit(Vector3 position) : base(position)
        {
            SetBehavior(new PitBehavior());
        }

        public override void Update(float deltaTime)
        {
            ProcessTrackedBlock();
        }

        public void TrySetTrackedBlock(IChangableBehavior cell, IMovable cellMovement)
        {
            if (!Filled)
            {
                changableCell = cell;
                incomingBlockMovement = cellMovement;
                incomingBlockMovement.AchievedTarget += OnIncomingBlock_AchievedTarget;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void ResetTrackedBlock()
        {
            changableCell = null;
            incomingBlockMovement.AchievedTarget -= OnIncomingBlock_AchievedTarget;
            incomingBlockMovement = null;
        }

        private void OnIncomingBlock_AchievedTarget()
        {
            processTrackedBlock = true;
        }

        private void ProcessTrackedBlock()
        {
            if (processTrackedBlock)
            {
                changableCell.SwitchBehavior();
                Filled = true;
                ResetTrackedBlock();
                processTrackedBlock = false;
            }
        }
    }
}
