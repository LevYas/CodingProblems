namespace CodingProblems.Indices;

// 56. Merge Intervals
// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals,
//      and return an array of the non-overlapping intervals that cover all the intervals in the input.
// https://leetcode.com/problems/merge-intervals/

public class IntervalMerger
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1)
            return intervals;
        
        Array.Sort(intervals, (a1, a2) => a1[0].CompareTo(a2[0]));
        
        List<int[]> result = new();
        
        int start = intervals[0][0];
        int end = intervals[0][1];
        
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] > end)
            {
                result.Add(new[] {start, end});
                start = intervals[i][0];
                end = intervals[i][1];
            }
            else
                end = Math.Max(end, intervals[i][1]);
        }
        
        result.Add(new[] {start, end});
        
        return result.ToArray();
    }
}
