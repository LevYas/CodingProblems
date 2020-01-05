using CodingProblems.MathProblems;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.Equal(expected, OtherMathProblems.CalcNthPerfectNumber(n));
        }

        [Fact]
        public void CalcPiUsingMonteCarloTest()
        {
            Assert.True(Math.Abs(Math.PI - OtherMathProblems.CalcPiUsingMonteCarlo()) < 1e-3);
        }

        [Theory]
        [MemberData(nameof(SetForPowerSetTestData))]
        public void SetToPowerSetGeneralTest(IEnumerable<int> set)
        {
            var sets = OtherMathProblems.SetToPowerSet(set);
            Assert.Equal(8, sets.Count);
            Assert.Equal(set.Count(), sets.SelectMany(en => en).Distinct().Count());
        }

        public static TheoryData<IEnumerable<int>> SetForPowerSetTestData
        {
            get => new TheoryData<IEnumerable<int>>
                {
                    new[] { 1, 2, 3 }
                };
        }
    }
}
