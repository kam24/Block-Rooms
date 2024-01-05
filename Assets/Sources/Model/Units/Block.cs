using UnityEngine;

namespace BlockRooms.Model
{
    public class Block : Unit
    {
        public Block(Vector3 position) : base(position)
        {
            SetBehavior(new BlockBehavior());
        }
    }
}
