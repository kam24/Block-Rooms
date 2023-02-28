using System;

namespace BlockRooms.Model
{
    public interface IAttachable
    {
        bool Enabled { get; }
        bool IsAttached { get; }

        event Action Attached;
        event Action Detached;
        event Action BecomesNonAttachable;

        void SetAttached();
        void SetDetached();
    }
}
