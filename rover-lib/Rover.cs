using System.Collections.Generic;

namespace rover_lib
{
    public class Rover
    {
        private IDictionary<Direction, Direction> leftRotation = new Dictionary<Direction, Direction>()
        {
            { Direction.North , Direction.West },
            { Direction.West , Direction.South },
            { Direction.South , Direction.Est },
            { Direction.Est , Direction.North }
        };
        Direction currentDirection = Direction.North;
        public Position go(string input)
        {
            if(string.IsNullOrEmpty(input))
                return new Position(0, 0, Direction.North);
            foreach (char command in input) {
                currentDirection = leftRotation[currentDirection];
            }
            return new Position(0, 0, currentDirection);
        }
    }
}
