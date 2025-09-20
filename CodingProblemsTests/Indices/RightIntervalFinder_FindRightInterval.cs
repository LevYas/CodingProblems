namespace CodingProblemsTests.Indices;

public class RightIntervalFinder_FindRightInterval
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] intervals, int[] expected)
    {
        int[] result = new RightIntervalFinder().FindRightInterval(intervals);

        result.Should().Equal(expected);
    }

    public static TheoryData<int[][], int[]> TestData
        => new()
        {
            {
                "[1,2]".ToArrays(),
                new[] { -1 }
            },
            {
                "[3,4],[2,3],[1,2]".ToArrays(),
                new[] { -1,0,1 }
            },
            {
                "[1,4],[2,3],[3,4]".ToArrays(),
                new[] { -1,2,-1 }
            },
            {
                "[4,5],[2,3],[1,2]".ToArrays(),
                new[] { -1, 0, 1 }
            },
        };
}
