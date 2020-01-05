using CodingProblems.Indices;
using Xunit;

namespace CodingProblemsTests.Indices
{
    public class ClimbingStairsSolverTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        public void ClimbStairsWorks(int height, int expected)
        {
            Assert.Equal(expected, ClimbingStairsSolver.ClimbStairs(height));
        }
    }
}
