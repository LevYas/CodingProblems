namespace CodingProblemsTests.Indices;

public class VideoStitching_CalcMinAmountOfClips
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] clips, int time, int expected)
    {
        int result = new VideoStitching().CalcMinAmountOfClips(clips, time);

        result.Should().Be(expected);
    }

    public static TheoryData<int[][], int, int> TestData
        => new()
        {
            { "[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]".ToArrays(), 10, 3 },
            { "[0,1],[1,2]".ToArrays(), 5, -1 },
            { "[0,1],[6,8],[0,2],[5,6],[0,4],[0,3],[6,7],[1,3],[4,7],[1,4],[2,5],[2,6],[3,4],[4,5],[5,7],[6,9]".ToArrays(), 9, 3 },
            { "[0,4],[3,9]".ToArrays(), 5, 2 },
        };
}
