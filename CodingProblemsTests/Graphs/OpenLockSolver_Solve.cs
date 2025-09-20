namespace CodingProblemsTests.Graphs;

public class OpenLockSolver_Solve
{
    [Theory]
    [InlineData(new[] { "0201", "0101", "0102", "1212", "2002" }, "0202", 6)]
    [InlineData(new[] { "8888" }, "0009", 1)]
    [InlineData(new[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" }, "8888", -1)]
    [InlineData(new[] { "0000" }, "8888", -1)]
    [InlineData(new string[] { }, "8888", 8)]
    public void Works(string[] deadends, string target, int expected)
    {
        int result = new OpenLockSolver().Solve(deadends, target);

        result.Should().Be(expected);
    }
}
