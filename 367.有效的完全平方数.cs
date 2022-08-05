/*
 * @lc app=leetcode.cn id=367 lang=csharp
 *
 * [367] 有效的完全平方数
 */

// @lc code=start
public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        int sqrt = Sqrt(num);
        return num == sqrt * sqrt;
    }

    private int Sqrt(int x)
    {
        int max = 0xB504;
        if (x >= max * max) return max;

        int min = 0;
        int result = -1;
        while (min <= max)
        {
            int mid = min + (max - min) / 2;
            int minSquare = mid * mid;
            if (minSquare <= x)
            {
                result = mid;
                if (minSquare == x)
                {
                    break;
                }

                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }
        return result;
    }
}
// @lc code=end

