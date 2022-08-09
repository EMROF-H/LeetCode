/*
 * @lc app=leetcode.cn id=213 lang=csharp
 *
 * [213] 打家劫舍 II
 */

// @lc code=start
public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
        return Math.Max(Dp(nums, 0, nums.Length - 2), Dp(nums, 1, nums.Length - 1));
    }

    public int Dp(int[] nums, int start, int end)
    {
        var last = (nums[start], Math.Max(nums[start], nums[start + 1]));
        for (int i = start + 2; i <= end; i++)
        {
            last = (last.Item2, Math.Max(last.Item1 + nums[i], last.Item2));
        }
        return last.Item2;
    }
}
// @lc code=end

