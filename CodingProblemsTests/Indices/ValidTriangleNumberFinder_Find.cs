namespace CodingProblemsTests.Indices;

public class ValidTriangleNumberFinder_Find
{
    [Theory]
    [InlineData(new[] { 2, 2, 3, 4 }, 3)]
    [InlineData(new[] { 0, 2, 3, 4 }, 1)]
    [InlineData(new[] { 4, 2, 3, 4 }, 4)]
    [InlineData(new[] { 4, 2 }, 0)]
    [InlineData(new[] { 34, 75, 96, 10, 60, 70, 70, 45 }, 36)]
    public void Works(int[] nums, int expected)
    {
        int result = new ValidTriangleNumberFinder().Find(nums);

        result.Should().Be(expected);
    }
}
