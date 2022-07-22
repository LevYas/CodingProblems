namespace CodingProblems.Indices;

// 1648. Sell Diminishing-Valued Colored Balls
// You have an inventory of different colored balls, and there is a customer that wants orders balls of any color.
// The customer weirdly values the colored balls.
// Each colored ball's value is the number of balls of that color you currently have in your inventory.
// For example, if you own 6 yellow balls, the customer would pay 6 for the first yellow ball.
// After the transaction, there are only 5 yellow balls left,
//      so the next yellow ball is then valued at 5 (i.e., the value of the balls decreases as you sell more to the customer).
// You are given an integer array, inventory, where inventory[i] represents the number of balls
//      of the ith color that you initially own.
// You are also given an integer orders, which represents the total number of balls that the customer wants.
// You can sell the balls in any order.
// Return the maximum total value that you can attain after selling orders colored balls.
// As the answer may be too large, return it modulo 109 + 7.
// https://leetcode.com/problems/sell-diminishing-valued-colored-balls/

public class BallProfitMaximizer
{
    public int MaxProfit(int[] inventory, int orders)
    {
        // Solution: sort the array, calculate rectangles with the same max and min inv. Calc sum of AP for column, multiply by width

        Array.Sort(inventory);
        Array.Reverse(inventory);

        ulong profit = 0;
        ulong currentMaxValue = (ulong)inventory[0];
        ulong columnsWithCurrentMax = 1;

        while (orders > 0)
        {
            while (columnsWithCurrentMax < (ulong)inventory.Length
                   && (ulong)inventory[columnsWithCurrentMax] >= currentMaxValue)
                columnsWithCurrentMax++;

            ulong nextValue = columnsWithCurrentMax < (ulong)inventory.Length ? (ulong)inventory[columnsWithCurrentMax] : 0;
            ulong maxAvailableHeight = currentMaxValue - nextValue;

            ulong itemsToDraw = Math.Min((ulong)orders, columnsWithCurrentMax * maxAvailableHeight);

            ulong wholeRows = itemsToDraw / columnsWithCurrentMax;

            ulong profitFromOneCol = (currentMaxValue + currentMaxValue - wholeRows + 1) * wholeRows / 2;
            profit += profitFromOneCol * columnsWithCurrentMax;

            currentMaxValue -= wholeRows;

            ulong lastRowWidth = itemsToDraw % columnsWithCurrentMax;
            profit += lastRowWidth * currentMaxValue;

            orders -= (int)itemsToDraw;
        }

        return (int)(profit % 1000000007);
    }
}
