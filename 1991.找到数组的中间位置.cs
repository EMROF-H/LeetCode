/*
 * @lc app=leetcode.cn id=1991 lang=csharp
 *
 * [1991] 找到数组的中间位置
 */

// @lc code=start
public class Solution
{
    public int FindMiddleIndex(int[] nums)
    {
        int sum = nums.Sum();

        int currentSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (currentSum * 2 + nums[i] == sum) return i;
            currentSum += nums[i];
        }
        return -1;
    }
}
// @lc code=end

public class Solution1
{
    public int FindMiddleIndex(int[] nums)
    {
        int[] sum = new int[nums.Length + 1];

        sum[0] = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum[i + 1] = sum[i] + nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (2 * sum[i] + nums[i] == sum[^1]) return i;
        }
        return -1;
    }
}