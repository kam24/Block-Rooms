using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public static class VectorExtension
    {
        private const int MAX_FRAME_RATE = 500;
        private const float EPSILON = 1 / (float)MAX_FRAME_RATE;

        public static bool Equals(Vector2 vector1, Vector2 vector2)
        {
            float diffX = Math.Abs(vector1.x - vector2.x);
            float diffY = Math.Abs(vector1.y - vector2.y);

            bool xEquals = diffX <= EPSILON || diffX <= Math.Max(Math.Abs(vector1.x), Math.Abs(vector2.x)) * EPSILON;
            bool yEquals = diffY <= EPSILON || diffY <= Math.Max(Math.Abs(vector1.y), Math.Abs(vector2.y)) * EPSILON;

            return xEquals && yEquals;
        }
    }
}
