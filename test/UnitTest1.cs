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

        [TestCase("", 0, 0, Direction.North)]
        [TestCase("L", 0, 0, Direction.West)]
        [TestCase("LL", 0, 0, Direction.South)]
        [TestCase("LLL", 0, 0, Direction.Est)]
        [TestCase("LLLL", 0, 0, Direction.North)]
        [TestCase("LLLLLLLL", 0, 0, Direction.North)]
        [TestCase("LLLLLLL", 0, 0, Direction.Est)]
        [TestCase("R", 0, 0, Direction.Est)]
        [TestCase("RR", 0, 0, Direction.South)]
        [TestCase("RRR", 0, 0, Direction.West)]
        [TestCase("RRRR", 0, 0, Direction.North)]
        [TestCase("RRRRR", 0, 0, Direction.Est)]
        [TestCase("RM", 1, 0, Direction.Est)]
        [TestCase("RMMMMMMMMM", 9, 0, Direction.Est)]
        [TestCase("RMMMMMMMMMM", 0, 0, Direction.Est)]
        [TestCase("LM", 9, 0, Direction.West)]
        [TestCase("LMMMMMMMMMM", 0, 0, Direction.West)]
        [TestCase("LMMMMMMMMMMM", 9, 0, Direction.West)]
        [TestCase("M", 0, 9, Direction.North)]
        [TestCase("MMMMMMMMMM", 0, 0, Direction.North)]
        [TestCase("MMMMMMMMMMM", 0, 9, Direction.North)]
        [TestCase("RRM", 0, 1, Direction.South)]
        [TestCase("RRMMMMMMMMMM", 0, 0, Direction.South)]
        public void TestGoTo(string input, int x, int y, Direction direction)
        {
            Position expectedOutput = new Position(x, y, direction);
            Position retVal = rover.go(input);

            retVal.Should().Be(expectedOutput);
        }
    }
}

