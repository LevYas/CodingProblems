namespace CodingProblems.Graphs;

// 572. Subtree of Another Tree
// Given the roots of two binary trees root and subRoot,
//      return true if there is a subtree of root with the same
//      structure and node values of subRoot and false otherwise.
// A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants.
// The tree tree could also be considered as a subtree of itself.
// https://leetcode.com/problems/subtree-of-another-tree/

public class SubtreeFinder
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        Queue<TreeNode> nodesToScan = new();
        
        nodesToScan.Enqueue(root);
        
        while(nodesToScan.Any())
        {
            TreeNode current = nodesToScan.Dequeue();
            
            if (current == null)
                continue;
            
            if (current.Val == subRoot.Val && areEqual(current, subRoot))
                return true;
            
            nodesToScan.Enqueue(current.Left);
            nodesToScan.Enqueue(current.Right);
        }
        
        return false;
    }
    
    private bool areEqual(TreeNode root, TreeNode subRoot)
    {
        Queue<(TreeNode, TreeNode)> nodesToCheck = new();
        
        nodesToCheck.Enqueue((root, subRoot));
        
        while(nodesToCheck.Any())
        {
            (TreeNode lhs, TreeNode rhs) = nodesToCheck.Dequeue();
            
            if (lhs == null && rhs == null)
                continue;
            
            if (lhs == null || rhs == null || lhs.Val != rhs.Val)
                return false;
            
            nodesToCheck.Enqueue((lhs.Left, rhs.Left));
            nodesToCheck.Enqueue((lhs.Right, rhs.Right));
        }
        
        return true;
    }
}
