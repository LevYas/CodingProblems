using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class Graphs
    {
        // Given an undirected graph, return true if and only if it is bipartite.
        // https://leetcode.com/problems/is-graph-bipartite/
        public static bool IsGraphBipartite(int[][] graph)
        {
            if (graph.Length <= 2)
                return true;

            // -1 for color1, 0 for unset, 1 for color2
            sbyte[] colors = new sbyte[graph.Length];

            for (int i = 0; i < graph.Length; ++i)
            {
                if (colors[i] == 0)
                    colors[i] = -1;

                if (!paintConnectedVertices(graph, colors, i))
                    return false;
            }

            return true;
        }

        private static bool paintConnectedVertices(int[][] graph, sbyte[] colors, int currentVrtx)
        {
            foreach (int connectedIdx in graph[currentVrtx])
            {
                if (colors[connectedIdx] == colors[currentVrtx])
                    return false;

                if (colors[connectedIdx] == 0)
                {
                    colors[connectedIdx] = (sbyte)(colors[currentVrtx] == 1 ? -1 : 1);
                    paintConnectedVertices(graph, colors, connectedIdx);
                }
            }

            return true;
        }

        // Given a set of N people (numbered 1, 2, ..., N), we would like to split everyone into two groups of any size.
        // Each person may dislike some other people, and they should not go into the same group.
        // https://leetcode.com/problems/possible-bipartition/
        public static bool PossibleBipartition(int n, int[][] dislikes)
        {
            if (dislikes.Length <= 2)
                return true;

            // -1 for color, 0 for unset, 1 for color2
            sbyte[] colors = new sbyte[n];

            Dictionary<short, List<short>> personToAllDislikes = new Dictionary<short, List<short>>(n);

            for (short i = 0; i < n; i++)
                personToAllDislikes.Add(i, new List<short>());

            foreach (int[] entry in dislikes)
            {
                short person1Idx = (short)(entry[0] - 1);
                short person2Idx = (short)(entry[1] - 1);

                personToAllDislikes[person1Idx].Add(person2Idx);
                personToAllDislikes[person2Idx].Add(person1Idx);
            }

            Queue<short> queue = new Queue<short>();

            while (personToAllDislikes.Any())
            {
                short startingIdx = personToAllDislikes.First().Key;
                colors[startingIdx] = -1;
                queue.Enqueue(startingIdx);

                while (queue.Any() && personToAllDislikes.Any())
                {
                    short idxToProcess = queue.Dequeue();
                    sbyte currentColor = colors[idxToProcess];

                    foreach (short adjacentId in personToAllDislikes[idxToProcess])
                    {
                        sbyte adjacentColor = colors[adjacentId];
                        if (adjacentColor == currentColor)
                            return false;

                        if (adjacentColor == 0)
                        {
                            colors[adjacentId] = (sbyte)(currentColor == 1 ? -1 : 1);
                            queue.Enqueue(adjacentId);
                        }
                    }

                    personToAllDislikes.Remove(idxToProcess);
                }
            }

            return true;
        }
    }

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

    public static class SudokuSolver
    {
        // Write a program to solve a Sudoku puzzle by filling the empty cells.
        // A sudoku solution must satisfy all of the following rules:
        // - Each of the digits 1-9 must occur exactly once in each row.
        // - Each of the digits 1-9 must occur exactly once in each column.
        // - Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
        // Empty cells are indicated by the character '.'.
        // https://leetcode.com/problems/sudoku-solver/
        public static void SolveSudoku(char[][] board)
        {
            trySolveSudoku(board, (0, 0));
        }

        private static bool trySolveSudoku(char[][] board, (short y, short x) startCoords)
        {
            for (short y = startCoords.y; y < 9; y++)
            {
                for (short x = startCoords.x; x < 9; x++)
                {
                    if (board[y][x] >= '1' && board[y][x] <= '9')
                        continue;

                    for (char i = '1'; i <= '9'; i++)
                    {
                        board[y][x] = i;

                        if (isDigitValid(board, (y, x)) && trySolveSudoku(board, (y, x)))
                            return true;

                        board[y][x] = '.';
                    }

                    if (board[y][x] == '.')
                        return false;
                }

                startCoords.x = 0;
            }

            return true;
        }

        private static bool isDigitValid(char[][] board, (short y, short x) coords)
        {
            char digit = board[coords.y][coords.x];

            for (short i = 0; i < 9; i++)
            {
                if (i != coords.y && board[i][coords.x] == digit)
                    return false;

                if (i != coords.x && board[coords.y][i] == digit)
                    return false;
            }

            short subGridStartX = (short)(coords.x - (coords.x % 3));
            short subGridStartY = (short)(coords.y - (coords.y % 3));

            for (short y = subGridStartY; y < subGridStartY + 3; y++)
            {
                for (short x = subGridStartX; x < subGridStartX + 3; x++)
                {
                    if (y != coords.y && x != coords.x && board[y][x] == digit)
                        return false;
                }
            }

            return true;
        }
    }
}
