namespace CodingProblemsTests.MathProblems;

public class ServiceCenterPlacer_GetMinDistSum
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] positions, double expected)
    {
        double result = new ServiceCenterPlacer().GetMinDistSum(positions);

        result.Should().BeApproximately(expected, 1e-5);
    }

    public static TheoryData<int[][], double> TestData() =>
        new()
        {
            {
                new[] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 1, 2 }, new[] { 2, 1 } },
                4
            },
            {
                new[] { new[] { 1, 1 }, new[] { 3, 3 } },
                2.82843
            },
            {
                new[] { new[] { 3, 3 } },
                0
            },
            {
                new[]
                {
                    new[] { 47, 37 }, new[] { 38, 36 }, new[] { 44, 42 }, new[] { 46, 36 }, new[] { 39, 48 }, new[] { 87, 87 },
                    new[] { 41, 36 }, new[] { 41, 44 }, new[] { 87, 85 }, new[] { 45, 47 }, new[] { 85, 87 }, new[] { 87, 87 },
                    new[] { 41, 45 }, new[] { 41, 40 }, new[] { 39, 46 }, new[] { 87, 87 }, new[] { 39, 45 }, new[] { 85, 85 },
                    new[] { 43, 36 }, new[] { 85, 85 }, new[] { 87, 85 }, new[] { 47, 45 }, new[] { 42, 47 }, new[] { 87, 86 },
                    new[] { 41, 40 }, new[] { 36, 44 }, new[] { 43, 45 }, new[] { 46, 46 }, new[] { 85, 86 }, new[] { 41, 45 },
                    new[] { 86, 87 }, new[] { 46, 39 }, new[] { 86, 85 }, new[] { 37, 38 }, new[] { 85, 87 }, new[] { 87, 87 },
                    new[] { 86, 85 }, new[] { 85, 85 },
                },
                1055.53427
            },
            {
                new[] { new[] { 0, 0 }, new[] { 0, 0 }, new[] { 0, 0 }, new[] { 0, 0 }, new[] { 0, 0 } },
                0
            },
            {
                new[] { new[] { 17, 80 }, new[] { 17, 32 } },
                48
            },
        };
}
