namespace CodingProblems.Indices;

// 2134. Minimum Swaps to Group All 1's Together II
// A swap is defined as taking two distinct positions in an array and swapping the values in them.
// A circular array is defined as an array where we consider the first element and the last element to be adjacent.
// Given a binary circular array nums, return the minimum number of swaps required to group all 1's present in the
//      array together at any location.
// https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together-ii/

public class MinSwapsFinder
{
    public int Find(int[] nums)
    {
        // We'll use sliding window with size == amount of 1s

        int amountOf1 = nums.Sum(n => n == 1 ? 1 : 0);

        int currentAmountOf0 = 0;
        int windowSize = 0;

        while (windowSize < amountOf1)
        {
            if (nums[windowSize++] == 0)
                currentAmountOf0++;
        }

        int getIdx(int idx) => idx % nums.Length;

        int minAmountOf0 = currentAmountOf0;
        for (int i = 0; i < nums.Length + amountOf1; i++)
        {
            if (nums[getIdx(i)] == 0)
                currentAmountOf0--;

            if (nums[getIdx(i + windowSize)] == 0)
                currentAmountOf0++;

            minAmountOf0 = Math.Min(minAmountOf0, currentAmountOf0);
        }

        return minAmountOf0;
    }
}
