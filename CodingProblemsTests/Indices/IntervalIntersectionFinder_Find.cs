namespace CodingProblemsTests.Indices;

public class IntervalIntersectionFinder_Find
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] firstList, int[][] secondList, int[][] expected)
    {
        int[][] result = new IntervalIntersectionFinder().Find(firstList, secondList);

        for (int i = 0; i < expected.Length; i++)
            result[i].Should().Equal(expected[i]);
    }

    public static TheoryData<int[][], int[][], int[][]> TestData
        => new()
        {
            {
                new[] { new[] { 0, 2 }, new[] { 5, 10 }, new[] { 13, 23 }, new[] { 24, 25 } },
                new[] { new[] { 1, 5 }, new[] { 8, 12 }, new[] { 15, 24 }, new[] { 25, 26 } },
                new[] { new[] { 1, 2 }, new[] { 5, 5 }, new[] { 8, 10 }, new[] { 15, 23 }, new[] { 24, 24 }, new[] { 25, 25 } }
            },
            {
                new[] { new[] { 0, 2 }, new[] { 5, 10 }, new[] { 13, 23 }, new[] { 24, 25 } },
                Array.Empty<int[]>(),
                Array.Empty<int[]>()
            },
        };
}
