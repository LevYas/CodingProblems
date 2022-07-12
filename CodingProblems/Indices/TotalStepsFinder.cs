using System;
using System.Collections.Generic;

namespace CodingProblems.Indices;

// 2289. Steps to Make Array Non-decreasing
// You are given a 0-indexed integer array nums.
// In one step, remove all elements nums[i] where nums[i - 1] > nums[i] for all 0 < i < nums.length.
// Return the number of steps performed until nums becomes a non-decreasing array.
// https://leetcode.com/problems/steps-to-make-array-non-decreasing/

public class TotalStepsFinder
{
    public int TotalSteps(int[] nums)
    {
        // Monotonically decreasing stack
        // Holds (idx of the current minimum, steps to reach that minimum from the previous maximum)
        Stack<(int idx, int steps)> decreasingItemsIds = new();
        decreasingItemsIds.Push((0, 0));
        int maxSteps = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            // By default we assume that the current value is less than previous one
            int currentSteps = 1;

            // In case current value is bigger than the previous maximum, we purging the stack
            while (decreasingItemsIds.TryPeek(out (int idx, int steps) min) && nums[i] >= nums[min.idx])
            {
                // If current value is bigger than previous and previous is our starting point,
                //      it means the array is fine, and we update our starting point
                // Otherwise, we need to make one step more than saved one to reach the desired state
                // Stack purging eventually will go to earlier elements with small "steps", so we need to keep the maximum
                currentSteps = min.steps == 0 ? 0 : Math.Max(min.steps + 1, currentSteps);
                decreasingItemsIds.Pop(); // Purge "out of order" element
            }

            decreasingItemsIds.Push((i, currentSteps));
            maxSteps = Math.Max(maxSteps, currentSteps);
        }
        
        return maxSteps;
    }
}
