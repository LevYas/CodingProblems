using CodingProblems.MathProblems;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.MathProblems;

public class SeatAssignmentProbabilityCalculator_LastPersonGetsOwnSeat
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Works(int n)
    {
        new SeatAssignmentProbabilityCalculator().LastPersonGetsOwnSeat(n).Should().Be(0.5);
    }
}
