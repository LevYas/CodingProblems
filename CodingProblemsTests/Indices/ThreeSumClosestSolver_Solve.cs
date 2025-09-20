namespace CodingProblemsTests.Indices;

public class ThreeSumClosestSolver_Solve
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 1, 2)]
    [InlineData(new[] { 0, 0, 0 }, 1, 0)]
    [InlineData(new[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }, -2, -2)]
    [InlineData(new[] { -55, -24, -18, -11, -7, -3, 4, 5, 6, 9, 11, 23, 33 }, 0, 0)]
    public void Solves(int[] nums, int target, int expected)
    {
        int result = new ThreeSumClosestSolver().Solve(nums, target);

        result.Should().Be(expected);
    }
}
