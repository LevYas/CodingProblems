using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Graphs;

// 331. Verify Preorder Serialization of a Binary Tree
// One way to serialize a binary tree is to use preorder traversal. When we encounter a non-null node, we record the node's value.
// If it is a null node, we record using a sentinel value such as '#'.
// For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#", where '#' represents a null node.
// Given a string of comma-separated values preorder, return true if it is a correct preorder traversal serialization of a binary tree.
// It is guaranteed that each comma-separated value in the string must be either an integer or a character '#' representing null pointer.

// You may assume that the input format is always valid.
// For example, it could never contain two consecutive commas, such as "1,,3".
//     Note: You are not allowed to reconstruct the tree.
// https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/

public class PreorderVerifier
{
    public bool IsValidSerialization(string preorder)
    {
        Stack<(string val, bool isLeftVisited, bool isRightVisited)> currentBranch = new();

        string[] tokens = preorder.Split(",");
        
        if (tokens[0] != "#")
            currentBranch.Push((tokens[0], false, false));

        for(int i = 1; i < tokens.Length; i++)
        {
            if (!currentBranch.Any())
                return false;
            
            var parent = currentBranch.Pop();

            if (!parent.isLeftVisited)
                parent.isLeftVisited = true;
            else if (!parent.isRightVisited)
                parent.isRightVisited = true;

            currentBranch.Push(parent);
            
            if (tokens[i] != "#")
                currentBranch.Push((tokens[i], false, false));
            else
            {
                while (currentBranch.Any() && parent.isLeftVisited && parent.isRightVisited)
                {
                    currentBranch.Pop();
                    currentBranch.TryPeek(out parent);
                }
            }            
        }

        return !currentBranch.Any();
    }
}
