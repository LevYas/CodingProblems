namespace CodingProblems.Sorting;

// 215. Kth Largest Element in an Array
// Given an integer array nums and an integer k, return the kth largest element in the array.
// Note that it is the kth largest element in the sorted order, not the kth distinct element.
// https://leetcode.com/problems/kth-largest-element-in-an-array/

public class KthLargestElementFinder
{
    private readonly Random _random = new();

    public int FindKthLargestViaQuickselect(int[] nums, int k)
    {
        int lo = 0, hi = nums.Length - 1;

        int targetIdx = nums.Length - k;

        while (lo != hi)
        {
            int pivotIdx = partition(nums, lo, hi);

            if (pivotIdx == targetIdx)
                return nums[pivotIdx];

            if (pivotIdx < targetIdx)
                lo = pivotIdx + 1;
            else
                hi = pivotIdx - 1;
        }

        return nums[targetIdx];
    }

    private int partition(int[] nums, int lo, int hi)
    {
        // pick pivot randomly
        int randomIdx = _random.Next(lo + 1, hi + 1);
        (nums[lo], nums[randomIdx]) = (nums[randomIdx], nums[lo]);

        int i = lo;
        int j = hi + 1;

        // now we can use the 1st element as a pivot
        while (true)
        {
            while (nums[++i] < nums[lo] && i != hi);
            while (nums[--j] > nums[lo] && j != lo);
            
            if (j <= i)
                break;

            (nums[j], nums[i]) = (nums[i], nums[j]);
        }

        (nums[lo], nums[j]) = (nums[j], nums[lo]);

        return j;
    }

    public int FindKthLargestViaPq(int[] nums, int k)
    {
        PriorityQueue<int, int> buffer = new(k);

        foreach (int num in nums)
        {
            if (buffer.Count < k)
            {
                buffer.Enqueue(num, num);
                continue;
            }

            if (num > buffer.Peek())
                buffer.EnqueueDequeue(num, num);
        }

        return buffer.Peek();
    }
}
