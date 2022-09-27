/*
 * @lc app=leetcode.cn id=172 lang=c
 *
 * [172] 阶乘后的零
 */

// @lc code=start

int trailingZeroes(int n)
{
    int result = 0;
    for (int factor = 5; factor <= n; factor *= 5)
    {
        result += n / factor;
    }

    return result;
}
// @lc code=end
