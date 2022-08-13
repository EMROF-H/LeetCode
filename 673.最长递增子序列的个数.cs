/*
 * @lc app=leetcode.cn id=673 lang=csharp
 *
 * [673] 最长递增子序列的个数
 */

// @lc code=start
public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        var dp = new (int MaxLength, int Number)[nums.Length];
        int maxLength = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = (1, 1);
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    if (dp[i].MaxLength < dp[j].MaxLength + 1)
                    {
                        dp[i].MaxLength = dp[j].MaxLength + 1;
                        dp[i].Number = dp[j].Number;
                    }
                    else if (dp[i].MaxLength == dp[j].MaxLength + 1)
                    {
                        dp[i].Number += dp[j].Number;
                    }
                }
            }
            if (maxLength < dp[i].MaxLength)
            {
                maxLength = dp[i].MaxLength;
            }
        }
        return dp.Sum(element => element.MaxLength == maxLength ? element.Number : 0);
    }
}
// @lc code=end

