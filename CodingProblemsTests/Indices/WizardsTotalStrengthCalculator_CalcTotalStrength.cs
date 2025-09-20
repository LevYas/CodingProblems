namespace CodingProblemsTests.Indices;

public class WizardsTotalStrengthCalculator_CalcTotalStrength
{
    [Theory]
    [InlineData(new[] { 1, 3, 1, 2 }, 44)]
    [InlineData(new[] { 5, 4, 6 }, 213)]
    public void Works(int[] strengths, int expected)
    {
        int result = new WizardsTotalStrengthCalculator().CalcTotalStrength(strengths);

        result.Should().Be(expected);
    }
}
