namespace CodingProblems.Indices;

// 28. Implement strStr()
// Implement strStr().
// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack,
//      or -1 if needle is not part of haystack.
//   Clarification:
// What should we return when needle is an empty string? This is a great question to ask during an interview.
// For the purpose of this problem, we will return 0 when needle is an empty string.
// This is consistent to C's strstr() and Java's indexOf().
// https://leetcode.com/problems/implement-strstr/

public class SubstringFinder
{
    public int StrStr(string haystack, string needle)
    {
        if (String.IsNullOrEmpty(needle))
            return 0;
        
        for(int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack[i] != needle[0])
                continue;
            
            int j = 1;
            
            for(; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j])
                    break;
            }
            
            if (j == needle.Length)
                return i;
            
        }
        
        return -1;
    }
}
