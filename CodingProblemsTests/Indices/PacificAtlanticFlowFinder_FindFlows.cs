using System.Collections;

namespace CodingProblemsTests.Indices;

public class PacificAtlanticFlowFinder_FindFlows
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] heights, int[][] expected)
    {
        IList<IList<int>> result = new PacificAtlanticFlowFinder().FindFlows(heights);

        var expectedList = (IList)expected.Select(l => (IList)l.ToList()).ToList();
        result.Should().BeEquivalentTo(expectedList);
    }

    public static TheoryData<int[][], int[][]> TestData
        => new()
        {
            {
                new[]
                {
                    new[] { 2, 1 },
                    new[] { 1, 2 },
                },
                new[]
                {
                    new[] { 0, 0 },
                    new[] { 0, 1 },
                    new[] { 1, 0 },
                    new[] { 1, 1 },
                }
            },
            {
                new[]
                {
                    new[] { 1, 2, 2, 3, 5 },
                    new[] { 3, 2, 3, 4, 4 },
                    new[] { 2, 4, 5, 3, 1 },
                    new[] { 6, 7, 1, 4, 5 },
                    new[] { 5, 1, 1, 2, 4 },
                },
                new[]
                {
                    new[] { 0, 4 },
                    new[] { 1, 3 },
                    new[] { 1, 4 },
                    new[] { 2, 2 },
                    new[] { 3, 0 },
                    new[] { 3, 1 },
                    new[] { 4, 0 },
                }
            },
            {
                new[]
                {
                    new[] { 3,3,3,3,3,3 },
                    new[] { 3,0,3,3,0,3 },
                    new[] { 3,3,3,3,3,3 },
                },
                new[]
                {
                    new[] { 0, 0 },
                    new[] { 0, 1 },
                    new[] { 0, 2 },
                    new[] { 0, 3 },
                    new[] { 0, 4 },
                    new[] { 0, 5 },

                    new[] { 1, 0 },
                    new[] { 1, 2 },
                    new[] { 1, 3 },
                    new[] { 1, 5 },

                    new[] { 2, 0 },
                    new[] { 2, 1 },
                    new[] { 2, 2 },
                    new[] { 2, 3 },
                    new[] { 2, 4 },
                    new[] { 2, 5 },
                }
            },
        };
}
