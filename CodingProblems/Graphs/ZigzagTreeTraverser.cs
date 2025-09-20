namespace CodingProblems.Graphs;

// 103. Binary Tree Zigzag Level Order Traversal
// Given the root of a binary tree, return the zigzag level order traversal of its nodes' values.
//      (i.e., from left to right, then right to left for the next level and alternate between).
// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/

public class ZigzagTreeTraverser
{
    public IList<IList<int>> Traverse(TreeNode root)
    {
        List<IList<int>> result = new();

        if (root == null)
            return result;

        List<TreeNode> toProcess = new() { root };
        bool toRight = true;

        while (toProcess.Any())
        {
            List<int> currentResultLevel = new();

            List<TreeNode> nodesToProcessNext = new();

            foreach (TreeNode node in toProcess.Where(n => n != null))
            {
                nodesToProcessNext.Add(node.Left);
                nodesToProcessNext.Add(node.Right);

                if (toRight)
                    currentResultLevel.Add(node.Val);
                else
                    currentResultLevel.Insert(0, node.Val);
            }

            if (currentResultLevel.Any())
                result.Add(currentResultLevel);

            toRight = !toRight;
            toProcess = nodesToProcessNext;
        }

        return result;
    }
}
