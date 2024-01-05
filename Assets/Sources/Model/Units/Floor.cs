using UnityEngine;

namespace BlockRooms.Model
{
    public class Floor : UpdatableUnit
    {
        public Floor(Vector3 position) : base(position)
        {
            SetBehavior(new FloorBehavior());
        }
    }
}
