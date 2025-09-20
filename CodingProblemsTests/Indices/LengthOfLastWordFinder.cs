namespace CodingProblemsTests.Indices;

// 58. Length of Last Word
// Given a string s consisting of words and spaces, return the length of the last word in the string.
// A word is a maximal substring consisting of non-space characters only.
// https://leetcode.com/problems/length-of-last-word/

public class LengthOfLastWordFinder
{
    public int FindLength(string s)
    {
        int wordEndIdx = -1;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ' && wordEndIdx == -1)
                continue;

            if (wordEndIdx == -1)
                wordEndIdx = i;

            if (s[i] == ' ')
                return wordEndIdx - i;

            if (i == 0)
                return wordEndIdx + 1;
        }

        return -1;
    }
}
