namespace CodingProblemsTests.Indices;

public class MaximumCandiesCalculator_Calculate
{
    [Theory]
    [InlineData(new[] { 5, 8, 6 }, 3, 5)]
    [InlineData(new[] { 2, 5 }, 11, 0)]
    [InlineData(new[] { 5, 6, 4, 10, 10, 1, 1, 2, 2, 2 }, 9, 3)]
    public void Works(int[] candies, long k, int expected)
    {
        int result = new MaximumCandiesCalculator().Calculate(candies, k);

        result.Should().Be(expected);
    }
}
