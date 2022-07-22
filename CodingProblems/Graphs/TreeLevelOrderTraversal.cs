namespace CodingProblems.Graphs;

// 102. Binary Tree Level Order Traversal
// Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
// https://leetcode.com/problems/binary-tree-level-order-traversal/

public class TreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        // The key idea is that current queue is one level
        // We go through one level, prepare the next, swap in the end of iteration

        List<IList<int>> result = new();
        
        if (root == null)
            return result;
        
        Queue<TreeNode> toProcess = new();
        Queue<TreeNode> temp = new();
        
        toProcess.Enqueue(root);
        
        while(toProcess.Any())
        {
            List<int> currentLevel = new();
            
            while(toProcess.Any())
            {
                TreeNode current = toProcess.Dequeue();
                currentLevel.Add(current.Val);
                
                if (current.Left != null)
                    temp.Enqueue(current.Left);
                
                if (current.Right != null)
                    temp.Enqueue(current.Right);
            }
            
            result.Add(currentLevel);
            toProcess = temp;
            temp = new();
        }
        
        return result;
    }
}
