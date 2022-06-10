using System;
using CodingProblems.Graphs;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Graphs;

public class ValidPathFinder_Find
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Works(int n, int[][] edges, int source, int destination, bool expected)
    {
        bool result = new ValidPathFinder().Find(n, edges, source, destination);

        result.Should().Be(expected);
    }

    public static TheoryData<int, int[][], int, int, bool> Data
        => new()
        {
            {
                1,
                Array.Empty<int[]>(),
                0,
                0,
                true
            },
            {
                3,
                new[] { new[] { 0,1 }, new[] { 1,2 }, new[] { 2,0 } },
                0,
                2,
                true
            },
            {
                6,
                new[] { new[] { 0,1 }, new[] { 0,2 }, new[] { 3,5 }, new[] { 5,4 }, new[] { 4,3 } },
                0,
                5,
                false
            },
            {
                6,
                new[] { new[] { 0,1 }, new[] { 0,2 }, new[] { 3,5 }, new[] { 5,4 }, new[] { 4,3 } },
                1,
                2,
                true
            },
        };
}
