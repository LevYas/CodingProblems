namespace CodingProblemsTests.Other;

public class MinStack_PushPopMin
{
    private readonly MinStack _sut = new();

    [Theory]
    [InlineData(new[] { 5 }, new[] { 5 })]
    [InlineData(new[] { 5, 7, 5, 7, 4, 5 }, new[] { 5, 4, 7, 5, 7, 5 })]
    [InlineData(new[] { -2, 0, -3 }, new[] { -3, 0, -2 })]
    public void TopWorks(int[] input, int[] expected)
    {
        foreach (int i in input)
            _sut.Push(i);

        foreach (int i in expected)
        {
            _sut.Top().Should().Be(i);
            _sut.Pop();
        }
    }

    [Theory]
    [InlineData(new[] { 5 }, new[] { 5 })]
    [InlineData(new[] { 5, 7, 4, 5 }, new[] { 4, 4, 5, 5 })]
    [InlineData(new[] { -2, 0, -3 }, new[] { -3, -2, -2 })]
    public void GetMinWorks(int[] input, int[] expected)
    {
        foreach (int i in input)
            _sut.Push(i);

        foreach (int i in expected)
        {
            _sut.GetMin().Should().Be(i);
            _sut.Pop();
        }
    }
}
