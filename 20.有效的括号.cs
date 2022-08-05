/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
public class Solution
{
    public bool IsValid(string s)
    {
        Stack<byte> brackers = new Stack<byte>(s.Length);
        foreach (char c in s)
        {
            byte n = BracketIndex(c);
            if (n % 2 == 1)
            {
                brackers.Push(n);
            }
            else
            {
                if (brackers.Count == 0 || brackers.Pop() != n - 1)
                {
                    return false;
                }
            }
        }
        return brackers.Count == 0;
    }

    private byte BracketIndex(char bracker)
    {
        switch (bracker)
        {
            case '(': return 1;
            case ')': return 2;
            case '[': return 3;
            case ']': return 4;
            case '{': return 5;
            case '}': return 6;
            default: return 0;
        }
    }
}
// @lc code=end

