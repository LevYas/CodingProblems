namespace CodingProblems.Lists;

// 142. Linked List Cycle II
// Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.
// There is a cycle in a linked list if there is some node in the list that can be reached again by continuously
//      following the next pointer.
// Internally, pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed).
// It is -1 if there is no cycle. Note that pos is not passed as a parameter.
//    Do not modify the linked list.
// https://leetcode.com/problems/linked-list-cycle-ii/

public class LinkedListCycleFinder
{
    public ListNode DetectCycle(ListNode head)
    {
        ListNode hare = head;
        ListNode tortoise = head;
        
        while (hare != null && tortoise != null)
        {
            hare = hare.Next?.Next;
            tortoise = tortoise.Next;
            
            if (hare == tortoise)
                break;
        }
        
        if (hare == null || tortoise == null)
            return null;
        
        tortoise = head;
        
        while (tortoise != hare)
        {
            tortoise = tortoise.Next;
            hare = hare.Next;
        }
        
        return tortoise;
    }
}
