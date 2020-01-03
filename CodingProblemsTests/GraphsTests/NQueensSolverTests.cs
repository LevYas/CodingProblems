﻿using CodingProblems.Graphs;
using System.Collections.Generic;
using Xunit;

namespace CodingProblemsTests.GraphsTests
{
    public class NQueensSolverTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void SolvesNQueensPuzzle(int numberOfQueensAndSize, int solutionsAmount, IList<IList<string>> expectedBoards = null)
        {
            var result = NQueensSolver.SolveNQueens(numberOfQueensAndSize);

            Assert.Equal(solutionsAmount, result.Count);

            if (expectedBoards == null)
                return;

            for (int resultIdx = 0; resultIdx < expectedBoards.Count; resultIdx++)
            {
                for (int rowIdx = 0; rowIdx < expectedBoards[resultIdx].Count; rowIdx++)
                    Assert.Equal(expectedBoards[resultIdx][rowIdx], result[resultIdx][rowIdx]);
            }
        }

        public static object[][] TestData()
        {
            return new object[][]
            {
                new object[] { 0, 1 },
                new object[] { 1, 1, new List<IList<string>>() { new List<string>() { "Q" } } },
                new object[] { 2, 0 },
                new object[] { 3, 0 },

                new object[] { 4, 2, new List<IList<string>>()
                    {
                        new List<string>() { ".Q..", "...Q", "Q...", "..Q." },
                        new List<string>() { "..Q.", "Q...", "...Q", ".Q.." }
                    },
                },

                // Others are from: https://oeis.org/A000170
                new object[] { 5, 10 },
                new object[] { 6, 4 },
                new object[] { 7, 40 },
                new object[] { 8, 92 },
                new object[] { 9, 352 },
                new object[] { 10, 724 },
            };
        }
    }
}