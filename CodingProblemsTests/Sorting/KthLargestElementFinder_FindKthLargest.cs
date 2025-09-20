using FluentAssertions.Execution;
using KthLargestElementFinder = CodingProblems.Sorting.KthLargestElementFinder;

namespace CodingProblemsTests.Sorting;

public class KthLargestElementFinder_FindKthLargest
{
    [Theory]
    [InlineData(new[] { 3 }, 1, 3)]
    [InlineData(new[] { -1, 2, 0 }, 1, 2)]
    [InlineData(new[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
    [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
    [InlineData(new[] { -3, -2, -1, -5, 6, 4 }, 3, -1)]
    [InlineData(new[] { 7, 6, 5, 4, 3, 2, 1 }, 5, 3)]
    public void Works(int[] nums, int k, int expected)
    {
        KthLargestElementFinder sut = new();

        int resultPq = sut.FindKthLargestViaPq(nums, k);
        int resultQs = sut.FindKthLargestViaQuickselect(nums, k);

        using var _ = new AssertionScope();
        resultPq.Should().Be(expected);
        resultQs.Should().Be(expected);
    }
}
