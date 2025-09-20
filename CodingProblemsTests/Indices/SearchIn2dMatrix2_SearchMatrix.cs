namespace CodingProblemsTests.Indices;

public class SearchIn2dMatrix2_SearchMatrix
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] matrix, int target, bool expected)
    {
        bool result = new SearchIn2dMatrix2().SearchMatrix(matrix, target);

        result.Should().Be(expected);
    }

    public static TheoryData<int[][], int, bool> TestData
        => new()
        {
            {
                new[] { new[] { 1, 4, 7, 11, 15 }, new[] { 2, 5, 8, 12, 19 }, new[] { 3, 6, 9, 16, 22 },
                    new[] { 10, 13, 14, 17, 24 }, new[] { 18, 21, 23, 26, 30 } },
                5,
                true
            },
            {
                new[] { new[] { 1, 4, 7, 11, 15 }, new[] { 2, 5, 8, 12, 19 }, new[] { 3, 6, 9, 16, 22 },
                    new[] { 10, 13, 14, 17, 24 }, new[] { 18, 21, 23, 26, 30 } },
                15,
                true
            },
            {
                new[] { new[] { 1, 4, 7, 11, 15 }, new[] { 2, 5, 8, 12, 19 }, new[] { 3, 6, 9, 16, 22 },
                    new[] { 10, 13, 14, 17, 24 }, new[] { 18, 21, 23, 26, 30 } },
                20,
                false
            },
            {
                new[] { new[] { 1 } },
                1,
                true
            },
        };
}
