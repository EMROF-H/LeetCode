/*
 * @lc app=leetcode.cn id=202 lang=c
 *
 * [202] 快乐数
 */

#include <stdbool.h>

// @lc code=start

int DigitSquareSum(int n)
{
    int result = 0, digit;
    while (n)
    {
        digit = n % 10;
        n /= 10;
        result += digit * digit;
    }
    return result;
}

bool isHappy(int n)
{
    int m = n;
    while (true)
    {
        m = DigitSquareSum(m);
        m = DigitSquareSum(m);
        n = DigitSquareSum(n);

        if (m == 1)
        {
            return true;
        }

        if (m == n)
        {
            return false;
        }
    }
}
// @lc code=end

// 2 4 16 37 67 85 89 145 42 20 4