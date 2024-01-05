using BlockRooms.Model.Units.Extensions.Interfaces;
using System;

namespace BlockRooms.Model.Units.Extensions
{
    public class AttachableExtension : IAttachable
    {
        public AttachableExtension() => IsAttached = false;

        public event Action Attached;
        public event Action Detached;
        public event Action BecomesNonAttachable;

        public bool IsAttached { get; private set; }

        public void SetNonAttachable() => BecomesNonAttachable?.Invoke();

        public void SetAttached()
        {
            IsAttached = true;
            Attached?.Invoke();
        }

        public void SetDetached()
        {
            IsAttached = false;
            Detached?.Invoke();
        }
    }
}
