using UnityEngine;

namespace BlockRooms.Model
{
    public class Floor : UpdatableCell
    {
        public Floor(Vector3 position) : base(position)
        {
            SetBehavior(new FloorBehavior());
        }
    }
}
