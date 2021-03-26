using System;

namespace rover_lib
{
    public class Rover
    {
        public Position go(string input)
        {
            if(string.IsNullOrEmpty(input))
                return new Position(0, 0, Direction.North);
            return new Position(0, 0, Direction.West);
        }
    }
}
