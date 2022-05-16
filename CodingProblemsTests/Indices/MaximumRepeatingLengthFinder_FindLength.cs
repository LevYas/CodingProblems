using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class MaximumRepeatingLengthFinder_FindLength
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 2, 1 }, new[] { 3, 2, 1, 4, 7 }, 3)]
    [InlineData(new[] { 3, 2, 1, 4, 7 }, new[] { 1, 2, 3, 2, 1 }, 3)]
    [InlineData(new[] { 0, 0, 0, 0, 0 }, new[] { 0, 0, 0, 0, 0 }, 5)]
    [InlineData(new[] { 0, 0, 0, 1, 0 }, new[] { 0, 1, 0, 0, 0 }, 3)]
    [InlineData(new[] { 0, 1, 0, 0, 0 }, new[] { 0, 0, 0, 1, 0 }, 3)]
    [InlineData(new[] { 1, 0, 1, 0, 0, 0, 0, 0, 1, 1 }, new[] { 1, 1, 0, 1, 1, 0, 0, 0, 0, 0 }, 6)]
    [InlineData(new[] { 3 }, new[] { 3 }, 1)]
    [InlineData(new[] { 3 }, new[] { 4 }, 0)]
    public void Works(int[] nums1, int[] nums2, int expected)
    {
        int result = new MaximumRepeatingLengthFinder().FindLength(nums1, nums2);

        result.Should().Be(expected);
    }

    [Fact]
    public void WorksOnBigData()
    {
        int[] zeroes = new int[10000];

        int result = new MaximumRepeatingLengthFinder().FindLength(zeroes, zeroes);

        result.Should().Be(10000);
    }
}
