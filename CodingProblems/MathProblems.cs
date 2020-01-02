using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public static class MathProblems
    {
        // Daily Coding Problem: Problem #70 [Easy]
        // A number is considered perfect if its digits sum up to exactly 10.
        // Given a positive integer n, return the n-th perfect number.
        // For example, given 1, you should return 19. Given 2, you should return 28.
        public static int CalcNthPerfectNumber(int n)
        {
            return (int)Math.Pow(10, n / 10 + 1) + (n % 10 + n / 10) * 9;
        }

        // Daily Coding Problem: Problem #14
        // The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method. 
        // Hint: The basic equation of a circle is x2 + y2 = r2.
        public static double CalcPiUsingMonteCarlo()
        {
            const double radius = 0.5;
            int insidePtsAmount = 0;
            const int totalPoints = (int)1e8;

            Random rnd = new Random();

            for (int i = 0; i < totalPoints; ++i)
            {
                double x = rnd.NextDouble() - 0.5;
                double y = rnd.NextDouble() - 0.5;

                if (Math.Sqrt(x * x + y * y) < radius)
                    insidePtsAmount++;
            }

            double area = insidePtsAmount / ((double)totalPoints);
            return area / (radius * radius);
        }

        // Subsets (Daily Coding Problem: Problem #37)
        // The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.
        // For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
        // You may also use a list or array to represent a set.
        // https://leetcode.com/problems/subsets/
        public static IList<IList<int>> SetToPowerSet(IEnumerable<int> set)
        {
            List<IList<int>> powerSet = new List<IList<int>>();

            foreach (int elem in set)
            {
                var newElems = new List<List<int>>();

                foreach (List<int> subset in powerSet)
                {
                    var newSubset = subset.ToList();
                    newSubset.Add(elem);
                    newElems.Add(newSubset);
                }

                powerSet.Add(new List<int> { elem });

                if (newElems.Any())
                    powerSet.AddRange(newElems);
            }

            powerSet.Add(new List<int>());
            return powerSet;
        }

        private struct ChessCoord
        {
            public int Row;
            public int Column;

            public ChessCoord(int row, int column) => (Row, Column) = (row, column);

            public bool IsInsideTheBoard(int boardSize) => Row >= 0 && Column >= 0 && Row < boardSize && Column < boardSize;

            public static ChessCoord operator +(ChessCoord p1, ChessCoord p2) => new ChessCoord(p1.Row + p2.Row, p1.Column + p2.Column);

            public override string ToString() => $"row {Row}, col {Column}";
        }

        // Knight Probability in Chessboard
        // On an NxN chessboard, a knight starts at the r-th row and c-th column and attempts to make exactly K moves. 
        // Each time the knight is to move, it chooses one of eight possible moves uniformly at random
        //      (even if the piece would go off the chessboard) and moves there.
        // The knight continues moving until it has made exactly K moves or has moved off the chessboard.
        // Return the probability that the knight remains on the board after it has stopped moving.
        // https://leetcode.com/problems/knight-probability-in-chessboard/
        public static double CalcKnightProbability(int boardSize, int movesAmount, int startRow, int startColumn)
        {
            ChessCoord[] moveOptions = new[] { new ChessCoord(1, 2), new ChessCoord(-1, 2),
                                          new ChessCoord(2, 1), new ChessCoord(2, -1),
                                          new ChessCoord(-1, -2), new ChessCoord(1, -2),
                                          new ChessCoord(-2, -1), new ChessCoord(-2, 1)};

            // the snapshots of probabilities for each cell for the current and the next moves
            double[][,] boardSnapshots = new double[][,] { new double[boardSize, boardSize], new double[boardSize, boardSize] };

            int curIdx = 0; // the switchable "pointers" to the appropriate boards
            int nextIdx = 1;

            // before the 1st move knight is on the starting cell with 100% probability
            boardSnapshots[curIdx][startRow, startColumn] = 1;

            for (int moveIdx = 0; moveIdx < movesAmount; moveIdx++)
            {
                forEachCell(boardSize, (row, col) =>
                {
                    double sourceValue = boardSnapshots[curIdx][row, col];

                    if (sourceValue == 0)
                        return;

                    boardSnapshots[curIdx][row, col] = 0;

                    foreach (ChessCoord moveOption in moveOptions)
                    {
                        var resPos = new ChessCoord(row, col) + moveOption;

                        if (resPos.IsInsideTheBoard(boardSize))
                            boardSnapshots[nextIdx][resPos.Row, resPos.Column] += sourceValue / 8; // 8 possible moves from each pos
                    }
                });

                (curIdx, nextIdx) = (nextIdx, curIdx);
            }

            double totalProbability = 0;

            forEachCell(boardSize, (row, col) =>
                totalProbability += boardSnapshots[curIdx][row, col]);

            return totalProbability;
        }

        private static void forEachCell(int size, Action<int, int> action)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    action(j, i);
                }
            }
        }
    }
}
