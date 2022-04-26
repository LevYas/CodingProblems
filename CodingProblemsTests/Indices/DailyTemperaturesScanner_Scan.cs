using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class DailyTemperaturesScanner_Scan
{
    [Theory]
    [InlineData(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    [InlineData(new[] { 30, 40, 50, 60 }, new[] { 1, 1, 1, 0 })]
    [InlineData(new[] { 30, 60, 90 }, new[] { 1, 1, 0 })]
    public void Works(int[] temperatures, int[] expected)
    {
        int[] result = new DailyTemperaturesScanner().Scan(temperatures);

        result.Should().Equal(expected);
    }
}
