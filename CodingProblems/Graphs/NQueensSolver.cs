using System;
using System.Collections.Generic;

namespace CodingProblems.Graphs
{
    public static class NQueensSolver
    {
        // The n-queens puzzle is the problem of placing n queens on an n×n chessboard such 
        // that no two queens attack each other.
        // Given an integer n, return all distinct solutions to the n-queens puzzle.
        // Each solution contains a distinct board configuration of the n-queens' placement,
        // where 'Q' and '.' both indicate a queen and an empty space respectively.
        // https://leetcode.com/problems/n-queens/
        // Right answers here: https://oeis.org/A000170
        public static IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 1)
                return new List<IList<string>>() { new List<string>() { "Q" } };

            if (n == 2 || n == 3)
                return new List<IList<string>>();

            var results = new List<IList<string>>();

            solveNQueens(results, n, new List<int>());

            return results;
        }

        private static void solveNQueens(List<IList<string>> results, int n, List<int> queensIds)
        {
            if (queensIds.Count == n)
            {
                results.Add(printBoard(queensIds, n));
                return;
            }

            for (int x = 0; x < n; x++)
            {
                queensIds.Add(x);

                if (isLastQueenPlacementValid(queensIds))
                    solveNQueens(results, n, queensIds);

                queensIds.RemoveAt(queensIds.Count - 1);
            }
        }

        private static bool isLastQueenPlacementValid(List<int> queensIds)
        {
            int lastQueenY = queensIds.Count - 1;
            int lastQueenX = queensIds[lastQueenY];

            for (int y = 0; y < lastQueenY; y++)
            {
                int diff = Math.Abs(queensIds[y] - lastQueenX);

                if (diff == 0 || diff == lastQueenY - y)
                    return false;
            }

            return true;
        }

        private static IList<string> printBoard(List<int> queensIds, int n)
        {
            var rows = new List<string>(n);

            for (int y = 0; y < n; y++)
                rows.Add(new string('.', queensIds[y]) + "Q" + new string('.', n - queensIds[y] - 1));

            return rows;
        }
    }
}
