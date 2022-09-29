/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 */

// @lc code=start
public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];

        for (int i = 1; i <= amount; i++)
        {
            dp[i] = -1;
            for (int j = 0; j < coins.Length; j++)
            {
                if (i >= coins[j])
                {
                    int x = dp[i - coins[j]];
                    if (x != -1)
                    {
                        if (dp[i] == -1) dp[i] = x + 1;
                        else dp[i] = Math.Min(dp[i], x + 1);
                    }
                }
            }
        }

        return dp[amount];
    }
}
// @lc code=end

