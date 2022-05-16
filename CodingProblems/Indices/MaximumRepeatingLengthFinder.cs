using System;

namespace CodingProblems.Indices;

// 718. Maximum Length of Repeated Subarray
// Given two integer arrays nums1 and nums2, return the maximum length of a subarray that appears in both arrays.
// https://leetcode.com/problems/maximum-length-of-repeated-subarray/

public class MaximumRepeatingLengthFinder
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        int maxLength = 0;
        int[][] cumulativeResult = new int[nums1.Length + 1][];

        for (int i1 = 0; i1 <= nums1.Length; i1++)
        {
            cumulativeResult[i1] = new int[nums2.Length + 1];

            for (int i2 = 0; i2 <= nums2.Length; i2++)
            {
                if (i1 == 0 || i2 == 0)
                    cumulativeResult[i1][i2] = 0;
                else if (nums1[i1 - 1] == nums2[i2 - 1])
                {
                    cumulativeResult[i1][i2] = 1 + cumulativeResult[i1 - 1][i2 - 1];
                    maxLength = Math.Max(maxLength, cumulativeResult[i1][i2]);
                }
            }
        }

        return maxLength;
    }
}
