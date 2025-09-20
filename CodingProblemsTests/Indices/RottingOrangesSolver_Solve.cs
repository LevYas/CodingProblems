namespace CodingProblemsTests.Indices;

public class RottingOrangesSolver_Solve
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Solves(int[][] grid, int expected)
    {
        int result = new RottingOrangesSolver().Solve(grid);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void SolvesBruteforceVersion(int[][] grid, int expected)
    {
        int result = new RottingOrangesSolver().SolveUsingBruteforce(grid);

        result.Should().Be(expected);
    }

    public static TheoryData<int[][], int> TestData
        => new()
        {
            {
                new[]
                {
                    new[] { 2, 1, 1 },
                    new[] { 1, 1, 0 },
                    new[] { 0, 1, 1 },
                },
                4
            },
            {
                new[]
                {
                    new[] { 2, 1, 1 },
                    new[] { 0, 1, 1 },
                    new[] { 1, 0, 1 },
                },
                -1
            },
            {
                new[]
                {
                    new[] { 2, 1, 1 },
                    new[] { 1, 1, 1 },
                    new[] { 0, 1, 2 },
                },
                2
            },
            {
                new[]
                {
                    new[] { 0, 2 },
                },
                0
            },
        };
}
