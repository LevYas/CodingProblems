namespace CodingProblems.Indices;

// 647. Palindromic Substrings
// Given a string s, return the number of palindromic substrings in it.
// A string is a palindrome when it reads the same backward as forward.
// A substring is a contiguous sequence of characters within the string.
// https://leetcode.com/problems/palindromic-substrings/

public class PalindromicSubstringsCounter
{
    public int CountSubstrings(string s)
    {
        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // a letter is always a palindrome to itself
            result++;

            // try to go left and right from this point
            int l = i - 1;
            int r = i + 1;

            // expanding from one char
            while (l >= 0 && r < s.Length && s[l--] == s[r++])
                result++;

            l = i;
            r = i + 1;
            // expanding from 2 chars for even palindromes
            while (l >= 0 && r < s.Length && s[l--] == s[r++])
                result++;
        }

        return result;
    }
}
