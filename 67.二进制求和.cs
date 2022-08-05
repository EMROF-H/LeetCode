/*
 * @lc app=leetcode.cn id=67 lang=csharp
 *
 * [67] 二进制求和
 */

// @lc code=start

public class Solution
{
    public string AddBinary(string a, string b)
    {
        if (a.Length < b.Length)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        char[] result = new char[a.Length + 1];
        if (true)
        {
            int i;
            bool last = false;
            for (i = 0; i < b.Length; i++) (result[i], last) = BinPlus(a[i], b[i], last);
            (result[i], _) = BinPlus(a: i < a.Length ? a[i] : '0', last: last);
            for (; i < a.Length; i++) result[i] = a[i];
        }
        return new string(result);
    }

    private (char bit, bool next) BinPlus(char a = '0', char b = '0', bool last = false)
    {
        return ((a == '0' ? 0 : 1) + (b == '0' ? 0 : 1) + (last ? 1 : 0)) switch
        {
            0 => ('0', false),
            1 => ('1', false),
            2 => ('0', true),
            _ => ('\0', false),
        };
    }
}
// @lc code=end

