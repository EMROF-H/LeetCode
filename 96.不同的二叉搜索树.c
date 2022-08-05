/*
 * @lc app=leetcode.cn id=96 lang=c
 *
 * [96] 不同的二叉搜索树
 */

// @lc code=start

int results[20] = {0};

inline void buildResults(int n)
{
    results[n] = 0;
    for (int i = 0; i < n; i++)
    {
        results[n] += results[i] * results[n - 1 - i];
    }
}

int numTrees(int n)
{
    results[0] = 1;
    for (int i = 1; i <= n; i++)
    {
        buildResults(i);
    }
    return results[n];
}
// @lc code=end
