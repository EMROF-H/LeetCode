/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution
{
    IList<string>[] results;

    public IList<string> GenerateParenthesis(int n)
    {
        results = new List<string>[n + 1];
        results[0] = new List<string>(new string[1] { "" });
        return Generate(n);
    }

    private IList<string> Generate(int n)
    {
        if (results[n] != null) return results[n];
        IList<string> result = new List<string>();
        for (byte i = 0; i < n; i++)
        {
            foreach (string left in Generate(i))
            {
                foreach (string right in Generate(n - 1 - i))
                {
                    result.Add($"({left}){right}");
                }
            }
        }
        results[n] = result;
        return result;
    }
}
// @lc code=end

