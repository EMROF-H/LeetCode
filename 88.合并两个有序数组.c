/*
 * @lc app=leetcode.cn id=88 lang=c
 *
 * [88] 合并两个有序数组
 */

// @lc code=start

void merge(int *nums1, int nums1Size, int m, int *nums2, int nums2Size, int n)
{
    for (int index = nums1Size - 1, i = m - 1, j = n - 1; index >= 0; index--)
    {
        if (j < 0)
        {
            return;
        }
        if (i >= 0 && nums1[i] > nums2[j])
        {
            nums1[index] = nums1[i--];
        }
        else
        {
            nums1[index] = nums2[j--];
        }
    }
}
// @lc code=end
