using CodingProblems.Graphs;
using FluentAssertions;
using System;
using Xunit;

namespace CodingProblemsTests.Graphs;

public class RoomVisitor_CanVisitAllRooms
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Works(int[][] rooms, bool expected)
    {
        bool result = new RoomVisitor().CanVisitAllRooms(rooms);

        result.Should().Be(expected);
    }

    public static TheoryData<int[][], bool> Data
        => new()
        {
            {
                new[] { new[] { 1 }, new[] { 2 }, new[] { 3 }, Array.Empty<int>() },
                true
            },
            {
                new[] { new[] { 1, 3 }, new[] { 3, 0, 1 }, new[] { 2 }, new[] { 0 } },
                false
            },
        };
}
