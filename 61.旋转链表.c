/*
 * @lc app=leetcode.cn id=61 lang=c
 *
 * [61] 旋转链表
 */

#include <stdint.h>

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

struct ListNode *rotateRight(struct ListNode *head, int k)
{
    if (head == NULL || k == 0)
        return head;
    struct ListNode *next = head;
    uint16_t n = 0;
    while (next->next)
    {
        next = next->next;
        n++;
    }
    next->next = head;
    k %= n + 1;
    k = n - k;
    while (k--)
    {
        head = head->next;
    }
    struct ListNode *result = head->next;
    head->next = NULL;
    return result;
}
// @lc code=end
