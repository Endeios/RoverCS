using System.Collections.Generic;

namespace rover_lib
{
    public class Rover
    {
        private readonly IDictionary<Direction, Direction> leftRotation = new Dictionary<Direction, Direction>()
        {
            { Direction.North , Direction.West },
            { Direction.West , Direction.South },
            { Direction.South , Direction.Est },
            { Direction.Est , Direction.North }
        };
        private readonly IDictionary<Direction, Direction> rightRotation = new Dictionary<Direction, Direction>()
        {
            { Direction.North , Direction.Est },
            { Direction.Est , Direction.South },
            { Direction.South , Direction.West },
            { Direction.West, Direction.North }
        };
        Direction currentDirection = Direction.North;
        public Position go(string input)
        {
            if(string.IsNullOrEmpty(input))
                return new Position(0, 0, Direction.North);
            foreach (char command in input) {
                if(command=='L')
                    currentDirection = leftRotation[currentDirection];
                if(command == 'R')
                    currentDirection = rightRotation[currentDirection];
            }
            return new Position(0, 0, currentDirection);
        }
    }
}
