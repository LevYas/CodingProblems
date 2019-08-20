using CodingProblems;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace CodingProblemsTests
{
    public class ArraysTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 1 }, 2, 2)]
        [InlineData(new int[] { 1, 2, 3, 5, 0, 10, -5 }, 5, 5)]
        public void SubarraySumTest(int[] arr, int k, int expected)
        {
            Assert.Equal(expected, Arrays.CalcSubarraysAmount(arr, k));
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 5, 3, 4 }, "3")]
        [InlineData(new int[] { 2, 1, 5, 4, 3 }, "4")]
        [InlineData(new int[] { 2, 5, 1, 3, 4 }, "Too chaotic")]
        [InlineData(new int[] { 2, 1, 5, 4 }, "Too chaotic")]
        public void MinimumBribesTest(int[] a, string expected)
        {
            var content = new StringBuilder();
            var writer = new StringWriter(content);

            Arrays.CalcMinimumBribesAmount(writer, a);

            var actualOutput = content.ToString().Replace(Environment.NewLine, "");
            Assert.Equal(expected, actualOutput);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 3, 4, 5, 1, 2 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5, 1, 2, 3, 4 })]
        public void RotLeftTest(int[] a, int d, int[] expected)
        {
            Assert.Equal(expected, Arrays.RotateLeft(a, d));
        }

        [Theory]
        [MemberData(nameof(ArrForHourglassSum))]
        public void HourglassSumTest(int[][] arr, int expected)
        {
            Assert.Equal(expected, Arrays.CalcMaxHourglassSum(arr));
        }

        public static TheoryData<int[][], int> ArrForHourglassSum
        {
            get => new TheoryData<int[][], int>
                {
                    {
                        new int[][] { new int[] { 1, 1, 1, 0, 0, 0 },
                                      new int[] { 0, 1, 0, 0, 0, 0 },
                                      new int[] { 1, 1, 1, 0, 0, 0 },
                                      new int[] { 0, 0, 2, 4, 4, 0 },
                                      new int[] { 0, 0, 0, 2, 0, 0 },
                                      new int[] { 0, 0, 1, 2, 4, 0 } },
                        19
                    }
                };
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 3, 2, 1, 0, }, 0)]
        [InlineData(new int[] { 2, 0, 0, 0, 2 }, 6)]
        [InlineData(new int[] { 3, 0, 0, 0, 2 }, 6)]
        [InlineData(new int[] { 0, 0, 0, 0, 5 }, 0)]
        [InlineData(new int[] { 5, 4, 3, 2, 3, 4, 5 }, 9)]
        public void WaterTrapTest(int[] arr, int expected)
        {
            Assert.Equal(expected, Arrays.CalcTrappedWaterAmountUsingDP(arr));
            Assert.Equal(expected, Arrays.CalcTrappedWaterAmountUsingStack(arr));
            Assert.Equal(expected, Arrays.CalcTrappedWaterAmountUsingTwoPointers(arr));
        }

        [Theory]
        [InlineData(new int[] { 2, -2, 3, 0, 4, -7 }, 4)]
        [InlineData(new int[] { 0, 0, 0 }, 6)]
        public void ArrayZeroFragmentsTest(int[] arr, int expected)
        {
            Assert.Equal(expected, Arrays.CalcZeroFragmentsCount(arr));
        }
    }
}
