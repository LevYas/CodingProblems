using CodingProblems.Sorting;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Sorting;

public class InversionCounter_CountInversions
{
    [Theory]
    [InlineData(new[] { 1, 1, 1, 2, 2 }, 0)]
    [InlineData(new[] { 2, 1, 3, 1, 2 }, 4)]
    public void Works(int[] arr, long expected)
    {
        InversionCounter.CountInversions(arr).Should().Be(expected);
    }
}