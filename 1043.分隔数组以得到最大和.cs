/*
 * @lc app=leetcode.cn id=1043 lang=csharp
 *
 * [1043] 分隔数组以得到最大和
 */

// @lc code=start
public class Solution
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        int[] result = new int[arr.Length];
        for (int max = int.MinValue, i = 0; i < k; i++)
        {
            max = Math.Max(max, arr[i]);
            result[i] = max * (i + 1);
        }

        for (int i = k; i < arr.Length; i++)
        {
            result[i] = int.MinValue;
            for (int max = int.MinValue, j = 0; j < k; j++)
            {
                max = Math.Max(max, arr[i - j]);
                result[i] = Math.Max(result[i], max * (j + 1) + result[i - j - 1]);
            }
        }

        return result[^1];
    }
}

// @lc code=end

