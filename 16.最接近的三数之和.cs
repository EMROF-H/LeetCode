/*
 * @lc app=leetcode.cn id=16 lang=csharp
 *
 * [16] 最接近的三数之和
 */

// @lc code=start
public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int errorResult = int.MaxValue;

        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1, k = nums.Length - 1; j < k;)
            {
                int error = nums[i] + nums[j] + nums[k] - target;
                if (error == 0)
                {
                    return target;
                }
                else if (error < 0)
                {
                    j++;
                }
                else
                {
                    k--;
                }
                if (Math.Abs(errorResult) > Math.Abs(error)) errorResult = error;
            }
        }
        return target + errorResult;
    }
}
// @lc code=end

