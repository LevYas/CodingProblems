namespace CodingProblems.Indices;

// 676. Implement Magic Dictionary
// Design a data structure that is initialized with a list of different words.
//      Provided a string, you should determine if you can change exactly one character
//      in this string to match any word in the data structure.
// Implement the MagicDictionary class:
//      MagicDictionary() Initializes the object.
//      void buildDict(String[] dictionary) Sets the data structure with an array of distinct strings dictionary.
//      bool search(String searchWord) Returns true if you can change exactly one character in searchWord to match
//          any string in the data structure, otherwise returns false.
// https://leetcode.com/problems/implement-magic-dictionary/description/

public class MagicDictionary
{
    private string[] _dictionary;
    public void BuildDict(string[] dictionary) => _dictionary = dictionary;

    // Just check all the words with the same length char by char
    public bool Search(string searchWord)
    {
        foreach (string st in _dictionary.Where(s => s.Length == searchWord.Length))
        {
            int mismatches = 0;
            for (int i = 0; i < searchWord.Length; i++)
            {
                if (searchWord[i] != st[i])
                    mismatches++;

                if (mismatches > 1)
                    break;
            }

            if (mismatches == 1)
                return true;
        }

        return false;
    }
}
