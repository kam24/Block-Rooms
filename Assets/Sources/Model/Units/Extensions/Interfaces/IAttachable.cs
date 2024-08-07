﻿using System;

namespace BlockRooms.Model.Units.Extensions.Interfaces
{
    public interface IAttachable : IExtension
    {
        public bool IsAttached { get; }

        public event Action Attached;
        public event Action Detached;
        public event Action Disabled;

        public void SetAttached();

        public void SetDetached();

        public void Disable();
    }
}
