using System.Diagnostics.CodeAnalysis;

namespace CodingProblems.Lists;

// 382. Linked List Random Node
// Given a singly linked list, return a random node's value from the linked list. Each node must have the same probability of being chosen.
// Implement the Solution class:
// Solution(ListNode head) Initializes the object with the head of the singly-linked list head.
// int getRandom() Chooses a node randomly from the list and returns its value. All the nodes of the list should be equally likely to be chosen.
// https://leetcode.com/problems/linked-list-random-node/

public class LinkedListRandomNodeSolver
{
    private readonly Random _random = new();
    private readonly ListNode _head;
    private int? _count;

    public LinkedListRandomNodeSolver(ListNode head) => _head = head;

    public int GetRandom()
    {
        int rndIdx = _random.Next(_count ?? 10000);

        if (tryGetValue(rndIdx, out int lastIdx, out int? value))
            return value.Value;

        _count = lastIdx;
        rndIdx %= lastIdx;

        if (tryGetValue(rndIdx, out _, out value))
            return value.Value;

        throw new InvalidOperationException("Should not reach");
    }

    private bool tryGetValue(int idx, out int counter, [NotNullWhen(true)] out int? value)
    {
        counter = 0;
        value = null;
        ListNode current = _head;

        while (current != null)
        {
            if (counter == idx)
            {
                value = current.Val;
                return true;
            }

            counter++;
            current = current.Next;
        }

        return false;
    }
}
