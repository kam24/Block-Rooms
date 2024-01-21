using System;
using UnityEngine;

namespace BlockRooms.Model
{
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()

    /// <summary>
    /// Ненулевое направление в одну из четырех сторон
    /// </summary>
    public sealed class Direction
    {
        public static Direction Up => new(Vector2.up * Config.CELL_DELTA);
        public static Direction Down => new(Vector2.down * Config.CELL_DELTA);
        public static Direction Left => new(Vector2.left * Config.CELL_DELTA);
        public static Direction Right => new(Vector2.right * Config.CELL_DELTA);
        public static Direction[] Directions => new Direction[] { Up, Down, Left, Right };

        public Vector2 Position { get; }

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
            return (vector1 ?? vector2) is null 
                || vector2 is not null && vector1.Position == vector2.Position;
        }

        public static bool operator !=(Direction vector1, Direction vector2)
        {
            return (vector1 ?? vector2) is not null 
                   && (vector2 is null || vector1.Position != vector2.Position);
        }

        /// <summary>
        /// Возвращает вектор с положительными значениями по осям x и y
        /// </summary>
        /// <param name="cellVector"></param>
        /// <returns></returns>
        public Direction Abs() => new(new Vector2(Math.Abs(Position.x), Math.Abs(Position.y)));

        /// <summary>
        /// Возвращает перпендикулярный вектор
        /// </summary>
        /// <param name="cellVector"></param>
        /// <returns></returns>
        public Direction Perpendicular() => new(new Vector2(Position.y, Position.x));

        /// <summary>
        /// Складывает левую часть с направлением и сравнивает с правой частью
        /// </summary>
        /// <param name="left">Левая часть</param>
        /// <param name="right">Правая часть</param>
        /// <param name="direction">Направление</param>
        /// <param name="precision">Точность</param>
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

#pragma warning restore CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
#pragma warning restore CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)