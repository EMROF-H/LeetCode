/*
 * @lc app=leetcode.cn id=518 lang=csharp
 *
 * [518] 零钱兑换 II
 */

// @lc code=start
public class Solution
{
    public int Change(int amount, int[] coins)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;

        foreach (int coin in coins)
        {
            for (int i = coin; i <= amount; i++)
            {
                dp[i] += dp[i - coin];
            }
        }

        return dp[amount];
    }
}
// @lc code=end

