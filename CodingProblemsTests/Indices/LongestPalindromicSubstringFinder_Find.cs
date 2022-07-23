namespace CodingProblemsTests.Indices;

public class LongestPalindromicSubstringFinder_Find
{
    [Theory]
    [InlineData("a", "a")]
    [InlineData("aa", "aa")]
    [InlineData("ab", "a")]
    [InlineData("babad", "bab")] 
    [InlineData("cbbd", "bb")]
    [InlineData("bdaa", "aa")]
    [InlineData("aaaa", "aaaa")]
    [InlineData("abba", "abba")]
    [InlineData("csabbaks", "abba")]
    [InlineData("bdaaa", "aaa")]
    public void Works(string s, string expected)
    {
        string result = new LongestPalindromicSubstringFinder().Find(s);

        result.Should().Be(expected);
    }
}
