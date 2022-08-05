/*
 * @lc app=leetcode.cn id=326 lang=c
 *
 * [326] 3 的幂
 */

#include <stdbool.h>

// @lc code=start
bool isPowerOfThree(int n)
{
    return n > 0 && 0x4546B3DB % n == 0;
}
// @lc code=end
