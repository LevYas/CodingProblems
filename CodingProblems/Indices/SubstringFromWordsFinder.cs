namespace CodingProblems.Indices;

// 30. Substring with Concatenation of All Words
// You are given a string s and an array of strings words. All the strings of words are of the same length.
// A concatenated substring in s is a substring that contains all the strings of any permutation of words concatenated.
// For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab"
//      are all concatenated strings.
//      "acdbef" is not a concatenated substring because it is not the concatenation of any permutation of words.
// Return the starting indices of all the concatenated substrings in s. You can return the answer in any order.
// https://leetcode.com/problems/substring-with-concatenation-of-all-words/

public class SubstringFromWordsFinder
{
    private class ResettableCounter
    {
        public int Current;
        public int Initially;

        public void Reset() => Current = Initially;
    }

    public IList<int> FindSubstring(string s, string[] words)
    {
        List<int> result = new();
        int wordLen = words[0].Length;

        Dictionary<string, ResettableCounter> wordsToCount = new();

        foreach (string word in words)
        {
            wordsToCount.TryAdd(word, new());
            wordsToCount[word].Current++;
            wordsToCount[word].Initially++;
        }

        void resetCounters()
        {
            foreach (var kvp in wordsToCount)
                kvp.Value.Reset();
        }

        for (int i = 0; i <= s.Length - wordLen * words.Length; i++)
        {
            if (i > 0)
                resetCounters();

            bool found = true;

            for (int j = 0; j < wordLen * words.Length; j += wordLen)
            {
                string sub = s.Substring(i + j, wordLen);

                if (!wordsToCount.ContainsKey(sub) || wordsToCount[sub].Current == 0)
                {
                    found = false;
                    break;
                }

                wordsToCount[sub].Current--;
            }

            if (found)
                result.Add(i);
        }

        return result;
    }
}
