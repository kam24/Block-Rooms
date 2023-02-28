using UnityEngine;

namespace BlockRooms.Model
{
    public class PlayerBall : UpdatableCell
    {
        public PlayerBall(Vector3 position) : base(position)
        {
            SetBehavior(new PlayerMovement(this));
        }
    }
}
