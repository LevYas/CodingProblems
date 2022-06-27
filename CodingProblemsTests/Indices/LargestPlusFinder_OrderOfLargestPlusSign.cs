using CodingProblems.Indices;
using FluentAssertions;
using System;
using Xunit;

namespace CodingProblemsTests.Indices;

public class LargestPlusFinder_OrderOfLargestPlusSign
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int n, int[][] mines, int expected)
    {
        int result = new LargestPlusFinder().OrderOfLargestPlusSign(n, mines);

        result.Should().Be(expected);
    }

    public static TheoryData<int, int[][], int> TestData
        => new()
        {
            {
                1,
                new[] { new[] { 0, 0 } },
                0
            },
            {
                1,
                Array.Empty<int[]>(),
                1
            },
            {
                5,
                new[] { new[] { 4, 2 } },
                2
            },
        };
}
