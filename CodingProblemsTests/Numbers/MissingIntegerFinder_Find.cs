using CodingProblems.Numbers;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class MissingIntegerFinder_Find
    {
        [Theory]
        [InlineData(new[] { 1 }, 2)]
        [InlineData(new[] { 0 }, 1)]
        [InlineData(new[] { 10, 30 }, 1)]
        [InlineData(new[] { 1, 3, 6, 4, 1, 2 }, 5)]
        [InlineData(new[] { 1, 2, 3 }, 4)]
        [InlineData(new[] { -1, -3 }, 1)]
        public void FindsCorrectValues(int[] arr, int expected)
        {
            MissingIntegerFinder.Find(arr).Should().Be(expected);
        }

        [Fact]
        public void WorksOnBigArray()
        {
            const int size = 100000;
            int[] large = new int[size];

            for (int i = 0; i < size; i++)
                large[i] = i;

            MissingIntegerFinder.Find(large).Should().Be(size);
        }
    }
}
