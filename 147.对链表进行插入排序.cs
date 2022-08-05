using System.Diagnostics.Tracing;
/*
 * @lc app=leetcode.cn id=147 lang=csharp
 *
 * [147] 对链表进行插入排序
 */

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

internal static class Program
{
    static void Main(string[] args)
    {
        ListNode head = new(4, new(2, new(1, new(3))));
        head = new Solution().InsertionSortList(head);
    }
}

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
    public ListNode InsertionSortList(ListNode head)
    {
        ListNode resultFather = new(next: head);
        head = head.next;
        resultFather.next.next = null;

        while (head != null)
        {
            ListNode nodeFather;
            for (nodeFather = resultFather; true; nodeFather = nodeFather.next)
            {
                if (nodeFather.next == null) break;
                if (nodeFather.next.val > head.val) break;
            }

            ListNode resultNext = nodeFather.next;
            ListNode headNext = head.next;
            nodeFather.next = head;
            nodeFather.next.next = resultNext;
            head = headNext;
        }

        return resultFather.next;
    }
}
// @lc code=end

