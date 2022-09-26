/*
 * @lc app=leetcode.cn id=1144 lang=c
 *
 * [1144] 递减元素使数组呈锯齿状
 */

// @lc code=start

inline int max(int a, int b)
{
    return a > b ? a : b;
}

inline int min(int a, int b)
{
    return b > a ? a : b;
}

int movesToMakeZigzag(int *nums, int numsSize)
{
    if (numsSize == 1)
        return 0;

    int result1 = 0, result2 = 0;

    if (nums[0] >= nums[1])
    {
        result1 += nums[0] - nums[1] + 1;
    }
    if (nums[numsSize - 2] <= nums[numsSize - 1])
    {
        int diff = nums[numsSize - 1] - nums[numsSize - 2] + 1;
        if (numsSize % 2 == 1)
        {
            result1 += diff;
        }
        else
        {
            result2 += diff;
        }
    }
    for (int i = 1; i < numsSize - 1; i++)
    {
        if (nums[i] >= nums[i - 1] || nums[i] >= nums[i + 1])
        {
            int diff = max(nums[i] - nums[i - 1] + 1, nums[i] - nums[i + 1] + 1);

            if (i % 2 == 0)
            {
                result1 += diff;
            }
            else
            {
                result2 += diff;
            }
        }
    }

    return min(result1, result2);
}
// @lc code=end
int movesToMakeZigzag(int *nums, int numsSize)
{
    if (numsSize == 1)
        return 0;

    int result1 = 0, result2 = 0;

    if (nums[0] >= nums[1])
    {
        result1 += nums[0] - nums[1] + 1;
    }
    if (nums[numsSize - 2] <= nums[numsSize - 1] && (numsSize % 2 == 1))
    {
        result1 += nums[numsSize - 1] - nums[numsSize - 2] + 1;
    }
    for (int i = 2; i < numsSize - 1; i += 2)
    {
        if (nums[i] >= nums[i - 1] || nums[i] >= nums[i + 1])
        {
            result1 += max(nums[i] - nums[i - 1] + 1, nums[i] - nums[i + 1] + 1);
        }
    }

    if (nums[numsSize - 2] <= nums[numsSize - 1] && (numsSize % 2 == 0))
    {
        result2 += nums[numsSize - 1] - nums[numsSize - 2] + 1;
    }
    for (int i = 1; i < numsSize - 1; i += 2)
    {
        if (nums[i] >= nums[i - 1] || nums[i] >= nums[i + 1])
        {
            result2 += max(nums[i] - nums[i - 1] + 1, nums[i] - nums[i + 1] + 1);
        }
    }

    return min(result1, result2);
}