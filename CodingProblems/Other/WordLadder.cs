using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Other
{
    public static class WordLadder
    {
        // Given two words (beginWord and endWord), and a dictionary's word list, find the length of
        // shortest transformation sequence from beginWord to endWord, such that:
        // - Only one letter can be changed at a time.
        // - Each transformed word must exist in the word list.
        // https://leetcode.com/problems/word-ladder/
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return 0;

            wordList.Add(beginWord);

            // the idea is to not use O(n) list access
            string[] wordArr = wordList.ToArray();

            var distancesToWordsIds = new List<List<int>>
            {
                new List<int> { wordArr.Length - 1 }
            };

            // instead of deleting we will mark visited words
            bool[] isUsedFlags = new bool[wordArr.Length];

            // this is one-directional Dynamic Programming approach
            while (true)
            {
                var nextWords = new List<int>();

                foreach (int prevWordIdx in distancesToWordsIds.Last())
                {
                    string prevWord = wordArr[prevWordIdx];

                    for (int i = 0; i < wordArr.Length && i < isUsedFlags.Length; i++)
                    {
                        if (isUsedFlags[i])
                            continue;

                        if (!isOneLetterDiff(wordArr[i], prevWord))
                            continue;

                        if (wordArr[i] == endWord)
                            return distancesToWordsIds.Count + 1;

                        nextWords.Add(i);
                        isUsedFlags[i] = true;
                    }
                }

                if (nextWords.Count == 0)
                    return 0;

                distancesToWordsIds.Add(nextWords);
            }
        }

        private static bool isOneLetterDiff(string word1, string word2)
        {
            int diffsAmount = 0;

            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[i])
                    ++diffsAmount;

                if (diffsAmount > 1)
                    return false;
            }

            return diffsAmount == 1;
        }
    }
}
