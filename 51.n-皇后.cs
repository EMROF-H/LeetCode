/*
 * @lc app=leetcode.cn id=51 lang=csharp
 *
 * [51] N 皇后
 */

// @lc code=start
public class Solution
{
    private byte N;
    private List<IList<string>> Result;
    private string[] Strings;

    private byte[] SolutionBuffer;
    private BitArray BitArray;

    private void Push()
    {
        string[] solution = new string[N];
        for (int i = 0; i < N; i++)
        {
            solution[i] = Strings[SolutionBuffer[i]];
        }
        Result.Add(solution);
    }

    private void Init(int n)
    {
        N = (byte)n;
        Result = new();
        Strings = new string[n];
        SolutionBuffer = new byte[n];

        BitArray = new(n);

        char[] chars = new char[n];
        for (byte i = 0; i < n; i++)
        {
            SolutionBuffer[i] = 0xFF;
            chars[i] = '.';
        }
        for (byte i = 0; i < n; i++)
        {
            chars[i] = 'Q';
            Strings[i] = new(chars);
            chars[i] = '.';
        }
    }

    public IList<IList<string>> SolveNQueens(int n)
    {
        Init(n);
        Solve();
        return Result;
    }

    private void Solve(byte n = 0)
    {
        if (n == N)
        {
            Push();
            return;
        }
        for (byte i = 0; i < N; i++)
        {
            if (!BitArray[i])
            {
                if (!JudgeSlash(n, i)) continue;
                SolutionBuffer[n] = i;
                BitArray[i] = true;
                Solve((byte)(n + 1));
                SolutionBuffer[n] = 0xFF;
                BitArray[i] = false;
            }
        }
    }

    private bool JudgeSlash(byte column, int row)
    {
        for (int i = 0; i < column; i++)
        {
            if (Math.Abs(SolutionBuffer[i] - row) == Math.Abs(i - column)) return false;
        }
        return true;
    }
}
// @lc code=end

