using CodingProblems.Other;
using System;
using System.Collections.Generic;
using CodingProblemsTests.Utility;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class CinemaSeatAllocator_MaxNumberOfFamilies
    {
        [Theory]
        [MemberData(nameof(CinemaSeatAllocatorTestData))]
        public void WorksCorrectly(int numberOfRows, int[][] reservedSeats, int expected)
        {
            CinemaSeatAllocator.MaxNumberOfFamilies(numberOfRows, reservedSeats).Should().Be(expected);
        }

        public static TheoryData<int, int[][], int> CinemaSeatAllocatorTestData
            => new TheoryData<int, int[][], int>
            {
                { 2, "[1,1],[2,6],[1,3]".ToArrays(), 2 },
                { 1, Array.Empty<int[]>(), 2 },
                { 1, "[1,2],[1,3],[1,4],[1,5],[1,6],[1,7],[1,8],[1,9]".ToArrays(), 0 },
                { 1, "[1,2],[1,3],[1,4],[1,5],[1,6],[1,7],[1,8]".ToArrays(), 0 },
                { 1, "[1,2],[1,3],[1,4],[1,5],[1,6],[1,7]".ToArrays(), 0 },
                { 1, "[1,2],[1,3],[1,4],[1,5],[1,6]".ToArrays(), 0 },
                { 1, "[1,2],[1,3],[1,4],[1,5]".ToArrays(), 1 },
                { 1, "[1,3],[1,4],[1,5],[1,6],[1,7],[1,8],[1,9]".ToArrays(), 0 },
                { 1, "[1,4],[1,5],[1,6],[1,7],[1,8],[1,9]".ToArrays(), 0 },
                { 1, "[1,5],[1,6],[1,7],[1,8],[1,9]".ToArrays(), 0 },
                { 1, "[1,6],[1,7],[1,8],[1,9]".ToArrays(), 1 },
                { 1, "[1,2],[1,3],[1,8],[1,9]".ToArrays(), 1 },
                { 1, "[1,2],[1,9]".ToArrays(), 1 },
                { 1, "[1,3],[1,8]".ToArrays(), 1 },
                { 11, "[11,2],[11,8]".ToArrays(), 21 },
            };

        [Fact]
        public void WorksTillTheLimits()
        {
            const int numberOfRows = 1000_000_000;
            var seats = new List<int[]>();

            for (int i = 1000000; i < numberOfRows; i++)
            {
                if (seats.Count >= 1000)
                    break;

                for (int j = 1; j <= 10; j++)
                    seats.Add(new[] {i + 1, j});
            }

            CinemaSeatAllocator.MaxNumberOfFamilies(numberOfRows, seats.ToArray()).Should().BePositive();
        }
    }
}
