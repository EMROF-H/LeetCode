/*
 * @lc app=leetcode.cn id=300 lang=csharp
 *
 * [300] 最长递增子序列
 */

// @lc code=start
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int[] dpMaxLength = new int[nums.Length];
        int result = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            int maxLength = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    maxLength = Math.Max(maxLength, dpMaxLength[j] + 1);
                }
            }
            dpMaxLength[i] = maxLength;
            result = Math.Max(result, dpMaxLength[i]);
        }
        return result;
    }
}
// @lc code=end

