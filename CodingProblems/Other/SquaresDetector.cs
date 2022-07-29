namespace CodingProblems.Other;

// 2013. Detect Squares
// You are given a stream of points on the X-Y plane. Design an algorithm that:
// Adds new points from the stream into a data structure. Duplicate points are allowed and should be treated as different points.
//     Given a query point, counts the number of ways to choose three points from the data structure
//          such that the three points and the query point form an axis-aligned square with positive area.
//     An axis-aligned square is a square whose edges are all the same length and are either parallel
//          or perpendicular to the x-axis and y-axis.
// 
// Implement the DetectSquares class:
//      DetectSquares() Initializes the object with an empty data structure.
//      void add(int[] point) Adds a new point point = [x, y] to the data structure.
//      int count(int[] point) Counts the number of ways to form axis-aligned squares with point point = [x, y] as described above.

// https://leetcode.com/problems/detect-squares/

public class SquaresDetector
{
    private readonly Dictionary<(int x, int y), int> _counts = new();
    private readonly Dictionary<int, HashSet<(int x, int y)>> _xIdx = new();
    
    public void Add(int[] point)
    {
        _xIdx.TryAdd(point[0], new());
        _xIdx[point[0]].Add((point[0], point[1]));
        
        _counts.TryAdd((point[0], point[1]), 0);
        _counts[(point[0], point[1])]++;
    }
    
    public int Count(int[] point)
    {
        if (!_xIdx.TryGetValue(point[0], out var xMatch))
            return 0;

        int count = 0;

        foreach ((int x, int y) matchPt in xMatch)
        {
            int side = Math.Abs(point[1] - matchPt.y);

            if (side == 0)
                continue;

            count += countRects(point, matchPt, matchPt.x - side);
            count += countRects(point, matchPt, matchPt.x + side);
        }

        return count;
    }

    private int countRects(int[] point, (int x, int y) ptWithSameX, int targetX)
    {
        (int x, int y) diagonalPt = (targetX, ptWithSameX.y);

        if (!_xIdx.TryGetValue(diagonalPt.x, out var xSet)
            || !xSet.Contains(diagonalPt)
            || !xSet.TryGetValue((diagonalPt.x, point[1]), out var rightPt))
            return 0;

        return _counts[ptWithSameX] * _counts[diagonalPt] * _counts[rightPt];
    }
}
