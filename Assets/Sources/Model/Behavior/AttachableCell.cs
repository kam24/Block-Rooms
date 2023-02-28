using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class AttachableCell : UpdatableCell, IAttachable
    {
        public event Action Attached;
        public event Action Detached;
        public event Action BecomesNonAttachable;

        public bool Enabled { get; private set; }
        public bool IsAttached { get; private set; }

        protected AttachableCell(Vector3 position) : base(position)
        {
            Enabled = false;
            IsAttached = false;
        }

        public void SetAttachable()
        {
            Enabled = true;
        }

        public void SetNonAttachable()
        {
            BecomesNonAttachable?.Invoke();
            Enabled = false;
        }

        public void SetAttached()
        {
            if (Enabled)
            {
                IsAttached = true;
                Attached?.Invoke();
            }
            else
                throw new InvalidOperationException();
        }

        public void SetDetached()
        {
            if (Enabled)
            {
                IsAttached = false;
                Detached?.Invoke();
            }
            else
                throw new InvalidOperationException();
        }
    }
}
