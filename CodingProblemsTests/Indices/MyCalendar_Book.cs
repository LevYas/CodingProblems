namespace CodingProblemsTests.Indices;

public class MyCalendar_Book
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works((int, int, bool)[] datum)
    {
        MyCalendar sut = new();

        foreach ((int start, int end, bool expected) in datum)
            sut.Book(start, end).Should().Be(expected);
    }

    public static TheoryData<(int, int, bool)[]> TestData
        => new()
        {
            new[]
            {
                (10, 20, true),
                (15, 25, false),
                (20, 30, true),
                (15, 16, false),
                (20, 25, false),
                (50, 60, true),
                (0, 10, true),
            },
            new[]
            {
                (37, 50, true),
                (33, 50, false),
                (4, 17, true),
                (35, 48, false),
                (8, 25, false),
            },
        };
}
