namespace CodingProblemsTests.Other;

public class SquaresDetector_Count
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[][] points, int[] request, int expected)
    {
        SquaresDetector sut = new();

        foreach (int[] point in points)
            sut.Add(point);

        sut.Count(request).Should().Be(expected);
    }

    public static TheoryData<int[][], int[], int> TestData
        => new()
        {
            {
                new[] { new[] { 3, 10 }, new[] { 11, 2 }, new[] { 3, 2 } },
                new[] { 11, 10 },
                1
            },
            {
                new[] { new[] { 3, 10 }, new[] { 11, 2 }, new[] { 3, 2 } },
                new[] { 14, 8 },
                0
            },
            {
                new[] { new[] { 3, 10 }, new[] { 11, 2 }, new[] { 3, 2 }, new[] { 11, 2 } },
                new[] { 11, 10 },
                2
            },
            {
                new[]
                {
                    new[] { 3, 5 }, new[] { 5, 5 }, new[] { 7, 5 }, new[] { 5, 4 }, new[] { 3, 3 }, new[] { 6, 3 },
                    new[] { 7, 3 }, new[] { 5, 2 }, new[] { 6, 2 }, new[] { 3, 1 }, new[] { 5, 1 }, new[] { 7, 1 }
                },
                new[] { 5, 3 },
                5
            },
            {
                new[]
                {
                    new[] { 5, 10 }, new[] { 10, 5 }, new[] { 10, 10 }, new[] { 3, 0 }, new[] { 8, 0 }, new[] { 8, 5 }, new[] { 9, 0 },
                    new[] { 9, 8 }, new[] { 1, 8 }, new[] { 0, 0 }, new[] { 8, 0 }, new[] { 8, 8 }, new[] { 1, 9 }, new[] { 2, 9 },
                    new[] { 2, 10 }, new[] { 7, 8 }, new[] { 2, 3 }, new[] { 2, 8 }, new[] { 9, 10 }, new[] { 9, 5 }, new[] { 4, 5 },
                    new[] { 0, 9 }, new[] { 4, 5 }, new[] { 4, 9 }, new[] { 1, 10 }, new[] { 10, 1 }, new[] { 10, 10 }, new[] { 10, 0 },
                    new[] { 2, 0 }, new[] { 2, 8 }, new[] { 7, 6 }, new[] { 4, 6 }, new[] { 4, 9 }, new[] { 10, 9 }, new[] { 10, 0 },
                    new[] { 1, 0 },
                },
                new[] { 1,9 },
                5
            },
        };
}
