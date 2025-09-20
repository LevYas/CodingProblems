namespace CodingProblems.Graphs;

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

    public override string ToString() => $"{Val} ({(Left?.Val == null ? "null" : Left.Val)}, {(Right?.Val == null ? "null" : Right.Val)})";
}