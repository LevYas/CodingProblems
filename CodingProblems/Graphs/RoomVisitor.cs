namespace CodingProblems.Graphs;

// 841. Keys and Rooms
// There are n rooms labeled from 0 to n - 1 and all the rooms are locked except for room 0.
// Your goal is to visit all the rooms. However, you cannot enter a locked room without having its key.
// When you visit a room, you may find a set of distinct keys in it. Each key has a number on it, denoting
//      which room it unlocks, and you can take all of them with you to unlock the other rooms.
// Given an array rooms where rooms[i] is the set of keys that you can obtain if you visited room i,
// return true if you can visit all the rooms, or false otherwise.
// https://leetcode.com/problems/keys-and-rooms/

public class RoomVisitor
{
    public bool CanVisitAllRooms(int[][] rooms)
    {
        HashSet<int> visited = new() { 0 };
        visitRooms(rooms[0], rooms, visited);

        for (int i = 0; i < rooms.Length; i++)
        {
            if (!visited.Contains(i))
                return false;
        }

        return true;
    }

    private static void visitRooms(int[] keys, int[][] rooms, HashSet<int> visited)
    {
        foreach (int key in keys)
        {
            if (visited.Contains(key))
                continue;

            visited.Add(key);
            visitRooms(rooms[key], rooms, visited);
        }
    }
}