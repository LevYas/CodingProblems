using CodingProblems.Numbers;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class NegabinaryOperationsTests
    {
        [Theory]
        [InlineData(9, new[] { 1, 1, 0, 0, 1 })]
        [InlineData(-9, new[] { 1, 0, 1, 1 })]
        [InlineData(40, new[] { 1, 1, 1, 1, 0, 0, 0 })]
        public void ToNegabinaryTest(int number, int[] expected)
        {
            NegabinaryOperations.ToNegabinary(number).Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, 11)]
        [InlineData(new[] { 1, 0, 1 }, 5)]
        [InlineData(new[] { 1, 1, 0, 0, 1 }, 9)]
        [InlineData(new[] { 1, 0, 1, 1 }, -9)]
        [InlineData(new[] { 1, 1, 1, 1, 0, 0, 0 }, 40)]
        public void FromNegabinaryTest(int[] arr, int expected)
        {
            NegabinaryOperations.FromNegabinary(arr).Should().Be(expected);
        }

        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, new[] { 1, 0, 1 }, new[] { 1, 0, 0, 0, 0 })]
        public void AddNegabinarySimpleTest(int[] arr1, int[] arr2, int[] expected)
        {
            NegabinaryOperations.AddNegabinarySimple(arr1, arr2).Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
        [InlineData(new[] { 1, 1 }, new[] { 1 }, new[] { 0 })]
        [InlineData(new[] { 1 }, new[] { 1, 1, 0, 1 }, new[] { 1, 0 })]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, new[] { 1, 0, 1 }, new[] { 1, 0, 0, 0, 0 })]
        [InlineData(new[] { 1, 0, 1, 0, 1, 0, 1 }, new[] { 1, 1, 1, 0, 1, 0, 0 }, new[] { 1, 1, 0, 0, 1, 1, 0, 0, 1 })]
        public void AddNegabinaryTest(int[] arr1, int[] arr2, int[] expected)
        {
            NegabinaryOperations.AddNegabinary(arr1, arr2).Should().BeEquivalentTo(expected);
        }
    }
}
