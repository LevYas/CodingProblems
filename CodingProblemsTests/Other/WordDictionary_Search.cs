namespace CodingProblemsTests.Other;

public class WordDictionary_Search
{
    [Theory]
    [InlineData(new[] {"bad", "dad", "mad"}, "pad", false)]
    [InlineData(new[] {"bad", "dad", "mad"}, "bad", true)]
    [InlineData(new[] {"bad", "dad", "mad"}, ".ad", true)]
    [InlineData(new[] {"bad", "dad", "mad"}, "b..", true)]
    [InlineData(new[] {"bad", "dad", "mad"}, "b.m", false)]
    [InlineData(new[] {"bad", "dad", "mad"}, "...", true)]
    [InlineData(new[] {"bad", "bam", "bud"}, "...", true)]
    [InlineData(new[] {"baz", "dad", "mad"}, "..z", true)]
    [InlineData(new[] {"at", "and", "an", "add"}, "a", false)]
    [InlineData(new[] {"at", "and", "an", "add"}, "addition", false)]
    public void Works(string[] words, string target, bool expected)
    {
        WordDictionary sut = new();

        foreach (string word in words)
            sut.AddWord(word);

        sut.Search(target).Should().Be(expected);
    }
}
