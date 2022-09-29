/*
 * @lc app=leetcode.cn id=354 lang=csharp
 *
 * [354] 俄罗斯套娃信封问题
 */

// @lc code=start
public class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (a, b) =>
        {
            if (a[0] == b[0]) return b[1] - a[1];
            else return a[0] - b[0];
        });

        int[] dp = new int[envelopes.Length];
        dp[0] = envelopes[0][1];
        int result = 1;
        for (int i = 1; i < envelopes.Length; i++)
        {
            int left = 0, right = result;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (dp[mid] < envelopes[i][1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            if (left == result)
            {
                result++;
            }
            dp[left] = envelopes[i][1];
        }
        return result;
    }
}
// @lc code=end

