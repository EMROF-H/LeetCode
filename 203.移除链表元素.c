/*
 * @lc app=leetcode.cn id=203 lang=c
 *
 * [203] 移除链表元素
 */

#include <stdio.h>

struct ListNode
{
    int val;
    struct ListNode *next;
};

// @lc code=start
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */

struct ListNode *removeElements(struct ListNode *head, int val)
{
    if (head == NULL)
        return NULL;

    struct ListNode result;
    result.next = head;
    head = &result;

    while (head->next)
    {
        if (head->next->val == val)
        {
            head->next = head->next->next;
        }
        else
        {
            head = head->next;
        }
    }
    return result.next;
}
// @lc code=end
