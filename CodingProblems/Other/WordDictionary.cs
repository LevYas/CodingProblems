namespace CodingProblems.Other;

// 211. Design Add and Search Words Data Structure
// Design a data structure that supports adding new words and finding if a string matches any previously added string.
// Implement the WordDictionary class:
//      WordDictionary() Initializes the object.
//      void addWord(word) Adds word to the data structure, it can be matched later.
//      bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise.
//          word may contain dots '.' where dots can be matched with any letter.
// https://leetcode.com/problems/design-add-and-search-words-data-structure/

public class WordDictionary
{
    private class Node
    {
        public readonly Dictionary<char, Node> Children = new();
        public bool IsTheEndOfWord;
    }

    private readonly Node _root = new();

    public void AddWord(string word)
    {
        Node current = _root;
        
        foreach (char c in word)
        {
            current.Children.TryAdd(c, new Node());
            current = current.Children[c];
        }

        current.IsTheEndOfWord = true;
    }
    
    public bool Search(string word) => tryMatch(_root, word, 0);

    private static bool tryMatch(Node currentNode, string word, int currentCharIdx)
    {
        if (currentCharIdx == word.Length)
            return currentNode.IsTheEndOfWord;

        if (currentNode.Children.TryGetValue(word[currentCharIdx], out Node childNode))
            return tryMatch(childNode, word, currentCharIdx + 1);

        if (word[currentCharIdx] != '.')
            return false;

        foreach (Node node in currentNode.Children.Values)
        {
            if (tryMatch(node, word, currentCharIdx + 1))
                return true;
        }

        return false;
    }
}
