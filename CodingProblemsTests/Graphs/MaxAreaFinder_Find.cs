using CodingProblems.Graphs;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Graphs;

public class MaxAreaFinder_Find
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Finds(int[][] grid, int expected)
    {
        MaxAreaFinder.Find(grid)
            .Should().Be(expected);
    }

    public static TheoryData<int[][], int> Data
        => new()
        {
            {
                new[] { new[] { 0, 0, 0, 0, 0, 0, 0, 0 } },
                0
            },
            {
                new[]
                {
                    new[] { 0,0,1,0,0,0,0,1,0,0,0,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,1,1,0,0,0 },
                    new[] { 0,1,1,0,1,0,0,0,0,0,0,0,0 },
                    new[] { 0,1,0,0,1,1,0,0,1,0,1,0,0 },
                    new[] { 0,1,0,0,1,1,0,0,1,1,1,0,0 },
                    new[] { 0,0,0,0,0,0,0,0,0,0,1,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,1,1,0,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,1,0,0,0,0 },
                },
                6
            },
            {
                new[]
                {
                    new[] { 0,0,1,0,0,0,0,1,0,0,0,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,1,1,0,0,0 },
                    new[] { 0,1,1,0,1,0,0,0,0,0,0,0,0 },
                    new[] { 0,1,0,0,1,1,0,0,1,0,1,0,0 },
                    new[] { 0,1,0,0,1,1,0,0,1,1,1,0,0 },
                    new[] { 0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,1,1,0,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,1,0,0,0,0 },
                },
                5
            },
            {
                new[]
                {
                    new[] { 0,0,1,0,0,0,0,1,0,0,0,0,0 },
                    new[] { 0,0,0,0,0,0,0,1,0,1,0,0,0 },
                    new[] { 0,1,1,0,1,0,0,0,0,0,0,0,0 },
                },
                2
            },
            {
                new[]
                {
                    new[] { 0,0,1,0,0,0,0,1,0,0,0,0,0 },
                },
                1
            },
        };
}