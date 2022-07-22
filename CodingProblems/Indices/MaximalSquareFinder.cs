namespace CodingProblems.Indices;

// 221. Maximal Square
// Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
// https://leetcode.com/problems/maximal-square/

public class MaximalSquareFinder
{
    public int FindMaxSquare(char[][] matrix)
    {
        int[][] dp = new int[matrix.Length][];        
        int side = 0;
        
        for (int y = 0; y < matrix.Length; y++)
        {
            dp[y] = new int[matrix[y].Length];
            
            for (int x = 0; x < matrix[y].Length; x++)
            {
                if (matrix[y][x] == '0')
                    continue;
                
                dp[y][x] = 1;
                
                if (x == 0 || y == 0)
                {
                    if (side < 1)
                        side = 1;
                    
                    continue;
                }

                int neighborLeft = dp[y][x - 1];
                int neighborUp = dp[y - 1][x];
                int neighborUpLeft = dp[y - 1][x - 1];
                
                int minNeighbor = Math.Min(neighborUpLeft, Math.Min(neighborLeft, neighborUp));
                int newSide = minNeighbor + 1;
                
                dp[y][x] = newSide;
                
                if (newSide > side)
                    side = newSide;
            }            
        }
        
        return side * side;
    }
}