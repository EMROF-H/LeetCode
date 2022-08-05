using System.Threading;
using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
 */

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
 *         this`.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> result = new();
        PreorderTraversalNode(root);
        return result;

        void PreorderTraversalNode(TreeNode node)
        {
            if (node == null) return;
            result.Add(node.val);
            PreorderTraversalNode(node.left);
            PreorderTraversalNode(node.right);
        }
    }
}
// @lc code=end

