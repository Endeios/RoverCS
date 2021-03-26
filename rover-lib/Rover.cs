using System;

namespace rover_lib
{
    public class Rover
    {
        Direction currentDirection = Direction.North;
        public Position go(string input)
        {
            if(string.IsNullOrEmpty(input))
                return new Position(0, 0, Direction.North);
            foreach (char command in input) {
                if (currentDirection == Direction.Est)
                {
                    currentDirection = Direction.North;
                    continue;
                }
                if (currentDirection == Direction.South)
                {
                    currentDirection = Direction.Est;
                    continue;
                }
                if (currentDirection == Direction.West)
                {
                    currentDirection = Direction.South;
                    continue;
                }
                if (currentDirection == Direction.North)
                {
                    currentDirection = Direction.West;
                    continue;
                }
            }
            return new Position(0, 0, currentDirection);
        }
    }
}
