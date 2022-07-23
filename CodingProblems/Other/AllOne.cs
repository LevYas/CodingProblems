namespace CodingProblems.Other;

// 432. All O`one Data Structure
// Design a data structure to store the strings' count with the ability to return the strings with minimum and maximum counts.
// Implement the AllOne class:
// AllOne() Initializes the object of the data structure.
//     inc(String key) Increments the count of the string key by 1.
//          If key does not exist in the data structure, insert it with count 1.
//     dec(String key) Decrements the count of the string key by 1.
//          If the count of key is 0 after the decrement, remove it from the data structure.
//          It is guaranteed that key exists in the data structure before the decrement.
//     getMaxKey() Returns one of the keys with the maximal count. If no element exists, return an empty string "".
//     getMinKey() Returns one of the keys with the minimum count. If no element exists, return an empty string "".
//     Note that each function must run in O(1) average time complexity.
// https://leetcode.com/problems/all-oone-data-structure/

// The main idea is to have a dictionary to fast lookup and  maintain a sorted list of nodes.
// In each inc/dec we just adjusting the value and only swapping node with neighbor if needed.
// This is not 100% O(1) solution, but could be modified, so each node contain a HashSet of keys instead of 1.

public class AllOne
{
    class Node
    {
        public Node(string key, int val)
        {
            Value = val;
            Key = key;
        }
        
        public int Value;
        public string Key;
        public Node Greater;
        public Node Smaller;

        public override string ToString() => $"{Value} - {Key}";
    }
    
    private readonly Dictionary<string, Node> _keysToNodes = new();
    
    private Node _greatest;
    private Node _smallest;
    
    public void Inc(string key)
    {
        bool isNew = _keysToNodes.TryAdd(key, new Node(key, 0));
        
        Node node = _keysToNodes[key];
        node.Value++;
        
        if (isNew)
        {
            node.Greater = _smallest;
            _smallest = node;

            if (node.Greater != null)
                node.Greater.Smaller = node;
        }
        else
        {
            while (node.Greater != null && node.Value > node.Greater.Value)
                swap(node, node.Greater);
        }
        
        if (node.Greater == null)
            _greatest = node;
        else
            node.Greater.Smaller = node;
    }
    
    private void swap(Node node1, Node node2)
    {
        Node leftBound = node1.Smaller;
        Node rightBound = node2.Greater;

        node2.Smaller = leftBound;
        node2.Greater = node1;

        if (leftBound != null)
            leftBound.Greater = node2;
        else
            _smallest = node2;

        node1.Greater = rightBound;
        node1.Smaller = node2;

        if (rightBound != null)
            rightBound.Smaller = node1;
        else
            _greatest = node1;
    }
    
    public void Dec(string key)
    {
        Node node = _keysToNodes[key];
        node.Value--;
        
        if (node.Value == 0)
        {
            _keysToNodes.Remove(key);

            Node gt = node.Greater;
            Node sm = node.Smaller;

            if (sm != null)
                sm.Greater = gt;
            else // means current node is the smallest
                _smallest = gt;

            if (gt != null)
                gt.Smaller = sm;
            else // means current node is the greatest
                _greatest = sm;

            return;
        }

        while (node.Smaller != null && node.Value < node.Smaller.Value)
            swap(node.Smaller, node);
    }
    
    public string GetMaxKey() => _greatest?.Key ?? "";
    public string GetMinKey() => _smallest?.Key ?? "";
}
