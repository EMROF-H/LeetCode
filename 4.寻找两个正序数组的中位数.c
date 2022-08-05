/*
 * @lc app=leetcode.cn id=4 lang=c
 *
 * [4] 寻找两个正序数组的中位数
 */
// @lc code=start

#include <stdbool.h>
#include <stddef.h>

#define MIN(a, b) ((a) < (b) ? (a) : (b))
#define AVERAGE(a, b) ((((double)(a)) + (b)) / 2)

double findMedianSortedArrays(int *nums1, int nums1Size, int *nums2, int nums2Size)
{
    if (nums1Size == 1 && nums2Size == 1)
    {
        return AVERAGE(nums1[0], nums2[0]);
    }

    int target = nums1Size + nums2Size;
    bool odd = target % 2;
    target /= 2;
    target += odd - 1;

    if (nums1Size == 0)
    {
        if (odd)
        {
            return nums2[target];
        }
        else
        {
            return AVERAGE(nums2[target], nums2[target + 1]);
        }
    }
    if (nums2Size == 0)
    {
        if (odd)
        {
            return nums1[target];
        }
        else
        {
            return AVERAGE(nums1[target], nums1[target + 1]);
        }
    }

    size_t i = 0, j = 0;
    while (i + j < target)
    {
        if (nums1[i] < nums2[j])
        {
            i++;
            if (i == nums1Size)
            {
                if (odd)
                {
                    return nums2[target - nums1Size];
                }
                else
                {
                    return AVERAGE(nums2[target - nums1Size], nums2[target - nums1Size + 1]);
                }
            }
        }
        else
        {
            j++;
            if (j == nums2Size)
            {
                if (odd)
                {
                    return nums1[target - nums2Size];
                }
                else
                {
                    return AVERAGE(nums1[target - nums2Size], nums1[target - nums2Size + 1]);
                }
            }
        }
    }

    if (odd)
    {
        return MIN(nums1[i], nums2[j]);
    }
    else
    {
        if (i + 1 == nums1Size)
        {
            return AVERAGE(nums2[j], MIN(nums1[i], nums2[j + 1]));
        }
        else if (j + 1 == nums2Size)
        {
            return AVERAGE(nums1[i], MIN(nums2[j], nums1[i + 1]));
        }
        else if (nums1[i + 1] < nums2[j])
        {
            return AVERAGE(nums1[i], nums1[i + 1]);
        }
        else if (nums2[j + 1] < nums1[i])
        {
            return AVERAGE(nums2[j], nums2[j + 1]);
        }
        else
        {
            return AVERAGE(nums1[i], nums2[j]);
        }
    }
}

/*
#include <stdbool.h>

#define MIN(a, b) ((a) < (b) ? (a) : (b))

int

double findMedianSortedArrays(int *nums1, int nums1Size, int *nums2, int nums2Size)
{
    int size = nums1Size + nums2Size;
    bool odd = size % 2;
    size /= 2;

    int start1 = 0, start2 = 0, index;

    while (index = (size - (start1 + start2)) / 2)
    {
        if (nums1[start1 + index] < nums2[start2 + index])
        {
            start1 += index;
            if (start1 >= nums1Size)
            {
                return nums2[start2 + index];
            }
        }
        else
        {
            start2 += index;
            if (start2 >= nums2Size)
            {
                return nums2[start1 + index];
            }
        }
    }

    if (odd)
    {
        return MIN(nums1[start1], nums2[start2]);
    }
    else
    {
        return 0;
    }
}
*/
// @lc code=end

int main()
{
    int nums1[] = {1, 3, 4};
    int nums2[] = {2};
    findMedianSortedArrays(nums1, 3, nums2, 1);
}