namespace CodingProblemsTests.Indices;

public class SubstringFinder_StrStr
{
    [Theory]
    [InlineData("hello", "ll", 2)]
    [InlineData("aaaaa", "bba", -1)]
    [InlineData("hello", "lo", 3)]
    [InlineData("hello", "he", 0)]
    public void Works(string haystack, string needle, int expected)
    {
        int result = new SubstringFinder().StrStr(haystack, needle);

        result.Should().Be(expected);
    }
}
