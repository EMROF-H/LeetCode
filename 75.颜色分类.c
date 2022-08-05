/*
 * @lc app=leetcode.cn id=75 lang=c
 *
 * [75] 颜色分类
 */

#include <stddef.h>

// @lc code=start

void sortColors(int *nums, int numsSize)
{
    int color[3] = {0};

    for (size_t i = 0; i < numsSize; i++)
    {
        color[nums[i]]++;
    }

    for (size_t i = 0; i < numsSize; i++)
    {
        if (color[0] > 0)
        {
            color[0]--;
            nums[i] = 0;
        }
        else if (color[1] > 0)
        {
            color[1]--;
            nums[i] = 1;
        }
        else
        {
            nums[i] = 2;
        }
    }
}
// @lc code=end
