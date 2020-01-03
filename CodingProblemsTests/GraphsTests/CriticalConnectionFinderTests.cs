using System.Collections.Generic;
using Xunit;
using CodingProblemsTests.Utility;
using FluentAssertions;
using CodingProblems.Graphs;

namespace CodingProblemsTests.GraphsTests
{
    public class CriticalConnectionFinderTests
    {
        [Theory]
        [MemberData(nameof(CriticalConnectionsTestData))]
        public void FindsCriticalConnectionsByDfs(int n, IList<IList<int>> connections, IList<IList<int>> expected)
        {
            new CriticalConnectionFinder().FindByDfs(n, connections).Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(CriticalConnectionsTestData))]
        public void FindsCriticalConnectionsByBruteForce(int n, IList<IList<int>> connections, IList<IList<int>> expected)
        {
            CriticalConnectionFinder.FindByBruteForce(n, connections).Should().BeEquivalentTo(expected);
        }

        public static TheoryData<int, IList<IList<int>>, IList<IList<int>>> CriticalConnectionsTestData()
        {
            return new TheoryData<int, IList<IList<int>>, IList<IList<int>>>
            {
                { 1, "".ToILists(), "".ToILists() },
                { 2, "[0,1]".ToILists(), "[0,1]".ToILists() },
                { 4, "[[0,1],[1,2],[2,0],[1,3]]".ToILists(), "[1,3]".ToILists() },
                { 6, "[[0,1],[1,2],[2,0],[1,3],[3,4],[4,5],[5,3]]".ToILists(), "[1,3]".ToILists() },
                { 5, "[[1,0],[2,0],[3,2],[4,2],[4,3],[3,0],[4,0]]".ToILists(), "[0,1]".ToILists() },
            };
        }
    }
}
