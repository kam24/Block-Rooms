﻿using BlockRooms.Model.Units.Extensions;
using BlockRooms.Model.Units.Extensions.Interfaces;
using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public abstract class Unit : Transformable
    {
        public IUnitBehavior Behavior { get; private set; }
        public Extensions Extensions { get; private set; }

        public event Action<IUnitBehavior> BehaviorChanged;

        public Unit(Vector3 position) : base(position)
        {
            Extensions = new Extensions();
        }

        public Unit(Vector3 position, IUnitBehavior cellBehavior) : this(position)
        {
            Behavior = cellBehavior;
        }

        public void SetLayer(UnitLayer layer)
        {
            var newPosition = new Vector3(Position.x, Position.y, (float)layer);
            SetPosition(newPosition);
        }

        protected virtual void SetBehavior(IUnitBehavior behavior)
        {
            Behavior = behavior;
            SetLayer(behavior.Layer);
            BehaviorChanged?.Invoke(Behavior);
        }
    }
}
