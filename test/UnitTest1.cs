using FluentAssertions;
using NUnit.Framework;
using rover_lib;

namespace test
{
    public class Tests
    {
        private Rover rover;

        [SetUp]
        public void Setup()
        {
            rover = new Rover();
        }

        [TestCase("L", 0, 0, Direction.West)]
        public void Test1(string input, int x, int y, Direction direction)
        {
            Position expectedOutput = new Position(x, y, direction);
            Position retVal = rover.go(input);

            retVal.Should().Be(expectedOutput);
        }
    }
}