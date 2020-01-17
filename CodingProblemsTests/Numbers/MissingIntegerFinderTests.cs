using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class MissingIntegerFinderTests
    {
        [Theory]
        [InlineData(new int[] { 1 }, 2)]
        [InlineData(new int[] { 0 }, 1)]
        [InlineData(new int[] { 10, 30 }, 1)]
        [InlineData(new int[] { 1, 3, 6, 4, 1, 2 }, 5)]
        [InlineData(new int[] { 1, 2, 3 }, 4)]
        [InlineData(new int[] { -1, -3 }, 1)]
        public void FindsCorrectValues(int[] arr, int expected)
        {
            Assert.Equal(expected, MissingIntegerFinder.Find(arr));
        }

        [Fact]
        public void WorksOnBigArray()
        {
            const int size = 100000;
            int[] large = new int[size];

            for (int i = 0; i < size; i++)
                large[i] = i;

            Assert.Equal(size, MissingIntegerFinder.Find(large));
        }
    }
}
