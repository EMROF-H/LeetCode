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
        List<int> dp = new();
        dp.Add(nums[0]);

        foreach (var i in nums)
        {
            int left = 0, right = dp.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (dp[mid] < i)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            if (left == dp.Count)
            {
                dp.Add(i);
            }
            else
            {
                dp[left] = i;
            }
        }

        return dp.Count;
    }
}
// @lc code=end

public class SolutionNSquare
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