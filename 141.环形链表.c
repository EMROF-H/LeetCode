/*
 * @lc app=leetcode.cn id=141 lang=c
 *
 * [141] 环形链表
 */

#include <stdio.h>
#include <stdbool.h>

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
bool hasCycle(struct ListNode *head)
{
    struct ListNode *fastNode = head;
    struct ListNode *slowNode = head;

    while (fastNode != NULL && fastNode->next != NULL)
    {
        fastNode = fastNode->next->next;
        slowNode = slowNode->next;

        if (fastNode == slowNode)
            return true;
    }

    return false;
}
// @lc code=end
