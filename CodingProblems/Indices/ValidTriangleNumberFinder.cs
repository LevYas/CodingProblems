namespace CodingProblems.Indices;

// 611. Valid Triangle Number
// Given an integer array nums,
//      return the number of triplets chosen from the array that can make triangles if we take them as side lengths of a triangle.
// https://leetcode.com/problems/valid-triangle-number/

public class ValidTriangleNumberFinder
{
    public int Find(int[] nums)
    {
        Array.Sort(nums);

        int result = 0;

        if (nums.Length < 3)
            return 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] == 0)
                continue;

            int idxToStart = i + 2;

            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                int currentSum = nums[i] + nums[j];

                // sum must be qreater than third length
                // so the third length must be smaller

                idxToStart = Array.BinarySearch(nums, idxToStart, nums.Length - idxToStart, currentSum);

                if (idxToStart < 0) // If the value was not found it points to the first value larger than target
                    idxToStart = ~idxToStart;
                else
                {
                    // value is found, but we need the first value of the series
                    while (nums[idxToStart] == nums[idxToStart - 1])
                        idxToStart--;
                }

                result += idxToStart - j - 1;
            }
        }

        return result;
    }
}
