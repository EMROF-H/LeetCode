/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
 */

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
    public IList<int> PostorderTraversal(TreeNode root)
    {
        List<int> result = new();
        PostorderTraversalNode(root);
        return result;

        void PostorderTraversalNode(TreeNode node)
        {
            if (node == null) return;
            PostorderTraversalNode(node.left);
            PostorderTraversalNode(node.right);
            result.Add(node.val);
        }
    }
}
// @lc code=end

