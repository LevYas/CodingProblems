using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices
{
    public class ClimbingStairsSolver_ClimbStairs
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        public void Works(int height, int expected)
        {
            ClimbingStairsSolver.ClimbStairs(height).Should().Be(expected);
        }
    }
}
