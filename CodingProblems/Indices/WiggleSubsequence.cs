namespace CodingProblems.Indices;

// 376. Wiggle Subsequence
// A wiggle sequence is a sequence where the differences between successive numbers strictly
//      alternate between positive and negative. The first difference (if one exists) may be either positive or negative.
//      A sequence with one element and a sequence with two non-equal elements are trivially wiggle sequences.
// For example, [1, 7, 4, 9, 2, 5] is a wiggle sequence because the differences (6, -3, 5, -7, 3) alternate between positive and negative.
//    In contrast, [1, 4, 7, 2, 5] and [1, 7, 4, 5, 5] are not wiggle sequences.
//      The first is not because its first two differences are positive, and the second is not because its last difference is zero.
//    A subsequence is obtained by deleting some elements (possibly zero) from the original sequence,
//      leaving the remaining elements in their original order.
//
//    Given an integer array nums, return the length of the longest wiggle subsequence of nums.
// https://leetcode.com/problems/wiggle-subsequence/submissions/914823913/

public class WiggleSubsequence
{
    // 1. Filter out all the duplicates
    // 2. Calculate all the differences
    // 3. Count the amount of alternations
    public int GetMaxLength(int[] nums)
    {
        List<int> filtered = new() { nums[0] };

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
                filtered.Add(nums[i]);
        }

        if (filtered.Count == 1)
            return 1;

        int[] diffs = new int[filtered.Count - 1];

        for (int i = 0; i < diffs.Length; i++)
            diffs[i] = filtered[i + 1] - filtered[i];

        int result = 2;

        for (int i = 0; i < diffs.Length - 1; i++)
        {
            if (diffs[i] < 0 && diffs[i + 1] > 0 || diffs[i] > 0 && diffs[i + 1] < 0)
                result++;
        }

        return result;
    }
}
