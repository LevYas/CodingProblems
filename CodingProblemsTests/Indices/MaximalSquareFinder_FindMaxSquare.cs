using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class MaximalSquareFinder_FindMaxSquare
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(char[][] matrix, int expected)
    {
        int result = new MaximalSquareFinder().FindMaxSquare(matrix);

        result.Should().Be(expected);
    }

    public static TheoryData<char[][], int> TestData
        => new()
        {
            {
                new[]
                {
                    new[] { '1', '1' },
                    new[] { '1', '1' },
                },
                4
            },
            {
                new[]
                {
                    new[] { '1', '0' },
                    new[] { '1', '1' },
                },
                1
            },
            {
                new[]
                {
                    new[] { '1' },
                },
                1
            },
            {
                new[]
                {
                    new[] { '0' },
                },
                0
            },
            {
                new[]
                {
                    new[] { '1', '0', '1', '0', '0' },
                    new[] { '1', '0', '1', '1', '1' },
                    new[] { '1', '1', '1', '1', '1' },
                    new[] { '1', '0', '0', '1', '0' },
                },
                4
            },
            {
                new[]
                {
                    new[] { '1', '1', '1', '1', '1' },
                    new[] { '1', '1', '1', '1', '1' },
                    new[] { '1', '1', '1', '1', '1' },
                    new[] { '1', '1', '1', '1', '1' },
                },
                16
            },
            {
                new[]
                {
                    new[] { '1', '1', '1', '1', '0' },
                    new[] { '1', '1', '1', '1', '0' },
                    new[] { '1', '1', '1', '1', '1' },
                    new[] { '1', '1', '1', '1', '1' },
                    new[] { '0', '0', '1', '1', '1' },
                },
                16
            },

        };
}
