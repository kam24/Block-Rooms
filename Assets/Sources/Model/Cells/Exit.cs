using UnityEngine;

namespace BlockRooms.Model
{
    public class Exit : TransformableCell
    {
        public Exit(Vector3 position) : base(position)
        {
            SetBehavior(new FlooringBehavior());
        }
    }
}
