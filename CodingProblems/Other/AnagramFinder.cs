namespace CodingProblems.Other;

public static class AnagramFinder
{
    // Given two strings s and p, return an array of all the start indices of p's anagrams in s.
    // You may return the answer in any order.
    // An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
    //      typically using all the original letters exactly once.
    // https://leetcode.com/problems/find-all-anagrams-in-a-string/
    public static IList<int> FindAnagrams(string s, string p)
    {
        List<int> result = new();

        if (p.Length > s.Length)
            return result;

        int[] counters = new int[26];
        int[] targetCounters = new int[26];

        foreach (char c in p)
            targetCounters[getCounterIdx(c)]++;

        foreach (char c in s.AsSpan()[..(p.Length - 1)])
            counters[getCounterIdx(c)]++;

        for (int i = 0; i + p.Length <= s.Length; i++)
        {
            if (i > 0)
                counters[getCounterIdx(s[i - 1])]--;

            counters[getCounterIdx(s[i + p.Length - 1])]++;

            if (areCountersMatch(targetCounters, counters))
                result.Add(i);
        }

        return result;
    }

    private static int getCounterIdx(char c) => c - 'a';

    private static bool areCountersMatch(int[] targetCounters, int[] counters)
    {
        for (int i = 0; i < targetCounters.Length; i++)
        {
            if (targetCounters[i] != counters[i])
                return false;
        }

        return true;
    }
}