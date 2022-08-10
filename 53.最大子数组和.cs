/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子数组和
 */

// @lc code=start
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int preSum = 0;
        int maxSum = int.MinValue;
        foreach (int num in nums)
        {
            preSum = Math.Max(preSum + num, num);
            maxSum = Math.Max(maxSum, preSum);
        }
        return maxSum;
    }
}
// @lc code=end

