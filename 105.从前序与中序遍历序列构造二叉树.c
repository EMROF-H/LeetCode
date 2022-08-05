/*
 * @lc app=leetcode.cn id=105 lang=c
 *
 * [105] 从前序与中序遍历序列构造二叉树
 */

#include <stdio.h>
#include <malloc.h>

struct TreeNode
{
    int val;
    struct TreeNode *left;
    struct TreeNode *right;
};

// @lc code=start
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */

struct TreeNode *buildTreeNode(int *preOrder, int *inOrder, int size)
{
    if (size == 0)
        return NULL;

    struct TreeNode *result = (struct TreeNode *)malloc(sizeof(struct TreeNode));

    result->val = preOrder[0];

    for (int i = 0; i < size; i++)
    {
        if (inOrder[i] == result->val)
        {
            result->left = buildTreeNode(preOrder + 1, inOrder, i);
            result->right = buildTreeNode(preOrder + i + 1, inOrder + i + 1, size - i - 1);
        }
    }

    return result;
}

struct TreeNode *buildTree(int *preorder, int preorderSize, int *inorder, int inorderSize)
{
    return buildTreeNode(preorder, inorder, preorderSize);
}

// @lc code=end
