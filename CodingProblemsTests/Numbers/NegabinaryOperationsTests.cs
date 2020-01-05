using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class NegabinaryOperationsTests
    {
        [Theory]
        [InlineData(9, new int[] { 1, 1, 0, 0, 1 })]
        [InlineData(-9, new int[] { 1, 0, 1, 1 })]
        [InlineData(40, new int[] { 1, 1, 1, 1, 0, 0, 0 })]
        public void ToNegabinaryTest(int number, int[] expected)
        {
            Assert.Equal(expected, NegabinaryOperations.ToNegabinary(number));
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, 11)]
        [InlineData(new int[] { 1, 0, 1 }, 5)]
        [InlineData(new int[] { 1, 1, 0, 0, 1 }, 9)]
        [InlineData(new int[] { 1, 0, 1, 1 }, -9)]
        [InlineData(new int[] { 1, 1, 1, 1, 0, 0, 0 }, 40)]
        public void FromNegabinaryTest(int[] arr, int expected)
        {
            Assert.Equal(expected, NegabinaryOperations.FromNegabinary(arr));
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 0, 0, 0, 0 })]
        public void AddNegabinarySimpleTest(int[] arr1, int[] arr2, int[] expected)
        {
            Assert.Equal(expected, NegabinaryOperations.AddNegabinarySimple(arr1, arr2));
        }

        [Theory]
        [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 1, 1 }, new int[] { 1 }, new int[] { 0 })]
        [InlineData(new int[] { 1 }, new int[] { 1, 1, 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 0, 0, 0, 0 })]
        [InlineData(new int[] { 1, 0, 1, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 0, 1, 0, 0 }, new int[] { 1, 1, 0, 0, 1, 1, 0, 0, 1 })]
        public void AddNegabinaryTest(int[] arr1, int[] arr2, int[] expected)
        {
            Assert.Equal(expected, NegabinaryOperations.AddNegabinary(arr1, arr2));
        }
    }
}
