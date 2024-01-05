using System;
using System.Collections.Generic;

namespace BlockRooms.Model
{
    public interface IFloor : IUnitBehavior
    {
        event Action<Direction, IMovable> SetIncomingBlockForNextFloor;
        event Action<List<FloorDirection>> ChangedAllowedDirections;

        bool IsAvailiable(Direction direction);
        void SetIncomingBlock(IMovable block, Direction direction);
        void SetOutgoingBlock(IMovable block);
    }
}
