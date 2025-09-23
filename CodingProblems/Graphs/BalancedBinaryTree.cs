namespace CodingProblems.Graphs;

// 110. Balanced Binary Tree [Easy]
// Given a binary tree, determine if it is height-balanced.
// A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.
// https://leetcode.com/problems/balanced-binary-tree/description/

public class BalancedBinaryTree
{
    public static bool IsBalanced(TreeNode root)
    {
        bool result = true;
        getDepth(root, ref result);

        return result;
    }

    private static int getDepth(TreeNode node, ref bool result)
    {
        if (node == null || !result)
            return 0;

        int lDepth = getDepth(node.Left, ref result);
        int rDepth = getDepth(node.Right, ref result);

        if (Math.Abs(lDepth - rDepth) > 1)
            result = false;

        return Math.Max(lDepth, rDepth) + 1;
    }
}
