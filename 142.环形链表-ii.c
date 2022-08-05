/*
 * @lc app=leetcode.cn id=142 lang=c
 *
 * [142] 环形链表 II
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
struct ListNode *detectCycle(struct ListNode *head)
{
    struct ListNode *fastNode = head;
    struct ListNode *slowNode = head;

    while (fastNode != NULL && fastNode->next != NULL)
    {
        fastNode = fastNode->next->next;
        slowNode = slowNode->next;

        if (fastNode == slowNode)
        {
            struct ListNode *detectNode = head;
            while (slowNode != detectNode)
            {
                slowNode = slowNode->next;
                detectNode = detectNode->next;
            }
            return detectNode;
        }
    }

    return NULL;
}
// @lc code=end
