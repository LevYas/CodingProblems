namespace CodingProblems.Graphs;

// You have a lock in front of you with 4 circular wheels.
//      Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'.
//      The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'.
//      Each move consists of turning one wheel one slot.

// The lock initially starts at '0000', a string representing the state of the 4 wheels.

// You are given a list of deadends dead ends, meaning if the lock displays any of these codes,
//      the wheels of the lock will stop turning and you will be unable to open it.
// Given a target representing the value of the wheels that will unlock the lock, return the minimum
//      total number of turns required to open the lock, or -1 if it is impossible.
// https://leetcode.com/problems/open-the-lock/

public class OpenLockSolver
{
    public int Solve(string[] deadends, string target)
    {
        Queue<(string, int)> nextMoves = new();
        HashSet<string> forbiddenMoves = new(deadends);

        if (forbiddenMoves.Contains("0000"))
            return -1;

        nextMoves.Enqueue(("0000", 0));

        while(nextMoves.Any())
        {
            (string current, int turnsAmount) = nextMoves.Dequeue();

            if (current == target)
                return turnsAmount;
            
            foreach (string s in calcNextMoves(current, forbiddenMoves))
                nextMoves.Enqueue((s, turnsAmount + 1));
        }
        
        return -1;
    }
    
    private static List<string> calcNextMoves(string current, HashSet<string> forbiddenMoves)
    {
        List<string> nextMoves = new();

        for (int i = 0; i < current.Length; i++)
        {
            StringBuilder sb = new(current);
            int currentNumber = current[i] - '0';
            
            int greaterNumber = currentNumber == 9 ? 0 : currentNumber + 1;
            sb[i] = (char)('0' + greaterNumber);
            tryAdd(nextMoves, forbiddenMoves, sb);
            
            int lowerNumber = currentNumber == 0 ? 9 : currentNumber - 1;
            sb[i] = (char)('0' + lowerNumber);
            tryAdd(nextMoves, forbiddenMoves, sb);
        }
        
        // Performance could be improved by sorting to prioritize the closest ones to the target
        
        return nextMoves;
    }

    private static void tryAdd(List<string> nextMoves, HashSet<string> forbiddenMoves, StringBuilder sb)
    {
        string toAdd = sb.ToString();

        if (forbiddenMoves.Contains(toAdd))
            return;

        forbiddenMoves.Add(toAdd);
        nextMoves.Add(toAdd);
    }
}