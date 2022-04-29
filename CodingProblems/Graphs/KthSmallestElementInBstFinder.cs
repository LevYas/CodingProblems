namespace CodingProblems.Graphs;

// 230. Kth Smallest Element in a BST
// Given the root of a binary search tree, and an integer k,
// return the kth smallest value (1-indexed) of all the values of the nodes in the tree.
// https://leetcode.com/problems/kth-smallest-element-in-a-bst/

public class KthSmallestElementInBstFinder
{
    public int FindKthSmallest(TreeNode root, int k)
    {
        int current = 0;
        return traverse(root, k, ref current).Val;
    }
    
    private TreeNode traverse(TreeNode node, int k, ref int current)
    {
        if (node == null)
            return null;
        
        TreeNode left = traverse(node.Left, k, ref current);
        
        if (left != null)
            return left;
        
        if (++current == k)
            return node;
        
        return traverse(node.Right, k, ref current);
    }
}