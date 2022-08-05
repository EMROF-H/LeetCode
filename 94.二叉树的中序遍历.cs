/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
 */

using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}


// @lc code=start

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new();
        InorderTraversalNode(root);
        return result;

        void InorderTraversalNode(TreeNode node)
        {
            if (node == null) return;
            InorderTraversalNode(node.left);
            result.Add(node.val);
            InorderTraversalNode(node.right);
        }
    }
}
// @lc code=end
