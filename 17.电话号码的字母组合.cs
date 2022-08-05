/*
 * @lc app=leetcode.cn id=17 lang=csharp
 *
 * [17] 电话号码的字母组合
 */

// @lc code=start
public class Solution
{
    readonly static string[] letters = new string[]
    {
                "abc", "def",
        "ghi",  "jkl", "mno",
        "pqrs", "tuv", "wxyz"
    };

    private string digits;
    private char[] buffer;
    private IList<string> result;

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>();

        this.digits = digits;
        buffer = new char[digits.Length];
        result = new List<string>();

        Backtrack(0);
        return result;
    }

    private void Backtrack(int index)
    {
        if (index == buffer.Length)
        {
            result.Add(new string(buffer));
        }
        else
        {
            foreach (char c in letters[digits[index] - '2'])
            {
                buffer[index] = c;
                Backtrack(index + 1);
            }
        }
    }
}
// @lc code=end

