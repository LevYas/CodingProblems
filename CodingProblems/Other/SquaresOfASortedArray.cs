using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Other;

// Given an integer array nums sorted in non-decreasing order, return an array of the squares
// of each number sorted in non-decreasing order.
// https://leetcode.com/problems/squares-of-a-sorted-array/
public class SquaresOfASortedArray
{
    public int[] SolveSortedSquares(int[] nums)
    {
        Stack<int> negatives = new();
        List<int> result = new();

        foreach (int num in nums)
        {
            int currentSq = num * num;

            if (num < 0)
            {
                negatives.Push(currentSq);
                continue;
            }

            while (negatives.Any() && negatives.Peek() <= currentSq)
                result.Add(negatives.Pop());

            result.Add(currentSq);
        }

        while (negatives.Any())
            result.Add(negatives.Pop());

        return result.ToArray();
    }
}