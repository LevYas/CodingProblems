namespace CodingProblems.Indices;

// 930. Binary Subarrays With Sum
// Given a binary array nums and an integer goal, return the number of non-empty subarrays with a sum goal.
// A subarray is a contiguous part of the array.
// https://leetcode.com/problems/binary-subarrays-with-sum/

// The idea is to maintain prefix sum, and remember amount of each one.
// On each step, retrieve the amount for previous intervals, which is diff between current psum and psum "goal" steps before.
// +1 if current sum is also suitable

public class BinarySubarrayCounter
{
    public int Count(int[] nums, int goal)
    {
        int result = 0;
        int prefixSum = 0;

        // How many times we've seen a prefix sum. Max prefix sum == nums.Length, we need to be able to accomodate that
        int[] prefixSumCounts = new int[nums.Length + 1];

        foreach (int num in nums)
        {
            prefixSum += num;

            // Adding up previously found intervals
            if (prefixSum >= goal)
                result += prefixSumCounts[prefixSum - goal];

            // Adding up CURRENT interval
            if (prefixSum == goal)
                result += 1;

            prefixSumCounts[prefixSum]++;
        }

        return result;
    }
}
