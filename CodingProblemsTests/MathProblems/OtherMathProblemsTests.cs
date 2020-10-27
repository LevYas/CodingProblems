using CodingProblems.MathProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.MathProblems
{
    public class OtherMathProblemsTests
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
            OtherMathProblems.CalcNthPerfectNumber(n).Should().Be(expected);
        }

        [Fact]
        public void CalcPiUsingMonteCarloTest()
        {
            OtherMathProblems.CalcPiUsingMonteCarlo().Should().BeApproximately(Math.PI, 3);
        }

        [Theory]
        [MemberData(nameof(SetForPowerSetTestData))]
        public void SetToPowerSetGeneralTest(int[] set)
        {
            IList<IList<int>> sets = OtherMathProblems.SetToPowerSet(set);

            sets.Should().HaveCount(8);
            sets.SelectMany(en => en).Distinct().Should().HaveCount(set.Length);
        }

        public static TheoryData<int[]> SetForPowerSetTestData
            => new TheoryData<int[]> {new[] { 1, 2, 3 }};
    }
}
