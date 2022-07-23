namespace CodingProblemsTests.Indices;

public class EatingSpeedCalculator_FindMinEatingSpeed
{
    [Theory]
    [InlineData(new[] { 3, 6, 7, 11 }, 8, 4)]
    [InlineData(new[] { 30, 11, 23, 4, 20 }, 5, 30)]
    [InlineData(new[] { 30, 11, 23, 4, 20 }, 6, 23)]
    [InlineData(new[] { 1000000000, 1000000000 }, 3, 1000000000)]
    public void Works(int[] piles, int h, int expected)
    {
        int result = new EatingSpeedCalculator().FindMinEatingSpeed(piles, h);

        result.Should().Be(expected);
    }
}
