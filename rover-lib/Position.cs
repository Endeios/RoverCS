using System;

namespace rover_lib
{
    public class Position
    {
        private readonly int x;
        private readonly int y;
        private readonly Direction direction;

        public Position(int x, int y, Direction direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public Direction Direction => direction;

        public int Y => y;

        public int X => x;

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   x == position.x &&
                   y == position.y &&
                   direction == position.direction;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, direction);
        }

        public override string ToString()
        {
            return $"{X},{Y},{direction}";
        }
    }
}