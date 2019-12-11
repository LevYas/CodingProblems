using CodingProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingProblemsTests
{
    public class MathProblemsTests
    {
        [Theory]
        [InlineData(1, 19)]
        [InlineData(2, 28)]
        [InlineData(10, 109)]
        [InlineData(11, 118)]
        [InlineData(12, 127)]
        [InlineData(15, 154)]
        public void GetNthPerfectNumberTest(int n, int expected)
        {
            Assert.Equal(expected, MathProblems.CalcNthPerfectNumber(n));
        }

        [Fact]
        public void CalcPiUsingMonteCarloTest()
        {
            Assert.True(Math.Abs(Math.PI - MathProblems.CalcPiUsingMonteCarlo()) < 1e-3);
        }

        [Theory]
        [MemberData(nameof(SetForPowerSet))]
        public void SetToPowerSetGeneralTest(IEnumerable<int> set)
        {
            var sets = MathProblems.SetToPowerSet(set);
            Assert.Equal(8, sets.Count());
            Assert.Equal(set.Count(), sets.SelectMany(en => en).Distinct().Count());
        }

        public static TheoryData<IEnumerable<int>> SetForPowerSet
        {
            get => new TheoryData<IEnumerable<int>>
                {
                    new[] { 1, 2, 3 }
                };
        }

        [Theory]
        [InlineData(3, 2, 0, 0, 0.0625)]
        [InlineData(3, 3, 0, 0, 0.015625)]
        public void CalcKnightProbabilityTest(int chessboardSize, int movesAmount, int startRow, int startColumn, double expected)
        {
            Assert.Equal(expected, MathProblems.CalcKnightProbability(chessboardSize, movesAmount, startRow, startColumn), 10);
        }

        [Theory]
        [InlineData(9, new int[] { 1, 1, 0, 0, 1 })]
        [InlineData(-9, new int[] { 1, 0, 1, 1 })]
        [InlineData(40, new int[] { 1, 1, 1, 1, 0, 0, 0 })]
        public void ToNegabinaryTest(int number, int[] expected)
        {
            Assert.Equal(expected, MathProblems.ToNegabinary(number));
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, 11)]
        [InlineData(new int[] { 1, 0, 1 }, 5)]
        [InlineData(new int[] { 1, 1, 0, 0, 1 }, 9)]
        [InlineData(new int[] { 1, 0, 1, 1 }, -9)]
        [InlineData(new int[] { 1, 1, 1, 1, 0, 0, 0 }, 40)]
        public void FromNegabinaryTest(int[] arr, int expected)
        {
            Assert.Equal(expected, MathProblems.FromNegabinary(arr));
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 0, 0, 0, 0 })]
        public void AddNegabinarySimpleTest(int[] arr1, int[] arr2, int[] expected)
        {
            Assert.Equal(expected, MathProblems.AddNegabinarySimple(arr1, arr2));
        }

        [Theory]
        [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 1, 1 }, new int[] { 1 }, new int[] { 0 })]
        [InlineData(new int[] { 1 }, new int[] { 1, 1, 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 0, 0, 0, 0 })]
        [InlineData(new int[] { 1, 0, 1, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 0, 1, 0, 0 }, new int[] { 1, 1, 0, 0, 1, 1, 0, 0, 1 })]
        public void AddNegabinaryTest(int[] arr1, int[] arr2, int[] expected)
        {
            Assert.Equal(expected, MathProblems.AddNegabinary(arr1, arr2));
        }
    }
}
