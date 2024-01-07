using BlockRooms.Model.Units.Extensions.Interfaces;
using System;

namespace BlockRooms.Model.Units.Extensions
{
    public class AttachableExtension : IAttachable
    {
        public bool IsAttached { get; private set; }

        public event Action Attached;
        public event Action Detached;
        public event Action Disabled;

        public AttachableExtension() => IsAttached = false;

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

        public void Disable() => Disabled?.Invoke();
    }
}
