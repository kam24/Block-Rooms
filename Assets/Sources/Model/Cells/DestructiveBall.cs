using UnityEngine;

namespace BlockRooms.Model
{
    public class DestructiveBall : Ball
    {
        public DestructiveBall(Vector3 position) : base(position)
        {
            SetBehavior(new BallMovement(this));
        }
    }
}
