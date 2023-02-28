using UnityEngine;

namespace BlockRooms.Model
{
    public class Ball : AttachableCell
    {
        public Ball(Vector3 position) : base(position)
        {
            SetBehavior(new BallMovement(this));
        }
    }
}
