namespace CodingProblems.Graphs;

// Given the root of a binary tree, flatten the tree into a "linked list":
// The "linked list" should use the same TreeNode class where the right child pointer
//      points to the next node in the list and the left child pointer is always null.
// The "linked list" should be in the same order as a pre-order traversal of the binary tree.
// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/

public class FlattenBinaryTreeToLinkedList
{
    public void Flatten(TreeNode root)
    {
        flatten(root);
    }

    TreeNode flatten(TreeNode node)
    {
        if (node == null)
            return null;

        TreeNode left = node.Left;
        TreeNode right = node.Right;

        TreeNode leftTail = flatten(node.Left);
        TreeNode rightTail = flatten(node.Right);

        TreeNode connectTo = node;
        TreeNode overallTail = node;

        connectTo.Left = null;

        if (leftTail != null)
        {
            connectTo.Right = left;
            connectTo = leftTail;
            overallTail = leftTail;
        }

        if (rightTail != null)
        {
            connectTo.Right = right;
            overallTail = rightTail;
        }

        return overallTail;
    }
}
