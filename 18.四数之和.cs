/*
 * @lc app=leetcode.cn id=18 lang=csharp
 *
 * [18] 四数之和
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 3; i++)
        {
            if (i != 0 && nums[i] == nums[i - 1]) continue;
            for (int j = i + 1; j < nums.Length - 2; j++)
            {
                if (j != i + 1 && nums[j] == nums[j - 1]) continue;
                for (int k = j + 1, n = nums.Length - 1; k < n;)
                {
                    long sum = (long)nums[i] + nums[j] + nums[k] + nums[n] - target;
                    if (sum == 0)
                    {
                        result.Add(new int[] { nums[i], nums[j], nums[k], nums[n] });
                        while (k < n && nums[k] == nums[++k]) ;
                        while (k < n && nums[n] == nums[--n]) ;
                    }
                    else if (sum < 0)
                    {
                        k++;
                    }
                    else
                    {
                        n--;
                    }
                }
            }
        }
        return result;
    }
}
// @lc code=end

