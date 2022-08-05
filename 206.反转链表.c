/*
 * @lc app=leetcode.cn id=206 lang=c
 *
 * [206] 反转链表
 */

#include <stddef.h>

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

struct ListNode *reverseList(struct ListNode *head)
{
    struct ListNode *result = NULL;
    while (head)
    {
        struct ListNode *buffer = head->next;
        head->next = result;
        result = head;
        head = buffer;
    }
    return result;
}
// @lc code=end
