using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class RotatedSortedArrayScanner_Search
{
    [Theory]
    [InlineData(new[] { 1 }, 0, -1)]
    [InlineData(new[] { 1 }, 1, 0)]
    [InlineData(new[] { 1, 3 }, 3, 1)]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 5, 1)]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 1, 5)]
    [InlineData(new[] { 7, 8, 1, 2, 3, 4, 5, 6 }, 2, 3)]
    [InlineData(new[] { 0, 1, 2, 4, 5, 6 }, 3, -1)]
    [InlineData(new[] { 0, 1, 2, 4, 5, 6 }, 5, 4)]
    public void Works(int[] nums, int target, int expected)
    {
        int result = new RotatedSortedArrayScanner().Search(nums, target);

        result.Should().Be(expected);
    }
}
