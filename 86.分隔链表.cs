/*
 * @lc app=leetcode.cn id=86 lang=csharp
 *
 * [86] 分隔链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode Partition(ListNode head, int x)
    {
        if (head == null) return null;

        ListNode resultFather = new(next: head);
        ListNode insertionPoint = null;

        ListNode lessThanXHead = new();
        ListNode lessThanX = lessThanXHead;
        for (ListNode node = resultFather; node != null && node.next != null;)
        {
            if(insertionPoint != null)
            {
                if (node.next.val < x)
                {
                    lessThanX.next = node.next;
                    node.next = node.next.next;
                    lessThanX = lessThanX.next;
                    lessThanX.next = null;
                    continue;
                }
            }
            else
            {
                if (node.next.val >= x)
                {
                    insertionPoint = node;
                }
            }
            node = node.next;
        }

        if(insertionPoint != null)
        {
            lessThanX.next = insertionPoint.next;
            insertionPoint.next = lessThanXHead.next;
        }

        return resultFather.next;
    }
}
// @lc code=end

