using CodingProblems.MathProblems;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.MathProblems;

public class SeatAssignmentProbabilityCalculator_LastPersonGetsOwnSeat
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 0.5)]
    [InlineData(3, 0.5)]
    [InlineData(4, 0.5)]
    public void Works(int n, double expected)
    {
        new SeatAssignmentProbabilityCalculator().LastPersonGetsOwnSeat(n).Should().Be(expected);
    }
}
