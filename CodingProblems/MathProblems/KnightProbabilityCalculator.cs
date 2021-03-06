﻿using System;

namespace CodingProblems.MathProblems
{
    public static class KnightProbabilityCalculator
    {
        // Knight Probability in Chessboard
        // On an NxN chessboard, a knight starts at the r-th row and c-th column and attempts to make exactly K moves. 
        // Each time the knight is to move, it chooses one of eight possible moves uniformly at random
        //      (even if the piece would go off the chessboard) and moves there.
        // The knight continues moving until it has made exactly K moves or has moved off the chessboard.
        // Return the probability that the knight remains on the board after it has stopped moving.
        // https://leetcode.com/problems/knight-probability-in-chessboard/
        public static double CalcKnightProbability(int boardSize, int movesAmount, int startRow, int startColumn)
        {
            ChessCoord[] moveOptions = { new ChessCoord(1, 2), new ChessCoord(-1, 2),
                                          new ChessCoord(2, 1), new ChessCoord(2, -1),
                                          new ChessCoord(-1, -2), new ChessCoord(1, -2),
                                          new ChessCoord(-2, -1), new ChessCoord(-2, 1)};

            // the snapshots of probabilities for each cell for the current and the next moves
            double[][,] boardSnapshots = { new double[boardSize, boardSize], new double[boardSize, boardSize] };

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
                        ChessCoord resPos = new ChessCoord(row, col) + moveOption;

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

        private struct ChessCoord
        {
            public int Row;
            public int Column;

            public ChessCoord(int row, int column) => (Row, Column) = (row, column);

            public bool IsInsideTheBoard(int boardSize) => Row >= 0 && Column >= 0 && Row < boardSize && Column < boardSize;

            public static ChessCoord operator +(ChessCoord p1, ChessCoord p2) => new ChessCoord(p1.Row + p2.Row, p1.Column + p2.Column);

            public override string ToString() => $"row {Row}, col {Column}";
        }
    }
}
