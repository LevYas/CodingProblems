using CodingProblems.Other;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class OtherProblemsTests
    {
        [Theory]
        [MemberData(nameof(FindMinClassroomsAmountTestData))]
        public void FindMinClassroomsAmountTest((int, int)[] intervals, int expected)
        {
            OtherProblems.FindMinClassroomsAmount(intervals).Should().Be(expected);
        }

        public static TheoryData<(int, int)[], int> FindMinClassroomsAmountTestData => new TheoryData<(int, int)[], int>
            {
                { new[] { (30, 75), (0, 50), (60, 150) }, 2 }
            };
    }
}
