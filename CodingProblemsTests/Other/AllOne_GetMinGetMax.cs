namespace CodingProblemsTests.Other;

public class AllOne_GetMinGetMax
{
    [Theory]
    [InlineData(new[] { "hello" }, new string[0], "hello", "hello")]
    [InlineData(new[] { "hello", "hello" }, new string[0], "hello", "hello")]
    [InlineData(new[] { "hello", "hello", "leet" }, new string[0], "leet", "hello")]
    [InlineData(new[] { "hello", "leet", "three", "hello" }, new string[0], null, "hello")]
    [InlineData(new[] { "hello", "leet", "three", "three" }, new string[0], null, "three")]

    [InlineData(new[] { "hello", "hello", "leet" }, new[] { "hello", "hello" }, "leet", "leet")]
    [InlineData(new[] { "hello", "hello", "leet" }, new[] { "hello", "leet", "hello" }, "", "")]

    [InlineData(new[] { "a", "b", "b", "b", "b" }, new[] { "b", "b" }, "a", "b")]
    public void AreValid(string[] toInc, string[] toDec, string expectedMin, string expectedMax)
    {
        AllOne sut = new();

        foreach (string s in toInc)
            sut.Inc(s);

        foreach (string s in toDec)
            sut.Dec(s);

        if (expectedMin != null)
            sut.GetMinKey().Should().Be(expectedMin);

        sut.GetMaxKey().Should().Be(expectedMax);
    }
}
