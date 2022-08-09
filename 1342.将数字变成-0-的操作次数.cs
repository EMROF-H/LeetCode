/*
 * @lc app=leetcode.cn id=1342 lang=csharp
 *
 * [1342] 将数字变成 0 的操作次数
 */

// @lc code=start
public class Solution
{
    public int NumberOfSteps(int num)
    {
        if (num == 0) return 0;
        int result = -1;
        while (num != 0)
        {
            if ((num & 1) == 1)
            {
                result++;
            }
            num >>= 1;
            result++;
        }
        return result;
    }
}
// @lc code=end

