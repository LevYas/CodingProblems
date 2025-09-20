namespace CodingProblemsTests.Graphs;

public class ItineraryReconstructor_FindItinerary
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Works(string[][] tickets, string[] expected)
    {
        ItineraryReconstructor sut = new();
        var ticketList = tickets.Select(a => (IList<string>)a.ToList()).ToList();

        IList<string> result = sut.FindItinerary(ticketList);

        result.Should().Equal(expected);
    }

    public static TheoryData<string[][], string[]> Data
        => new()
        {
            {
                new[] { new[] { "JFK", "KUL" } },
                new[] { "JFK","KUL" }
            },
            {
                new[] { new[] { "MUC","LHR" }, new[] { "JFK","MUC" }, new[] { "SFO","SJC" }, new[] { "LHR","SFO" } },
                new[] { "JFK","MUC","LHR","SFO","SJC" }
            },
            {
                new[] { new[] { "JFK","SFO" }, new[] { "JFK","ATL" }, new[] { "SFO","ATL" }, new[] { "ATL","JFK" }, new[] { "ATL","SFO" } },
                new[] { "JFK","ATL","JFK","SFO","ATL","SFO" }
            },
            {
                new[] { new[] { "JFK","KUL" }, new[] { "JFK","NRT" }, new[] { "NRT","JFK" } },
                new[] { "JFK","NRT","JFK","KUL" }
            },
            {
                new[] { new[] { "EZE","TIA" }, new[] { "EZE","HBA" }, new[] { "AXA","TIA" }, new[] { "JFK","AXA" },
                    new[] { "ANU","JFK" }, new[] { "ADL","ANU" }, new[] { "TIA","AUA" }, new[] { "ANU","AUA" },
                    new[] { "ADL","EZE"}, new[] { "ADL","EZE"},new[] { "EZE","ADL"},new[] { "AXA","EZE"},new[] { "AUA","AXA"},
                    new[] { "JFK","AXA"},new[] { "AXA","AUA"},new[] { "AUA","ADL"},new[] { "ANU","EZE"},new[] { "TIA","ADL"},
                    new[] { "EZE","ANU"},new[] { "AUA","ANU"} },
                new[] { "JFK","AXA","AUA","ADL","ANU","AUA","ANU","EZE","ADL","EZE","ANU","JFK","AXA","EZE","TIA","AUA","AXA","TIA","ADL","EZE","HBA" }
            },
        };
}
