using System;

namespace CodingProblems.Indices;

// Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.
// Return the sum of the three integers.
// You may assume that each input would have exactly one solution.
// https://leetcode.com/problems/3sum-closest/

public class ThreeSumClosestSolver
{
    public int Solve(int[] nums, int target)
    {
        int closestSum = 0;
        int smallestDiff = Int32.MaxValue;
        Array.Sort(nums);
        
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int startIdx = i + 1;
            int endIdx = nums.Length - 1;
            
            while (startIdx != endIdx)
            {
                int sum = nums[i] + nums[startIdx] + nums[endIdx];
                int diff = Math.Abs(target - sum);
                
                if (diff < smallestDiff)
                {
                    smallestDiff = diff;
                    closestSum = sum;
                }
                
                if (sum > target)
                    endIdx--;
                else
                    startIdx++;
            }
        }
        
        return closestSum;
    }
}