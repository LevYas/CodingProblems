using CodingProblems.MathProblems;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.MathProblems
{
    public class KnightProbabilityCalculator_CalcKnightProbability
    {
        [Theory]
        [InlineData(3, 2, 0, 0, 0.0625)]
        [InlineData(3, 3, 0, 0, 0.015625)]
        public void Calcs(int chessboardSize, int movesAmount, int startRow, int startColumn, double expected)
        {
            KnightProbabilityCalculator.CalcKnightProbability(chessboardSize, movesAmount, startRow, startColumn)
                .Should()
                .BeApproximately(expected, 10);
        }
    }
}
