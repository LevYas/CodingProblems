using System;
using System.Collections.Generic;

namespace CodingProblems.Indices;

// 986. Interval List Intersections
// You are given two lists of closed intervals, firstList and secondList,
//      where firstList[i] = [starti, endi] and secondList[j] = [startj, endj].
//      Each list of intervals is pairwise disjoint and in sorted order.
// Return the intersection of these two interval lists.
// A closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.
// The intersection of two closed intervals is a set of real numbers that are either empty or represented as a closed interval.
// For example, the intersection of [1, 3] and [2, 4] is [2, 3].
// https://leetcode.com/problems/interval-list-intersections/

public class IntervalIntersectionFinder
{
    public int[][] Find(int[][] firstList, int[][] secondList)
    {
        int currentIdx1 = 0;
        int currentIdx2 = 0;

        List<int[]> result = new();

        while(currentIdx1 < firstList.Length && currentIdx2 < secondList.Length)
        {
            int[] current1 = firstList[currentIdx1];
            int[] current2 = secondList[currentIdx2];

            int intervalStart = Math.Max(current1[0], current2[0]);
            int intervalEnd = Math.Min(current1[1], current2[1]);

            if (intervalEnd >= intervalStart)
                result.Add(new[] { intervalStart, intervalEnd });
            
            if (current1[1] <= current2[1])
                currentIdx1++;
            else
                currentIdx2++;
        }

        return result.ToArray();
    }
}