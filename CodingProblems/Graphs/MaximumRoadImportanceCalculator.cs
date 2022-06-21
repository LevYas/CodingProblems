using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Graphs;

// 2285. Maximum Total Importance of Roads
// You are given an integer n denoting the number of cities in a country. The cities are numbered from 0 to n - 1.

// You are also given a 2D integer array roads where roads[i] = [ai, bi] denotes that there exists
//      a bidirectional road connecting cities ai and bi.
// You need to assign each city with an integer value from 1 to n, where each value can only be used once.
// The importance of a road is then defined as the sum of the values of the two cities it connects.
// Return the maximum total importance of all roads possible after assigning the values optimally.
// https://leetcode.com/problems/maximum-total-importance-of-roads/

public class MaximumRoadImportanceCalculator
{
    public long Calculate(int n, int[][] roads)
    {
        int[] roadsFromCity = new int[n];

        foreach(int[] road in roads)
        {
            roadsFromCity[road[0]]++;
            roadsFromCity[road[1]]++;
        }

        IEnumerable<int> sortedCities = roadsFromCity
            .Select((connections, idx) => (idx, connections))
            .OrderByDescending(tuple => tuple.connections)
            .Select(tuple => tuple.idx);
        
        int[] cityValues = new int[n];
        
        foreach(int city in sortedCities)
            cityValues[city] = n--;

        long result = 0;
        
        foreach(int[] road in roads)
            result += cityValues[road[0]] + cityValues[road[1]];

        return result;
    }
}
