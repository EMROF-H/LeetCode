/*
 * @lc app=leetcode.cn id=1869 lang=csharp
 *
 * [1869] 哪种连续子字符串更长
 */

// @lc code=start
public class Solution
{
    public bool CheckZeroOnes(string s)
    {
        bool lastIs1 = s[0] == '1';
        if (s.Length == 1) return lastIs1;
        int first = 0;
        int max0 = -1, max1 = -1;
        for (int i = 1; i <= s.Length; i++)
        {
            if ((i == s.Length || s[i] == '0') && lastIs1)
            {
                max1 = Math.Max(max1, i - first);
                first = i;
                lastIs1 = false;
            }
            else if ((i == s.Length || s[i] == '1') && !lastIs1)
            {
                max0 = Math.Max(max0, i - first);
                first = i;
                lastIs1 = true;
            }
        }
        return max1 > max0;
    }
}
// @lc code=end

