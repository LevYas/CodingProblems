using CodingProblems.Other;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class KthLargestElementFinder_Add
    {
        [Theory]
        [InlineData(1, new[] {1, 2, 3}, new[] {1, 3}, new[] {4, 4}, new[] {5, 5}, new[] {2, 5})]
        [InlineData(3, new[] {1, 2, 3}, new[] {1, 1}, new[] {4, 2}, new[] {5, 3}, new[] {2, 3})]
        [InlineData(2, new[] {-2, -3}, new[] {-4, -3}, new[] {-1, -2})]
        [InlineData(7, new[] {1, 2, 3, 6, 8, 12, 13}, new[] {1, 1}, new[] {4, 2}, new[] {20, 3})]
        [InlineData(1, new int[0], new[] {2, 2}, new[] {1, 2})]
        public void Works(int k, int[] initial, params int[][] adds)
        {
            var sut = new KthLargestElementFinder(k, initial);

            foreach (int[] toAdd in adds)
                sut.Add(toAdd[0]).Should().Be(toAdd[1]);
        }
    }
}
