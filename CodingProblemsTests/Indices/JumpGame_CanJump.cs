namespace CodingProblemsTests.Indices;

public class JumpGame_CanJump
{
    [Theory]
    [InlineData(new[] { 2, 3, 1, 1, 4 }, true)]
    [InlineData(new[] { 3, 2, 1, 0, 4 }, false)]
    public void Works(int[] nums, bool expected)
    {
        bool result = new JumpGame().CanJump(nums);

        result.Should().Be(expected);
    }
}
