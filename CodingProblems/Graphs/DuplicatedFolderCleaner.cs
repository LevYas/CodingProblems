namespace CodingProblems.Graphs;

// 1948. Delete Duplicate Folders in System
// Due to a bug, there are many duplicate folders in a file system. You are given a 2D array paths,
//      where paths[i] is an array representing an absolute path to the ith folder in the file system.
// For example, ["one", "two", "three"] represents the path "/one/two/three".
// 
// Two folders (not necessarily on the same level) are identical
//      if they contain the same non-empty set of identical subfolders and underlying subfolder structure.
// The folders do not need to be at the root level to be identical.
// If two or more folders are identical, then mark the folders as well as all their subfolders.
// 
// For example, folders "/a" and "/b" in the file structure below are identical. They (as well as their subfolders) should all be marked:
//     /a
//     /a/x
//     /a/x/y
//     /a/z
//     /b
//     /b/x
//     /b/x/y
//     /b/z
// However, if the file structure also included the path "/b/w", then the folders "/a" and "/b" would not be identical.
// Note that "/a/x" and "/b/x" would still be considered identical even with the added folder.
// Once all the identical folders and their subfolders have been marked, the file system will delete all of them.
// The file system only runs the deletion once, so any folders that become identical after the initial deletion are not deleted.
// 
// Return the 2D array ans containing the paths of the remaining folders after deleting all the marked folders.
// The paths may be returned in any order.
// https://leetcode.com/problems/delete-duplicate-folders-in-system/

public class DuplicatedFolderCleaner
{
    private class Node
    {
        public Node(string key) => Key = key;

        public readonly string Key;
        public readonly SortedDictionary<string, Node> Children = new();
        public bool ToDelete;
    }

    private readonly Dictionary<string, Node> _pathToVisitedNode = new();

    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        Node root = new("/");

        foreach (IList<string> folders in paths)
            addFolder(root, folders);

        markDuplicates(root);

        List<List<string>> survived = new();

        foreach (Node child in root.Children.Values)
            collectSurvivedPaths(child, survived, new List<string>());

        return survived.Cast<IList<string>>().ToList();
    }

    private static void addFolder(Node root, IList<string> hierarchy)
    {
        Node current = root;

        foreach (string folder in hierarchy)
        {
            current.Children.TryAdd(folder, new Node(folder));
            current = current.Children[folder];
        }
    }

    private string markDuplicates(Node node)
    {
        string result = "";

        if (node.Children.Count == 0)
            return result;

        foreach ((string key, Node childNode) in node.Children)
            result += "(" + key + markDuplicates(childNode) + ")";

        if (_pathToVisitedNode.TryGetValue(result, out Node seenNode))
            seenNode.ToDelete = node.ToDelete = true;
        else
            _pathToVisitedNode.Add(result, node);

        return result;
    }

    private static void collectSurvivedPaths(Node node, List<List<string>> survived, List<string> currentPath)
    {
        if (node.ToDelete)
            return;

        currentPath.Add(node.Key);
        survived.Add(new List<string>(currentPath));

        foreach (Node child in node.Children.Values)
            collectSurvivedPaths(child, survived, currentPath);

        currentPath.RemoveAt(currentPath.Count - 1);
    }
}
