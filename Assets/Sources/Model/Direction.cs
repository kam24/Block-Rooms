using System;
using UnityEngine;

namespace BlockRooms.Model
{
    public sealed class Direction
    {
        private static readonly Direction upVector = new(Vector2.up * Config.CellDelta);
        private static readonly Direction downVector = new(Vector2.down * Config.CellDelta);
        private static readonly Direction leftVector = new(Vector2.left * Config.CellDelta);
        private static readonly Direction rightVector = new(Vector2.right * Config.CellDelta);
        private static readonly Direction[] directions = new Direction[] { upVector, downVector, leftVector, rightVector };

        public static Direction Up => upVector;
        public static Direction Down => downVector;
        public static Direction Left => leftVector;
        public static Direction Right => rightVector;
        public static Direction[] Directions => directions;

        public enum Angle
        {
            Up = 0,
            Down = 180,
            Left = 90,
            Right = 270
        }

        public enum OperationType
        {
            Equals,
            LessThan,
            MoreThan
        }

        public Vector2 Position { get; }

        private Direction(Vector2 position)
        {
            Position = position;
        }

        public static Direction operator -(Direction vector)
        {
            return new Direction(-vector.Position);
        }

        public static bool operator ==(Direction vector1, Direction vector2)
        {
            return vector1.Position == vector2.Position;
        }

        public static bool operator !=(Direction vector1, Direction vector2)
        {
            return vector1.Position != vector2.Position;
        }

        /// <summary>
        /// Возвращает вектор с положительными значениями по осям x и y
        /// </summary>
        /// <param name="cellVector"></param>
        /// <returns></returns>
        public Direction Abs()
        {
            return new(new Vector2(Math.Abs(Position.x), Math.Abs(Position.y)));
        }

        /// <summary>
        /// Возвращает перпендикулярный вектор
        /// </summary>
        /// <param name="cellVector"></param>
        /// <returns></returns>
        public Direction Perpendicular()
        {
            return new(new Vector2(Position.y, Position.x));
        }

        /// <summary>
        /// Складывает левую часть с направлением и сравнивает с правой частью
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="direction"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static bool Compare(Vector2 left, Vector2 right, Direction direction, OperationType operation, int precision = 1)
        {
            int k = (int)Math.Pow(10, precision);

            int x1 = (int)Math.Round(left.x * k);
            int y1 = (int)Math.Round(left.y * k);

            int x2 = (int)Math.Round(right.x * k);
            int y2 = (int)Math.Round(right.y * k);

            int dX = (int)Math.Round(direction.Position.x * k);
            int dY = (int)Math.Round(direction.Position.y * k);

            return operation switch
            {
                OperationType.Equals => x1 + dX == x2 && y1 + dY == y2,
                OperationType.LessThan => x1 + dX < x2 || y1 + dY < y2,
                OperationType.MoreThan => x1 + dX > x2 || y1 + dY > y2,
                _ => throw new NotImplementedException()
            };
        }
    }
}
