/*
 * @lc app=leetcode.cn id=89 lang=c
 *
 * [89] 格雷编码
 */

#include <malloc.h>

// @lc code=start

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */

int *grayCode(int n, int *returnSize)
{
    *returnSize = 1 << n;
    int *result = (int *)malloc(*returnSize * sizeof(int));
    for (int i = 0; i < *returnSize; i++)
    {
        result[i] = i ^ (i >> 1);
    }
    return result;
}
// @lc code=end
