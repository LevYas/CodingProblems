namespace CodingProblemsTests.Numbers;

public class PerfectSquareValidator_IsPerfectSquare
{
    [Theory]
    [InlineData(1, true)]
    [InlineData(4, true)]
    [InlineData(16, true)]
    [InlineData(121, true)]
    [InlineData(808201, true)]
    [InlineData(2147395600, true)]
    [InlineData(2, false)]
    [InlineData(14, false)]
    public void Works(int num, bool expected)
    {
        bool result = new PerfectSquareValidator().IsPerfectSquare(num);

        result.Should().Be(expected);
    }
}
