using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class BallProfitMaximizer_MaxProfit
{
    [Theory]
    [InlineData(new[] { 2, 5 }, 4, 14)]
    [InlineData(new[] { 2, 5 }, 7, 18)]
    [InlineData(new[] { 3, 5 }, 6, 19)]
    [InlineData(new[] { 1000000000 }, 1000000000, 21)]
    [InlineData(new[] { 76 }, 22, 1441)]
    [InlineData(new[] { 2, 8, 4, 10, 6 }, 20, 110)]
    [InlineData(new[] { 215304442, 215520137, 789340189, 671515111, 162866516, 34775245, 440362748, 807594688, 771805560, 457696035, 933697922, 74781394, 55203629, 478443718, 61254303, 764025706, 813169464, 319568349, 209224238, 938193904, 463246620, 894931258, 294930990, 974756402, 50124566, 216580040, 728203093, 991462942, 210175195, 694836099, 375598500, 182268382, 787941805, 129316712, 351790475, 78646550, 361370990, 554717209, 752316728, 447978710, 146899252, 583712441, 529216382, 961753636, 758773559 }, 736018741, 458631340)]
    [InlineData(new[] { 680754224, 895956841, 524658639, 3161416, 992716630, 7365440, 582714485, 422256708, 332815744, 269407767 }, 707568720, 6150955)]
    [InlineData(new[] { 1000000000,1000000000,1000000000 }, 1000000000, 37)]
    public void Works(int[] inventory, int orders, int expected)
    {
        int result = new BallProfitMaximizer().MaxProfit(inventory, orders);

        result.Should().Be(expected);
    }
}
