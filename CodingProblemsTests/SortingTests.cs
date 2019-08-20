using CodingProblems;
using Xunit;

namespace CodingProblemsTests
{
    public class SortingTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 1, 2, 2 }, 0)]
        [InlineData(new int[] { 2, 1, 3, 1, 2 }, 4)]
        public void CountInversionsTest(int[] arr, long expected)
        {
            Assert.Equal(expected, Sorting.CountInversions(arr));
        }
    }
}
