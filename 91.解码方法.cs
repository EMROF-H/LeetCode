/*
 * @lc app=leetcode.cn id=91 lang=csharp
 *
 * [91] 解码方法
 */

// @lc code=start
public class Solution
{
    public int NumDecodings(string s)
    {
        if (s[0] == '0') return 0;

        int[] result = new int[s.Length];
        result[0] = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                if (s[i - 1] != '1' && s[i - 1] != '2')
                {
                    return 0;
                }
                else
                {
                    result[i] = ((i - 2) >= 0) ? result[i - 2] : 1;
                }
            }
            else if (s[i - 1] != '0' && (s[i - 1] - '0') * 10 + (s[i] - '0') <= 26)
            {
                result[i] = (((i - 2) >= 0) ? result[i - 2] : 1) + result[i - 1];
            }
            else
            {
                result[i] = result[i - 1];
            }
        }

        return result[^1];
    }
}
// @lc code=end

