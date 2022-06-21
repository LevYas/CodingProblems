using CodingProblems.Graphs;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Graphs;

public class MaximumRoadImportanceCalculator_Calculate
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Works(int n, int[][] roads, long expected)
    {
        long result = new MaximumRoadImportanceCalculator().Calculate(n, roads);

        result.Should().Be(expected);
    }

    public static TheoryData<int, int[][], long> Data
        => new()
        {
            {
                2,
                new[] { new[] { 0, 1 } },
                3
            },
            {
                5,
                new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 0, 2 }, new[] { 1, 3 }, new[] { 2, 4 } },
                43
            },
            {
                5,
                new[] { new[] { 0, 3 }, new[] { 2, 4 }, new[] { 1, 3 } },
                20
            },
        };
}
