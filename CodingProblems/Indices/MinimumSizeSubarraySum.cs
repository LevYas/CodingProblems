namespace CodingProblems.Indices;

// 209. Minimum Size Subarray Sum
// Given an array of positive integers nums and a positive integer target, return the minimal length of a contiguous subarray
//      [numsl, numsl+1, ..., numsr-1, numsr] of which the sum is greater than or equal to target.
// If there is no such subarray, return 0 instead.
// https://leetcode.com/problems/minimum-size-subarray-sum/

public class MinimumSizeSubarraySum
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int lo = 0;
        int hi = 0;

        int currentSum = 0;
        int minLength = Int32.MaxValue;

        while (lo < nums.Length)
        {
            if (currentSum < target && hi < nums.Length)
            {
                currentSum += nums[hi];
                hi++;
            }
            else
            {
                currentSum -= nums[lo];
                lo++;
            }

            if (currentSum >= target)
                minLength = Math.Min(minLength, hi - lo);

            if (minLength == 1)
                return 1;
        }

        return minLength == Int32.MaxValue ? 0 : minLength;
    }
}
