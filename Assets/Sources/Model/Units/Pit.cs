using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public class Pit : UpdatableUnit
    {
        public bool Filled { get; private set; }

        private bool _processTrackedBlock = false;

        private IChangableBehavior _changableCell;
        private IMovable _incomingBlockMovement = null;

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
                _changableCell = cell;
                _incomingBlockMovement = cellMovement;
                _incomingBlockMovement.AchievedTarget += OnIncomingBlock_AchievedTarget;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void ResetTrackedBlock()
        {
            _changableCell = null;
            _incomingBlockMovement.AchievedTarget -= OnIncomingBlock_AchievedTarget;
            _incomingBlockMovement = null;
        }

        private void OnIncomingBlock_AchievedTarget()
        {
            _processTrackedBlock = true;
        }

        private void ProcessTrackedBlock()
        {
            if (_processTrackedBlock)
            {
                _changableCell.SwitchBehavior();
                Filled = true;
                ResetTrackedBlock();
                _processTrackedBlock = false;
            }
        }
    }
}
