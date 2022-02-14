using System;

namespace CodingProblems.Graphs;

// The thief has found himself a new place for his thievery again. There is only one entrance to this area, called root.

// Besides the root, each house has one and only one parent house.
// After a tour, the smart thief realized that all houses in this place form a binary tree.
// It will automatically contact the police if two directly-linked houses were broken into on the same night.

// Given the root of the binary tree, return the maximum amount of money the thief can rob without alerting the police.
// https://leetcode.com/problems/house-robber-iii/

public class HouseRobberIIISolver
{
    public int Solve(TreeNode root)
    {
        (int maxIfLevelRobbed, int maxIfNot) = calcProfit(root);
        return Math.Max(maxIfLevelRobbed, maxIfNot);
    }

    private static (int maxIfLevelRobbed, int maxIfNot) calcProfit(TreeNode node)
    {
        if (node.Left == null && node.Right == null)
            return (node.Val, 0);

        (int maxIfLevelRobbed, int maxIfNot) leftProfit = node.Left != null ? calcProfit(node.Left) : (0, 0);
        (int maxIfLevelRobbed, int maxIfNot) rightProfit = node.Right != null ? calcProfit(node.Right) : (0, 0);

        // if we decide to rob, we have a limited choice
        int ifRobLevel = leftProfit.maxIfNot + rightProfit.maxIfNot + node.Val;

        // if not, we can pick the max but we can't use current value
        int ifNot = Math.Max(leftProfit.maxIfNot, leftProfit.maxIfLevelRobbed) +
                    Math.Max(rightProfit.maxIfNot, rightProfit.maxIfLevelRobbed);

        return (ifRobLevel, ifNot);
    }
}

public class TreeNode
{
    public readonly int Val;
    public TreeNode Left;
    public TreeNode Right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}