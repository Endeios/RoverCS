using System;

namespace rover_lib
{
    public class Rover
    {
        public Position go(string input)
        {
            return new Position(0, 0, Direction.West);
        }
    }
}
