/*
 * @lc app=leetcode.cn id=516 lang=csharp
 *
 * [516] 最长回文子序列
 */

// @lc code=start
public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        int[,] dp = new int[s.Length, s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = 1;
        }

        for (int i = s.Length - 2; i >= 0; i--)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[0, s.Length - 1];
    }
}
// @lc code=end

