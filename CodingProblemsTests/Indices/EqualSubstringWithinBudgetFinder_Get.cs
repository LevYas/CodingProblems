namespace CodingProblemsTests.Indices;

public class EqualSubstringWithinBudgetFinder_Get
{
    [Theory]
    [InlineData("abcd", "bcdf", 3, 3)]
    [InlineData("abcd", "cdef", 3, 1)]
    [InlineData("abcd", "acde", 0, 1)]
    [InlineData("b", "e", 1, 0)]
    public void Works(string s, string t, int maxCost, int expected)
    {
        int result = new EqualSubstringWithinBudgetFinder().GetEqualSubstringsWithinBudget(s, t, maxCost);

        result.Should().Be(expected);
    }
}
