using CodingProblems.Indices;
using Xunit;

namespace CodingProblemsTests.Indices
{
    public class TrappedWaterCalculator_CalcTrappedWaterAmount
    {
        [Theory]
        [InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [InlineData(new[] { 0, 1, 2, 3, 4, 3, 2, 1, 0, }, 0)]
        [InlineData(new[] { 2, 0, 0, 0, 2 }, 6)]
        [InlineData(new[] { 3, 0, 0, 0, 2 }, 6)]
        [InlineData(new[] { 0, 0, 0, 0, 5 }, 0)]
        [InlineData(new[] { 5, 4, 3, 2, 3, 4, 5 }, 9)]
        public void Works(int[] arr, int expected)
        {
            Assert.Equal(expected, TrappedWaterCalculator.CalcTrappedWaterAmountUsingDP(arr));
            Assert.Equal(expected, TrappedWaterCalculator.CalcTrappedWaterAmountUsingStack(arr));
            Assert.Equal(expected, TrappedWaterCalculator.CalcTrappedWaterAmountUsingTwoPointers(arr));
        }
    }
}
