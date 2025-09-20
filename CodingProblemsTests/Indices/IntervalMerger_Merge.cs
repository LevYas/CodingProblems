namespace CodingProblemsTests.Indices;

public class IntervalMerger_Merge
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] intervals, int[][] expected)
    {
        int[][] result = new IntervalMerger().Merge(intervals);

        result.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<int[][], int[][]> TestData
        => new()
        {
            {
                "[1,3],[2,6],[8,10],[15,18]".ToArrays(),
                "[1,6],[8,10],[15,18]".ToArrays()
            },
            {
                "[1,4],[4,5]".ToArrays(),
                "[1,5]".ToArrays()
            },
            {
                "[[1,4],[2,3]]".ToArrays(),
                "[1,4]".ToArrays()
            },
        };
}
