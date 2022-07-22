namespace CodingProblems.Indices;

// 169. Majority Element
// Given an array nums of size n, return the majority element.
// The majority element is the element that appears more than n/2 times. You may assume that the majority element always exists in the array.
// https://leetcode.com/problems/majority-element/

public class MajorityElementFinder
{
    public int Find(int[] nums)
    {
        int candidate = 0;
        int counter = 0;
        
        foreach (int t in nums)
        {
            if (counter == 0)
                candidate = t;

            counter += t == candidate ? 1 : -1;
        }
        
        return candidate;
    }
}
