namespace CodingProblemsTests.Indices;

public class SearchIn2dMatrix_SearchMatrix
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] matrix, int target, bool expected)
    {
        bool result = new SearchIn2dMatrix().SearchMatrix(matrix, target);

        result.Should().Be(expected);
    }

    public static TheoryData<int[][], int, bool> TestData
        => new()
        {
            {
                new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } },
                3,
                true
            },
            {
                new[] { new[] { 1 } },
                1,
                true
            },
            {
                new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } },
                13,
                false
            },
        };
}
