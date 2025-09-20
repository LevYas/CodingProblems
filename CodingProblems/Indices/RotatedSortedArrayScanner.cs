
namespace CodingProblems.Indices;

// 33. Search in Rotated Sorted Array
// There is an integer array nums sorted in ascending order (with distinct values).
// Prior to being passed to your function, nums is possibly rotated at an unknown pivot
//      index k (1 <= k < nums.length) such that the resulting array is
//      [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
// For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
// Given the array nums after the possible rotation and an integer target,
//      return the index of target if it is in nums, or -1 if it is not in nums.
// You must write an algorithm with O(log n) runtime complexity.
// https://leetcode.com/problems/search-in-rotated-sorted-array/

public class RotatedSortedArrayScanner
{
    public int Search(int[] nums, int target)
    {
        int lo = 0;
        int hi = nums.Length - 1;

        int pivot = lo;

        if (nums[lo] > nums[hi]) // Equals will work when the array has length == 1
        {
            while (pivot < hi)
            {
                int mi = (hi + pivot) / 2;

                if (nums[mi] > nums[hi]) // Left side is ordered
                    pivot = mi + 1;
                else
                    hi = mi;
            }
        }

        // Now let's decide what half of the array we will scan
        if (target <= nums[^1])
        {
            lo = pivot;
            hi = nums.Length - 1;
        }
        else
        {
            lo = 0;
            hi = pivot > 0 ? pivot - 1 : 0;
        }

        if (target < nums[lo] || target > nums[hi])
            return -1;

        while (lo <= hi)
        {
            int mi = (hi + lo) / 2;

            if (nums[lo] == target)
                return lo;

            if (nums[hi] == target)
                return hi;

            if (nums[mi] == target)
                return mi;

            if (nums[mi] < target)
                lo = mi + 1;
            else
                hi = mi - 1;
        }

        return -1;
    }
}
