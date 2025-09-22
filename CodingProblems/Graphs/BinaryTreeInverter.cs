namespace CodingProblems.Graphs;

// 226. Invert Binary Tree
// Given the root of a binary tree, invert the tree, and return its root.
// https://leetcode.com/problems/invert-binary-tree/description/

public static class BinaryTreeInverter
{
    public static TreeNode InvertBinaryTree(TreeNode root)
    {
        invertNode(root);
        return root;
    }

    private static void invertNode(TreeNode node)
    {
        if (node == null)
            return;

        invertNode(node.Left);
        invertNode(node.Right);

        if (node.Left != null || node.Right != null)
        {
            (node.Left, node.Right) = (node.Right, node.Left);
        }
    }
}
