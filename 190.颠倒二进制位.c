/*
 * @lc app=leetcode.cn id=190 lang=c
 *
 * [190] 颠倒二进制位
 */

#include <stdint.h>

// @lc code=start
uint32_t reverseBits(uint32_t n)
{
    n = (n << 16) | (n >> 16);
    n = ((n & 0x00FF00FF) << 8) | ((n & 0xFF00FF00) >> 8);
    n = ((n & 0x0F0F0F0F) << 4) | ((n & 0xF0F0F0F0) >> 4);
    n = ((n & 0x33333333) << 2) | ((n & 0xCCCCCCCC) >> 2);
    n = ((n & 0x55555555) << 1) | ((n & 0xAAAAAAAA) >> 1);
    return n;
}
// @lc code=end
