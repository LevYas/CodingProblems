namespace CodingProblemsTests.Indices;

public class TimeMap_SetGet
{
    public record Entry(string Key, string Value, int Timestamp);

    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(Entry[] input, Entry[] expected)
    {
        TimeMap sut = new();

        foreach (Entry entry in input)
            sut.Set(entry.Key, entry.Value, entry.Timestamp);

        foreach (Entry entry in expected)
            sut.Get(entry.Key, entry.Timestamp).Should().Be(entry.Value);
    }

    public static TheoryData<Entry[], Entry[]> TestData
        => new()
        {
            {
                new[]
                {
                    new Entry("foo", "bar", 1),
                },
                new[]
                {
                    new Entry("foo", "bar", 1),
                    new Entry("foo", "bar", 3),
                }
            },
            {
                new[]
                {
                    new Entry("foo", "bar", 1),
                    new Entry("foo", "bar2", 4),
                },
                new[]
                {
                    new Entry("foo", "bar2", 4),
                    new Entry("foo", "bar2", 5),
                }
            },
            {
                new[]
                {
                    new Entry("love", "high", 10),
                    new Entry("love", "low", 20),
                },
                new[]
                {
                    new Entry("love", "", 5),
                    new Entry("love", "high", 10),
                    new Entry("love", "high", 15),
                    new Entry("love", "low", 20),
                    new Entry("love", "low", 25),
                }
            },
        };
}
