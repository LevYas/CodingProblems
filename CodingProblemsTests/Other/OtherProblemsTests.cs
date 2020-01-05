using CodingProblems.Other;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class OtherProblemsTests
    {
        [Theory]
        [MemberData(nameof(FindMinClassroomsAmountTestData))]
        public void FindMinClassroomsAmountTest((int, int)[] intervals, int expected)
        {
            Assert.Equal(expected, OtherProblems.FindMinClassroomsAmount(intervals));
        }

        public static TheoryData<(int, int)[], int> FindMinClassroomsAmountTestData => new TheoryData<(int, int)[], int>
            {
                { new[] { (30, 75), (0, 50), (60, 150) }, 2 }
            };
    }
}
