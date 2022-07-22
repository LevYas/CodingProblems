namespace CodingProblems.Indices;

// 2301. Match Substring After Replacement
// You are given two strings s and sub.
// You are also given a 2D character array mappings where mappings[i] = [oldi, newi] indicates
// that you may replace any number of oldi characters of sub with newi.
// Each character in sub cannot be replaced more than once.
// Return true if it is possible to make sub a substring of s by replacing zero or more characters according to mappings.
// Otherwise, return false.
// A substring is a contiguous non-empty sequence of characters within a string.
// https://leetcode.com/problems/match-substring-after-replacement/

public class ReplacedStringMatcher
{
    public bool MatchReplacement(string s, string sub, char[][] mappings)
    {
        Dictionary<char, HashSet<char>> mappingIdx = new();
        
        foreach(char[] map in mappings)
        {
            mappingIdx.TryAdd(map[0], new HashSet<char>());
            mappingIdx[map[0]].Add(map[1]);
        }
        
        bool tryMatch(int i)
        {
            for (int isub = 0; isub < sub.Length; isub++)
            {
                if (sub[isub] == s[i + isub])
                    continue;
                
                if (!mappingIdx.ContainsKey(sub[isub]))
                    return false;
                
                if (!mappingIdx[sub[isub]].Contains(s[i + isub]))
                    return false;
            }
            
            return true;
        }
            
        for(int i = 0; i <= s.Length - sub.Length; i++)
        {
            if (tryMatch(i))
                return true;
        }
        
        return false;
    }
}
