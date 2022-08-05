/*
 * @lc app=leetcode.cn id=143 lang=csharp
 *
 * [143] 重排链表
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

public static class ListNodeExtensions
{
    public static ListNode? NullableIndex(this ListNode node, int index = 1)
    {
        ListNode? result = node;
        for (int i = 0; i < index; i++)
        {
            if (result == null) throw new Exception("An empty node is indexed.");
            result = result.next;
        }
        return result;
    }

    public static ListNode Index(this ListNode node, int index = 1)
    {
        ListNode result = node;
        for (int i = 0; i < index; i++)
        {
            if (result.next == null) throw new Exception("An empty node is indexed.");
            result = result.next;
        }
        return result;
    }

    public static ListNode End(this ListNode node)
    {
        while (node.next != null) { node = node.next; }
        return node;
    }

    public static ListNode Insert(this ListNode node, ListNode item)
    {
        item.End().next = node.next;
        node.next = item;
        return node;
    }

    public static ListNode Delete(this ListNode node, int number = 1)
    {
        node.next = node.NullableIndex(number + 1);
        return node;
    }
}

public class Solution
{
    public void ReorderList(ListNode head)
    {
        head.Insert(new(10086, new(1235))).Index(3).Insert(new(888888)).Index();
    }
}

// @lc code=end

