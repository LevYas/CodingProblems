namespace CodingProblems.Graphs;

// 287. Find the Duplicate Number
// Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.
// There is only one repeated number in nums, return this repeated number.
// You must solve the problem without modifying the array nums and uses only constant extra space.
// https://leetcode.com/problems/find-the-duplicate-number/

// I put it in the Graphs because I'd use the Floyd's "Tortoise and Hare" algorithm, that normally used for graphs
public class DuplicateNumberFinder
{
    public int FindDuplicate(int[] nums)
    {
        int tortoise = nums[0];
        int hare = nums[0];

        do
        {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        } while (tortoise != hare);

        tortoise = nums[0];

        while (tortoise != hare)
        {
            tortoise = nums[tortoise];
            hare = nums[hare];
        }

        return tortoise;
    }
}
