using System.Collections.Generic;

namespace rover_lib
{
    public class Rover
    {
        int worldWidth;
        int worldHeight;

        public Rover(int worldWidth=10, int worldHeight=10)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
        }

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
        int x = 0;
        int y = 0;
        public Position go(string input)
        {
            if(string.IsNullOrEmpty(input))
                return new Position(0, 0, Direction.North);
            foreach (char command in input) {
                if(command=='L')
                    currentDirection = leftRotation[currentDirection];
                if(command == 'R')
                    currentDirection = rightRotation[currentDirection];
                if (command == 'M')
                {
                    if(currentDirection==Direction.Est)
                        x = (x + 1)%worldWidth;
                    if (currentDirection == Direction.West)
                    {
                        x--;
                        if (x < 0) x = worldWidth - 1;
                    }
                    if(currentDirection == Direction.North)
                    {
                        y--;
                        if (y < 0) y = worldHeight - 1;
                    }
                    if(currentDirection==Direction.South)
                        y = (y + 1)%worldHeight;
                    
                }
            }
            return new Position(x, y, currentDirection);
        }
    }
}
