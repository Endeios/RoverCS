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
                if (command == 'L')
                    RotateLeft();
                if (command == 'R')
                    RotateRight();
                if (command == 'M')
                    moveForward();
            }
            return new Position(x, y, currentDirection);
        }

        private void moveForward()
        {
            if (RoverIsPointingEast())
                MoveEast();
            if (RoverIsPointingWest())
                MoveWest();
            if (RoverIsPointingNorth())
                MoveNorth();
            if (RoverIsPointingSouth())
                MoveSouth();
        }

        private void MoveSouth()
        {
            y = (y + 1) % worldHeight;
        }

        private bool RoverIsPointingSouth()
        {
            return currentDirection == Direction.South;
        }

        private void MoveNorth()
        {
            y--;
            if (y < 0) y = worldHeight - 1;
        }

        private bool RoverIsPointingNorth()
        {
            return currentDirection == Direction.North;
        }

        private void MoveWest()
        {
            x--;
            if (x < 0) x = worldWidth - 1;
        }

        private bool RoverIsPointingWest()
        {
            return currentDirection == Direction.West;
        }

        private void MoveEast()
        {
            x = (x + 1) % worldWidth;
        }

        private bool RoverIsPointingEast()
        {
            return currentDirection == Direction.Est;
        }

        private void RotateRight()
        {
            currentDirection = rightRotation[currentDirection];
        }

        private void RotateLeft()
        {
            currentDirection = leftRotation[currentDirection];
        }
    }
}
