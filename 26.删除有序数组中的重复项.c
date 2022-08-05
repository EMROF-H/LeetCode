/*
 * @lc app=leetcode.cn id=26 lang=c
 *
 * [26] 删除有序数组中的重复项
 */

#include <stdint.h>

// @lc code=start

int removeDuplicates(int *nums, int numsSize)
{
    int16_t pre = INT16_MAX;
    uint16_t i = 0;
    for (uint16_t delta = 0; i + delta < numsSize;)
    {
        if (nums[i + delta] == pre)
        {
            delta++;
        }
        else
        {
            nums[i] = nums[i + delta];
            pre = nums[i];
            i++;
        }
    }
    return i;
}
// @lc code=end
