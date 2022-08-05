/*
 * @lc app=leetcode.cn id=11 lang=c
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
int Max(int a, int b)
{
    return a > b ? a : b;
}

int Min(int a, int b)
{
    return a < b ? a : b;
}

int maxArea(int *height, int heightSize)
{
    int max = -1;
    int left = 0, right = heightSize - 1;
    while (right > left)
    {
        if (height[left] < height[right])
        {
            max = Max(max, height[left] * (right - left));
            left++;
        }
        else
        {
            max = Max(max, height[right] * (right - left));
            right--;
        }
    }
    return max;
}
// @lc code=end
