/*
 * @lc app=leetcode.cn id=106 lang=c
 *
 * [106] 从中序与后序遍历序列构造二叉树
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

struct TreeNode *buildTreeNode(int *postOrder, int *inOrder, int size)
{
    if (size == 0)
        return NULL;

    struct TreeNode *result = (struct TreeNode *)malloc(sizeof(struct TreeNode));

    result->val = postOrder[size - 1];

    for (int i = 0; i < size; i++)
    {
        if (inOrder[i] == result->val)
        {
            result->left = buildTreeNode(postOrder, inOrder, i);
            result->right = buildTreeNode(postOrder + i, inOrder + i + 1, size - i - 1);
        }
    }

    return result;
}

struct TreeNode *buildTree(int *inorder, int inorderSize, int *postorder, int postorderSize)
{
    return buildTreeNode(postorder, inorder, postorderSize);
}
// @lc code=end
