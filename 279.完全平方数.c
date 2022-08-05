/*
 * @lc app=leetcode.cn id=279 lang=c
 *
 * [279] 完全平方数
 */

#include <malloc.h>
#include <math.h>

// @lc code=start

#define MIN(a, b) ((a) < (b) ? (a) : (b))

int numSquares(int n)
{
    int *results = (int *)malloc(sizeof(int) * (n + 1));

    results[0] = 0;
    for (int i = 1; i <= n; i++)
    {
        int min = INT_MAX;
        for (int j = 1; j * j <= i; j++)
        {
            min = MIN(min, results[i - j * j]);
        }
        results[i] = min + 1;
    }
    return results[n];
}
// @lc code=end
