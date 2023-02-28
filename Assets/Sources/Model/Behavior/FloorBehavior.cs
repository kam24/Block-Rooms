using System;
using System.Collections.Generic;

namespace BlockRooms.Model
{
    public class FloorBehavior : IFloor, IUpdatable
    {
        public Cell.LayerPosition Layer => Cell.LayerPosition.Floor;

        public event Action<Direction, IMovable> SetIncomingBlockForNextFloor;
        public event Action<List<FloorDirection>> ChangedAllowedDirections;

        private List<FloorDirection> floorDirections = new(4);
        private Direction bannedDirection;

        private IMovable incomingBlock;
        private IMovable outgoingBlock;

        private bool processIncomingBlock = false;
        private bool processOutgoingBlock = false;

        public FloorBehavior()
        {
            foreach (var dir in Direction.Directions)
                floorDirections.Add(new FloorDirection(dir));
            ChangedAllowedDirections?.Invoke(floorDirections);
        }

        public bool IsAvailiable(Direction direction)
        {
            return MatchAllowedDirection(-direction);
        }

        public void SetIncomingBlock(IMovable block, Direction direction)
        {
            incomingBlock = block;
            SetOnlyOneAllowedDirection(-direction);
            incomingBlock.AchievedTarget += OnIncomingBlock_AchievedTarget;
        }

        public void SetOutgoingBlock(IMovable block)
        {
            outgoingBlock = block;
            outgoingBlock.GoingToMove += OnOutgoingBlock_GoingToMove;
        }

        public void Update(float deltaTime)
        {
            ProcessOutgoingBlock();
            ProcessIncomingBlock();
        }

        private void ProcessIncomingBlock()
        {
            if (processIncomingBlock)
            {
                AllowAllFloorDirections();
                SetOutgoingBlock(incomingBlock);
                incomingBlock.AchievedTarget -= OnIncomingBlock_AchievedTarget;
                incomingBlock = null;
                processIncomingBlock = false;
            }
        }

        private void ProcessOutgoingBlock()
        {
            if (processOutgoingBlock)
            {
                if (incomingBlock == null)
                    AllowTwoOppositeDirections();
                outgoingBlock.AchievedTarget -= OnOutgoingBlock_AchievedTarget;
                outgoingBlock = null;
                processOutgoingBlock = false;
            }
        }

        private void OnIncomingBlock_AchievedTarget()
        {
            processIncomingBlock = true;
        }

        private void OnOutgoingBlock_GoingToMove(Direction direction)
        {
            SetOnlyTwoBannedOppositeDirections(direction);
            SetIncomingBlockForNextFloor?.Invoke(direction, outgoingBlock);
            outgoingBlock.GoingToMove -= OnOutgoingBlock_GoingToMove;
            outgoingBlock.AchievedTarget += OnOutgoingBlock_AchievedTarget;
        }

        private void OnOutgoingBlock_AchievedTarget()
        {
            processOutgoingBlock = true;
        }

        private bool MatchAllowedDirection(Direction incomingDirection)
        {
            foreach (var direction in floorDirections)
                if (direction.Value == incomingDirection)
                    return direction.Allowed;
            return false;
        }

        private void SetOnlyOneAllowedDirection(Direction direction)
        {
            foreach (var dir in floorDirections)
                dir.Allowed = dir.Value == direction;

            ChangedAllowedDirections?.Invoke(floorDirections);
        }

        private void SetOnlyTwoBannedOppositeDirections(Direction direction)
        {
            bannedDirection = direction.Abs().Perpendicular();

            foreach (var dir in floorDirections)
                if (dir.Value.Abs() == bannedDirection)
                    dir.Allowed = false;

            ChangedAllowedDirections?.Invoke(floorDirections);
        }

        private void AllowTwoOppositeDirections()
        {
            foreach (var dir in floorDirections)
                if (dir.Value.Abs() == bannedDirection)
                    dir.Allowed = true;

            ChangedAllowedDirections?.Invoke(floorDirections);
        }

        private void AllowAllFloorDirections()
        {
            foreach (var direction in floorDirections)
                direction.Allowed = true;
            ChangedAllowedDirections?.Invoke(floorDirections);
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

