/*
 * @lc app=leetcode.cn id=338 lang=csharp
 *
 * [338] 比特位计数
 */

// @lc code=start
public class Solution
{
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];
        result[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            result[i] = result[i & (i - 1)] + 1;
        }
        return result;
    }
}

public class Solution1 //法一 逐个求解
{
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            result[i] = GetBits(i);
        }
        return result;
    }

    private int GetBits(int n)
    {
        int result = 0;
        while (n != 0)
        {
            n &= n - 1;
            result++;
        }
        return result;
    }
}

public class Solution2 //法二 DP最高有效位
{
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];
        result[0] = 0;
        int highBit = 0;
        for (int i = 1; i <= n; i++)
        {
            if ((i & (i - 1)) == 0)
            {
                result[i] = 1;
                highBit = i;
            }
            else
            {
                result[i] = result[i - highBit] + 1;
            }
        }
        return result;
    }
}

public class Solution3 //法三 DP最低有效位
{
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];
        result[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            result[i] = result[i >> 1] + (i & 1);
        }
        return result;
    }
}

public class Solution4 //法四 DP最低设置位
{
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];
        result[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            result[i] = result[i & (i - 1)] + 1;
        }
        return result;
    }
}
// @lc code=end
