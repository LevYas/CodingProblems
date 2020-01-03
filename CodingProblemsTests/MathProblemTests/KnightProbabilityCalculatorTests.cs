using CodingProblems.MathProblems;
using Xunit;

namespace CodingProblemsTests.MathProblemTests
{
    public class KnightProbabilityCalculatorTests
    {
        [Theory]
        [InlineData(3, 2, 0, 0, 0.0625)]
        [InlineData(3, 3, 0, 0, 0.015625)]
        public void CalcsRightProbability(int chessboardSize, int movesAmount, int startRow, int startColumn, double expected)
        {
            Assert.Equal(expected, KnightProbabilityCalculator.CalcKnightProbability(chessboardSize, movesAmount, startRow, startColumn), 10);
        }
    }
}
