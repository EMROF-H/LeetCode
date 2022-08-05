using System;
/*
 * @lc app=leetcode.cn id=829 lang=csharp
 *
 * [829] 连续整数求和
 */

// @lc code=start
public class Solution
{
    public int ConsecutiveNumbersSum(int n)
    {
        int result = 0;
        for (int d = 0; d < Math.Sqrt(2 * n); d++)
        {
            if ((2 * n) % (d + 1) != 0) continue;
            int buffer = (2 * n) / (d + 1) - d;
            if (buffer <= 0 || buffer % 2 != 0) continue;
            result++;
        }
        return result;
    }
}
// @lc code=end

