using CodingProblems.Graphs;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Graphs
{
    public class NQueensSolver_SolveNQueens
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void SolvesNQueensPuzzle(int numberOfQueensAndSize, int solutionsAmount, IList<IList<string>> expectedBoards = null)
        {
            IList<IList<string>> result = NQueensSolver.SolveNQueens(numberOfQueensAndSize);

            Assert.Equal(solutionsAmount, result.Count);

            if (expectedBoards == null)
                return;

            for (int resultIdx = 0; resultIdx < expectedBoards.Count; resultIdx++)
            {
                for (int rowIdx = 0; rowIdx < expectedBoards[resultIdx].Count; rowIdx++)
                    result[resultIdx][rowIdx].Should().Be(expectedBoards[resultIdx][rowIdx]);
            }
        }

        public static object[][] TestData()
        {
            return new[]
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
