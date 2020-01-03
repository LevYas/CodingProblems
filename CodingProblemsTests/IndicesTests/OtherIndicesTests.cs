using CodingProblems.Indices;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace CodingProblemsTests.IndicesTests
{
    public class OtherIndicesTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 1 }, 2, 2)]
        [InlineData(new int[] { 1, 2, 3, 5, 0, 10, -5 }, 5, 5)]
        public void CalculatesSubarraySum(int[] arr, int k, int expected)
        {
            Assert.Equal(expected, OtherIndicesProblems.CalcSubarraysAmount(arr, k));
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 5, 3, 4 }, "3")]
        [InlineData(new int[] { 2, 1, 5, 4, 3 }, "4")]
        [InlineData(new int[] { 2, 5, 1, 3, 4 }, "Too chaotic")]
        [InlineData(new int[] { 2, 1, 5, 4 }, "Too chaotic")]
        public void CalculatesMinimumBribesAmount(int[] a, string expected)
        {
            var content = new StringBuilder();
            var writer = new StringWriter(content);

            OtherIndicesProblems.CalcMinimumBribesAmount(writer, a);

            var actualOutput = content.ToString().Replace(Environment.NewLine, "");
            Assert.Equal(expected, actualOutput);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 3, 4, 5, 1, 2 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5, 1, 2, 3, 4 })]
        public void RotatesLeft(int[] a, int d, int[] expected)
        {
            Assert.Equal(expected, OtherIndicesProblems.RotateLeft(a, d));
        }

        [Theory]
        [MemberData(nameof(HourglassSumTestData))]
        public void CalculatesHourglassSum(int[][] arr, int expected)
        {
            Assert.Equal(expected, OtherIndicesProblems.CalcMaxHourglassSum(arr));
        }

        public static TheoryData<int[][], int> HourglassSumTestData
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
        [InlineData(new int[] { 2, -2, 3, 0, 4, -7 }, 4)]
        [InlineData(new int[] { 0, 0, 0 }, 6)]
        public void CalculatesArrayZeroFragmentsCount(int[] arr, int expected)
        {
            Assert.Equal(expected, OtherIndicesProblems.CalcZeroFragmentsCount(arr));
        }

        [Theory]
        [InlineData("abcdefg", 1, "abcdefg")]
        [InlineData("b", 1, "b")]
        [InlineData("b", 3, "b")]
        [InlineData("abcdefg", 2, "bacdfeg")]
        [InlineData("abcdefgh", 3, "cbadefhg")]
        [InlineData("abcdefghi", 3, "cbadefihg")]
        [InlineData("abcde", 3, "cbade")]
        public void ReversesString(string s, int k, string expected)
        {
            Assert.Equal(expected, OtherIndicesProblems.ReverseString(s, k));
        }
    }
}
