namespace CodingProblems.Indices;

// 5. Longest Palindromic Substring
// Given a string s, return the longest palindromic substring in s.
// https://leetcode.com/problems/longest-palindromic-substring/

public class LongestPalindromicSubstringFinder
{
    public string Find(string s)
    {
        // The main idea is to try to go left and right from the center. Center can consist of 1 or 2 characters
        string result = s[..1];

        // In THEORY, we may reduce it to one FOR loop, but conditions of defining hi and lo getting very complicated
        // So, I'll keep it conceptually simple

        // First, scan for all EVEN palindromes
        for (int i = 0; i < s.Length; i++)
        {
            int nextIdx = i + 1;

            if (nextIdx >= s.Length || s[nextIdx] != s[i])
                continue;

            int lo = i;
            int hi = nextIdx;

            while (lo >= 0 && hi < s.Length && s[lo] == s[hi])
            {
                if (hi - lo + 1 > result.Length)
                    result = s[lo..(hi + 1)];
                lo--;
                hi++;
            }
        }

        // Next, scan for ODD palindromes
        for (int i = 1; i < s.Length; i++)
        {
            int lo = i - 1;
            int hi = i + 1;

            while (lo >= 0 && hi < s.Length && s[lo] == s[hi])
            {
                if (hi - lo + 1 > result.Length)
                    result = s[lo..(hi + 1)];
                lo--;
                hi++;
            }
        }

        return result;
    }
}
