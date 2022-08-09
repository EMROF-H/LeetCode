/*
 * @lc app=leetcode.cn id=198 lang=csharp
 *
 * [198] 打家劫舍
 */

// @lc code=start

public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        nums[1] = Math.Max(nums[0], nums[1]);
        for (int i = 2; i < nums.Length; i++)
        {
            nums[i] = Math.Max(nums[i] + nums[i - 2], nums[i - 1]);
        }
        return nums[^1];
    }
}
// @lc code=end

