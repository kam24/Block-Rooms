using UnityEngine;

namespace BlockRooms.Model
{
    public class Player : UpdatableUnit
    {
        public Player(Vector3 position) : base(position)
        {
            SetBehavior(new PlayerMovement(this));
        }
    }
}
