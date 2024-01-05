using UnityEngine;

namespace BlockRooms.Model
{
    public class Ball : UpdatableUnit
    {
        public Ball(Vector3 position) : base(position)
        {
            SetBehavior(new BallMovement(this));
        }
    }
}
