using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Indices;

// 739. Daily Temperatures
// Given an array of integers temperatures represents the daily temperatures,
// return an array answer such that answer[i] is the number of days you have
// to wait after the ith day to get a warmer temperature.
// If there is no future day for which this is possible, keep answer[i] == 0 instead.
// https://leetcode.com/problems/daily-temperatures/

public class DailyTemperaturesScanner
{
    public int[] Scan(int[] temperatures)
    {
        Stack<(int, int)> valley = new();
        int[] result = new int[temperatures.Length];
        
        valley.Push((temperatures[0], 0));

        for(int i = 1; i < temperatures.Length; i++)
        {
            while (valley.Any() && temperatures[i] > valley.Peek().Item1)
            {
                (_, int idx) = valley.Pop();
                result[idx] = i - idx;
            }

            valley.Push((temperatures[i], i));
        }

        return result;    
    }
}