/*
 * @lc app=leetcode.cn id=42 lang=c
 *
 * [42] 接雨水
 */

// @lc code=start

inline int Max(int a, int b)
{
    return a > b ? a : b;
}

int trap(int *height, int heightSize)
{
    if (heightSize <= 2)
    {
        return 0;
    }

    int result = 0;
    int left = 0, right = heightSize - 1;
    int leftMax = -1, rightMax = -1;

    while (left <= right)
    {
        leftMax = Max(leftMax, height[left]);
        rightMax = Max(rightMax, height[right]);

        if (leftMax < rightMax)
        {
            result += leftMax - height[left];
            left++;
        }
        else
        {
            result += rightMax - height[right];
            right--;
        }
    }

    return result;
}
// @lc code=end
