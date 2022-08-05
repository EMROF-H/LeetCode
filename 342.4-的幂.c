/*
 * @lc app=leetcode.cn id=342 lang=c
 *
 * [342] 4的幂
 */

#include <stdbool.h>

// @lc code=start
bool isPowerOfFour(int n)
{
    return n > 0 && !(n & (n - 1)) && n % 3 == 1;
}
// @lc code=end
