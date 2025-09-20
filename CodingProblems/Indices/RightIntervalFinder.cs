namespace CodingProblems.Indices;

// 436. Find Right Interval
// You are given an array of intervals, where intervals[i] = [starti, endi] and each starti is unique.
// The right interval for an interval i is an interval j such that startj >= endi and startj is minimized. Note that i may equal j.
// Return an array of right interval indices for each interval i. If no right interval exists for interval i, then put -1 at index i.
// https://leetcode.com/problems/find-right-interval/

public class RightIntervalFinder
{
    public int[] FindRightInterval(int[][] intervals)
    {
        int[] starts = new int[intervals.Length];
        Dictionary<int, int> startToIdx = new();

        for (int i = 0; i < intervals.Length; i++)
        {
            starts[i] = intervals[i][0];
            startToIdx.Add(intervals[i][0], i);
        }

        Array.Sort(starts);

        int[] result = new int[intervals.Length];

        for (int i = 0; i < intervals.Length; i++)
        {
            int idx = Array.BinarySearch(starts, intervals[i][1]);

            if (idx < 0)
                idx = ~idx;

            result[i] = idx >= starts.Length ? -1 : startToIdx[starts[idx]];
        }

        return result;
    }
}
