/*
 * @lc app=leetcode.cn id=62 lang=csharp
 *
 * [62] 不同路径
 */

// @lc code=start
public static class Mathmium
{
    public static long Combination(int element, int set)
    {
        if (!(0 <= element && element <= set)) throw new ArgumentOutOfRangeException(nameof(element) + nameof(set));
        if (element > set / 2) element = set - element;
        long result = 1;
        for (int i = 1; i <= element; i++)
        {
            result *= set - i + 1;
            result /= i;
        }
        return result;
    }
}

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        return (int)Mathmium.Combination(m - 1, (m - 1) + (n - 1));
    }
}
// @lc code=end

