namespace CodingProblemsTests.Numbers;

public class HammingWeightCalculator_Calc
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(8, 1)]
    [InlineData(11, 3)]
    [InlineData(4294967293, 31)]
    public void Works(uint n, int expected)
    {
        int result = new HammingWeightCalculator().Calc(n);

        result.Should().Be(expected);
    }
}
