namespace CodingProblems.Lists;

// 2. Add Two Numbers
// You are given two non-empty linked lists representing two non-negative integers.
// The digits are stored in reverse order, and each of their nodes contains a single digit.
// Add the two numbers and return the sum as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
// https://leetcode.com/problems/add-two-numbers/

public class AddTwoNumbersSolver
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode result = null;
        ListNode currentFromResult = null;

        ListNode current1 = l1;
        ListNode current2 = l2;

        int carry = 0;
        while (current1 != null || current2 != null)
        {
            int sum = (current1?.Val ?? 0) + (current2?.Val ?? 0) + carry;
            carry = sum / 10;

            if (currentFromResult == null)
            {
                result = new(sum % 10);
                currentFromResult = result;
            }
            else
            {
                currentFromResult.Next = new(sum % 10);
                currentFromResult = currentFromResult.Next;
            }

            current1 = current1?.Next;
            current2 = current2?.Next;
        }

        if (carry == 1)
            currentFromResult.Next = new(1);

        return result;
    }
}
