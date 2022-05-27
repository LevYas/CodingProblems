using System;

namespace CodingProblems.Indices;

// 324. Wiggle Sort II
// Given an integer array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....
// You may assume the input array always has a valid answer.
// https://leetcode.com/problems/wiggle-sort-ii/

public class WiggleSorter
{
    public void WiggleSort(int[] nums)
    {
        if (nums.Length < 2)
            return;

        int[] counts = new int[5001];

        int maxVal = 0;
        int minVal = Int32.MaxValue;

        foreach (int i in nums)
        {
            counts[i]++;

            maxVal = Math.Max(maxVal, i);
            minVal = Math.Min(minVal, i);
        }

        int idx = 1;
        bool isSecondPass = false;

        for (int i = maxVal; i >= minVal; i--)
        {
            while (counts[i] > 0 && idx < nums.Length)
            {
                nums[idx] = i;
                idx += 2;
                counts[i]--;

                if (idx >= nums.Length && !isSecondPass)
                {
                    idx = 0;
                    isSecondPass = true;
                }
            }
        }
    }
}
