namespace CodingProblems.Lists;

// 234. Palindrome Linked List
// Given the head of a singly linked list, return true if it is a palindrome.
//https://leetcode.com/problems/palindrome-linked-list/

public class PalindromeListChecker
{
    public bool IsPalindrome(ListNode head)
    {
        if (head.Next == null) // one element only, it's a palindrome
            return true;

        ListNode current = head;
        int itemsCount = 0;

        // we don't really need this loop. Instead, we can use fast and slow pointers in the next loop
        while (current != null)
        {
            itemsCount++;
            current = current.Next;
        }

        if (itemsCount == 2)
            return head.Val == head.Next.Val;

        current = head.Next;
        ListNode next = head.Next;
        ListNode prev = head;

        for (int i = 1; i < itemsCount / 2; i++)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        ListNode currentToLeft;
        ListNode currentToRight = next;

        //    0  1  2  3
        //    1<-2  2->1
        // c        ^
        // n        ^
        // p     ^
        if (itemsCount % 2 == 0)
            currentToLeft = prev;

        //    0  1  2  3  4  5  6
        //    1<-2<-3  4->3->2->1
        // c           ^
        // n           ^
        // p        ^
        else
            currentToLeft = new(next.Val, prev);

        while (currentToRight != null)
        {
            if (currentToLeft.Val != currentToRight.Val)
                return false;

            currentToLeft = currentToLeft.Next;
            currentToRight = currentToRight.Next;
        }

        return true;
    }
}
