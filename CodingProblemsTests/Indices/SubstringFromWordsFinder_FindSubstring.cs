namespace CodingProblemsTests.Indices;

public class SubstringFromWordsFinder_FindSubstring
{
    [Theory]
    [InlineData("barfoothefoobarman", new[] { "foo", "bar" }, new[] { 0, 9 })]
    [InlineData("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "word" }, new int[0])]
    [InlineData("barfoofoobarthefoobarman", new[] { "bar", "foo", "the" }, new[] { 6, 9, 12 })]
    [InlineData("aaaaa", new[] { "aa", "aa" }, new[] { 0, 1 })]
    public void Works(string s, string[] words, int[] expected)
    {
        IList<int> result = new SubstringFromWordsFinder().FindSubstring(s, words);

        result.Should().BeEquivalentTo(expected);
    }
}
