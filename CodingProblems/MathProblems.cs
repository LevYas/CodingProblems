using System;
using System.Collections;
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

        // Daily Coding Problem: Problem #37
        // The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.
        // For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
        // You may also use a list or array to represent a set.
        public static IEnumerable<IEnumerable<int>> SetToPowerSet(IEnumerable<int> set)
        {
            List<List<int>> powerSet = new List<List<int>>();

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

        // Translation to negabinary number system, i.e.
        // 9 => 11001 (9 = 16 - 8 + 1)
        public static int[] ToNegabinary(int number)
        {
            var result = new List<int>();

            while (number != 0)
            {
                int quotient = number / -2;
                int reminder = number % -2;

                if (reminder < 0)
                {
                    quotient++;
                    reminder += 2;
                }

                number = quotient;
                result.Add(reminder);
            }

            result.Reverse();

            return result.ToArray();
        }

        public static int FromNegabinary(int[] arr)
        {
            int result = 0;

            for(int pow = 0, bitNumber = arr.Length - 1; bitNumber >= 0; --bitNumber, ++pow)
                result += arr[bitNumber] * (int)Math.Pow(-2, pow);

            return result;
        }

        public static int[] AddNegabinarySimple(int[] arr1, int[] arr2)
        {
            return ToNegabinary(FromNegabinary(arr1) + FromNegabinary(arr2));
        }

        // Adding Two Negabinary Numbers
        // Given two numbers arr1 and arr2 in base -2, return the result of adding them together.
        // Each number is given in array format:  as an array of 0s and 1s, from most significant bit to least significant bit.
        // Return the result of adding arr1 and arr2 in the same format: as an array of 0s and 1s with no leading zeros.
        // https://leetcode.com/problems/adding-two-negabinary-numbers/
        public static int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            Stack<int> result = new Stack<int>(Math.Max(arr1.Length, arr2.Length) + 1);

            int curIdx1 = arr1.Length - 1;
            int curIdx2 = arr2.Length - 1;

            int carry = 0, bit;
            int itemFrom1, itemFrom2;

            while (curIdx1 >= 0 || curIdx2 >= 0 || carry != 0)
            {
                itemFrom1 = curIdx1 >= 0 ? arr1[curIdx1--] : 0;
                itemFrom2 = curIdx2 >= 0 ? arr2[curIdx2--] : 0;

                (bit, carry) = findBitAndCarry(carry + itemFrom1 + itemFrom2);
                result.Push(bit);
            }

            while (result.Peek() == 0 && result.Count > 1)
                result.Pop();

            return result.ToArray();
        }

        private static (int, int) findBitAndCarry(int sum)
        {
            switch (sum)
            {
                case -2: return (0, 1);
                case -1: return (1, 1);
                case 0: return (0, 0);
                case 1: return (1, 0);
                case 2: return (0, -1);
                case 3: return (1, -1);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
