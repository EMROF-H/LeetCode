/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

using System;

// @lc code=start
class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];
        if (strs[0].Length == 0)
            return strs[0];

        for (short i = 0; true; i++)
        {
            if (strs[0].Length == i)
            {
                return strs[0].Substring(0, i);
            }

            for (short j = 1; j < strs.Length; j++)
            {
                if (strs[j].Length == i || strs[j][i] != strs[0][i])
                {
                    return strs[0].Substring(0, i);
                }
            }
        }
    }
}
// @lc code=end