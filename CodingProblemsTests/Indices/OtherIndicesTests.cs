using CodingProblems.Indices;
using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices
{
    public class OtherIndicesTests
    {
        [Theory]
        [InlineData(new[] { 1, 1, 1 }, 2, 2)]
        [InlineData(new[] { 1, 2, 3, 5, 0, 10, -5 }, 5, 5)]
        public void CalculatesSubarraySum(int[] arr, int k, int expected)
        {
            OtherIndicesProblems.CalcSubarraysAmount(arr, k).Should().Be(expected);
        }

        [Theory]
        [InlineData(new[] { 2, 1, 5, 3, 4 }, "3")]
        [InlineData(new[] { 2, 1, 5, 4, 3 }, "4")]
        [InlineData(new[] { 2, 5, 1, 3, 4 }, "Too chaotic")]
        [InlineData(new[] { 2, 1, 5, 4 }, "Too chaotic")]
        public void CalculatesMinimumBribesAmount(int[] a, string expected)
        {
            var content = new StringBuilder();
            using (var writer = new StringWriter(content))
                OtherIndicesProblems.CalcMinimumBribesAmount(writer, a);

            string actualOutput = content.ToString().Replace(Environment.NewLine, "");
            actualOutput.Should().Be(expected);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 3, 4, 5, 1, 2 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 5, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 5, 1, 2, 3, 4 })]
        public void RotatesLeft(int[] a, int d, int[] expected)
        {
            OtherIndicesProblems.RotateLeft(a, d).Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(HourglassSumTestData))]
        public void CalculatesHourglassSum(int[][] arr, int expected)
        {
            OtherIndicesProblems.CalcMaxHourglassSum(arr).Should().Be(expected);
        }

        public static TheoryData<int[][], int> HourglassSumTestData
            => new TheoryData<int[][], int>
            {
                {
                    new[]
                    {
                        new[] { 1, 1, 1, 0, 0, 0 },
                        new[] { 0, 1, 0, 0, 0, 0 },
                        new[] { 1, 1, 1, 0, 0, 0 },
                        new[] { 0, 0, 2, 4, 4, 0 },
                        new[] { 0, 0, 0, 2, 0, 0 },
                        new[] { 0, 0, 1, 2, 4, 0 } },
                    19
                },
            };

        [Theory]
        [InlineData(new[] { 2, -2, 3, 0, 4, -7 }, 4)]
        [InlineData(new[] { 0, 0, 0 }, 6)]
        public void CalculatesArrayZeroFragmentsCount(int[] arr, int expected)
        {
            OtherIndicesProblems.CalcZeroFragmentsCount(arr).Should().Be(expected);
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
            OtherIndicesProblems.ReverseString(s, k).Should().Be(expected);
        }
    }
}
