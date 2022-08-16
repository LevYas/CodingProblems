namespace CodingProblems.Indices;

// 3. Longest Substring Without Repeating Characters
// Given a string s, find the length of the longest substring without repeating characters.
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        int lo = 0;
        int longestLength = 0;
        HashSet<char> currentChars = new();

        for (int hi = 0; hi < s.Length; hi++)
        {
            if (currentChars.Add(s[hi]))
            {
                longestLength = Math.Max(longestLength, hi - lo + 1);
            }
            else
            {
                // delete elements until we find the same
                while (s[lo] != s[hi])
                    currentChars.Remove(s[lo++]);

                // and skip the same
                lo++;
            }
        }

        return longestLength;
    }
}
