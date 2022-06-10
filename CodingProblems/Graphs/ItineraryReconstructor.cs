using System.Collections.Generic;

namespace CodingProblems.Graphs;

// 332. Reconstruct Itinerary
// You are given a list of airline tickets where tickets[i] = [fromi, toi]
//      represent the departure and the arrival airports of one flight.
//
// Reconstruct the itinerary in order and return it.
// 
// All of the tickets belong to a man who departs from "JFK", thus, the itinerary must begin with "JFK".
//      If there are multiple valid itineraries, you should return the itinerary that has the smallest
//      lexical order when read as a single string.
// 
// For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
// You may assume all tickets form at least one valid itinerary. You must use all the tickets once and only once.
// https://leetcode.com/problems/reconstruct-itinerary/ 

public class ItineraryReconstructor
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        Dictionary<string, SortedSet<string>> ticketsIndex = new();
        Dictionary<(string, string), int> ticketsLeft = new();
        
        foreach (IList<string> ticket in tickets)
        {
            ticketsIndex.TryAdd(ticket[0], new SortedSet<string>());
            ticketsIndex[ticket[0]].Add(ticket[1]);

            ticketsLeft.TryAdd((ticket[0], ticket[1]), 0);
            ticketsLeft[(ticket[0], ticket[1])] += 1;
        }

        List<string> itinerary = new() { "JFK" };
        int ticketsAmount = tickets.Count;

        findItinerary(ticketsIndex, ticketsLeft, itinerary, ticketsAmount);

        return itinerary;
    }

    private bool findItinerary(Dictionary<string, SortedSet<string>> tickets, Dictionary<(string, string), int> ticketsLeft,
        List<string> itinerary, int ticketsAmount)
    {
        if (ticketsAmount == 0)
            return true;

        string current = itinerary[^1];

        if (!tickets.ContainsKey(current))
            return false;

        foreach (string nextAirport in tickets[current])
        {
            if (ticketsLeft[(current, nextAirport)] < 1)
                continue;

            ticketsLeft[(current, nextAirport)]--;
            itinerary.Add(nextAirport);
            ticketsAmount--;

            if (findItinerary(tickets, ticketsLeft, itinerary, ticketsAmount))
                return true;

            ticketsAmount++;
            itinerary.RemoveAt(itinerary.Count - 1);
            ticketsLeft[(current, nextAirport)]++;
        }

        return false;
    }
}
