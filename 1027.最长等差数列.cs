/*
 * @lc app=leetcode.cn id=1027 lang=csharp
 *
 * [1027] 最长等差数列
 */

// @lc code=start
public class Solution
{
    public int LongestArithSeqLength(int[] nums)
    {
        const int DifferAbsMax = 500;
        const int DifferNumber = 2 * DifferAbsMax + 1;

        int[,] dp = new int[nums.Length, DifferNumber];
        int resultMinus1 = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int differMoved = nums[i] - nums[j] + DifferAbsMax;
                dp[i, differMoved] = dp[j, differMoved] + 1;
                resultMinus1 = Math.Max(resultMinus1, dp[i, differMoved]);
            }
        }
        return resultMinus1 + 1;
    }
}
// @lc code=end

