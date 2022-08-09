/*
 * @lc app=leetcode.cn id=1646 lang=csharp
 *
 * [1646] 获取生成数组中的最大值
 */

// @lc code=start
public class Solution
{
    public int GetMaximumGenerated(int n)
    {
        if (n < 2) return n;
        int[] nums = new int[n + 1];
        (nums[0], nums[1]) = (0, 1);
        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            nums[i] = nums[i >> 1] + (((i & 1) == 1) ? nums[(i >> 1) + 1] : 0);
            result = Math.Max(result, nums[i]);
        }
        return result;
    }
}
// @lc code=end

