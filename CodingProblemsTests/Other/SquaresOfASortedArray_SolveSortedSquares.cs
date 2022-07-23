namespace CodingProblemsTests.Other;

public class SquaresOfASortedArray_SolveSortedSquares
{
    [Theory]
    [InlineData(new[] { -1 }, new[] { 1 })]
    [InlineData(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
    [InlineData(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
    public void Works(int[] nums, int[] expected)
    {
        int[] result = new SquaresOfASortedArray().SolveSortedSquares(nums);

        result.Should().Equal(expected);
    }
}