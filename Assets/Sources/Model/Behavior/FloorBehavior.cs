using System;
using System.Collections.Generic;

namespace BlockRooms.Model
{
    public class FloorBehavior : IFloor, IUpdatable
    {
        public UnitLayer Layer => UnitLayer.Floor;

        public event Action<Direction, IMovable> SetIncomingBlockForNextFloor;
        public event Action<List<FloorDirection>> ChangedAllowedDirections;

        private List<FloorDirection> _floorDirections = new(4);
        private Direction _bannedDirection;

        private IMovable _incomingBlock;
        private IMovable _outgoingBlock;

        private bool _processIncomingBlock = false;
        private bool _processOutgoingBlock = false;

        public FloorBehavior()
        {
            foreach (Direction dir in Direction.Directions)
                _floorDirections.Add(new FloorDirection(dir));
            ChangedAllowedDirections?.Invoke(_floorDirections);
        }

        public bool IsAvailiable(Direction direction) => MatchAllowedDirection(-direction);

        public void SetIncomingBlock(IMovable block, Direction direction)
        {
            _incomingBlock = block;
            SetOnlyOneAllowedDirection(-direction);
            _incomingBlock.AchievedTarget += OnIncomingBlock_AchievedTarget;
        }

        public void SetOutgoingBlock(IMovable block)
        {
            _outgoingBlock = block;
            _outgoingBlock.GoingToMove += OnOutgoingBlock_GoingToMove;
        }

        public void Update(float deltaTime)
        {
            ProcessOutgoingBlock();
            ProcessIncomingBlock();
        }

        private void ProcessIncomingBlock()
        {
            if (_processIncomingBlock)
            {
                AllowAllFloorDirections();
                SetOutgoingBlock(_incomingBlock);
                _incomingBlock.AchievedTarget -= OnIncomingBlock_AchievedTarget;
                _incomingBlock = null;
                _processIncomingBlock = false;
            }
        }

        private void ProcessOutgoingBlock()
        {
            if (_processOutgoingBlock)
            {
                if (_incomingBlock == null)
                    AllowTwoOppositeDirections();
                _outgoingBlock.AchievedTarget -= OnOutgoingBlock_AchievedTarget;
                _outgoingBlock = null;
                _processOutgoingBlock = false;
            }
        }

        private void OnIncomingBlock_AchievedTarget()
        {
            _processIncomingBlock = true;
        }

        private void OnOutgoingBlock_GoingToMove(Direction direction)
        {
            SetOnlyTwoBannedOppositeDirections(direction);
            SetIncomingBlockForNextFloor?.Invoke(direction, _outgoingBlock);
            _outgoingBlock.GoingToMove -= OnOutgoingBlock_GoingToMove;
            _outgoingBlock.AchievedTarget += OnOutgoingBlock_AchievedTarget;
        }

        private void OnOutgoingBlock_AchievedTarget()
        {
            _processOutgoingBlock = true;
        }

        private bool MatchAllowedDirection(Direction incomingDirection)
        {
            foreach (FloorDirection direction in _floorDirections)
                if (direction.Value == incomingDirection)
                    return direction.Allowed;
            return false;
        }

        private void SetOnlyOneAllowedDirection(Direction direction)
        {
            foreach (FloorDirection dir in _floorDirections)
                dir.Allowed = dir.Value == direction;

            ChangedAllowedDirections?.Invoke(_floorDirections);
        }

        private void SetOnlyTwoBannedOppositeDirections(Direction direction)
        {
            _bannedDirection = direction.Abs().Perpendicular();

            foreach (FloorDirection dir in _floorDirections)
                if (dir.Value.Abs() == _bannedDirection)
                    dir.Allowed = false;

            ChangedAllowedDirections?.Invoke(_floorDirections);
        }

        private void AllowTwoOppositeDirections()
        {
            foreach (FloorDirection dir in _floorDirections)
                if (dir.Value.Abs() == _bannedDirection)
                    dir.Allowed = true;

            ChangedAllowedDirections?.Invoke(_floorDirections);
        }

        private void AllowAllFloorDirections()
        {
            foreach (FloorDirection direction in _floorDirections)
                direction.Allowed = true;
            ChangedAllowedDirections?.Invoke(_floorDirections);
        }

    }

    public class FloorDirection
    {
        public Direction Value { get; private set; }
        public bool Allowed { get; set; }

        public FloorDirection(Direction direction)
        {
            Value = direction;
            Allowed = true;
        }
    }
}

