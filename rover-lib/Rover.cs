using System;
using System.Collections.Generic;

namespace rover_lib
{
    public class Rover
    {
        int worldWidth;
        int worldHeight;

        public Rover(int worldWidth = 10, int worldHeight = 10)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            advance = new Dictionary<Direction, Action>()
            {
                { Direction.Est, MoveEast },
                { Direction.West, MoveWest },
                { Direction.North, MoveNorth },
                { Direction.South, MoveSouth }
            };
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

        private readonly IDictionary<Direction, Action> advance;

        Direction currentDirection = Direction.North;
        int x = 0;
        int y = 0;
        public Position go(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new Position(0, 0, Direction.North);
            foreach (char command in input)
            {
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
            advance[this.currentDirection]();
        }

        private void MoveSouth()
        {
            y = (y + 1) % worldHeight;
        }

        private void MoveNorth()
        {
            y--;
            if (y < 0) y = worldHeight - 1;
        }

        private void MoveWest()
        {
            x--;
            if (x < 0) x = worldWidth - 1;
        }

        private void MoveEast()
        {
            x = (x + 1) % worldWidth;
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
