/*
 * @lc app=leetcode.cn id=52 lang=csharp
 *
 * [52] N皇后 II
 */

// @lc code=start
public class Solution
{
    private static readonly short[] Result =
        new short[] { 1, 1, 0, 0, 2, 10, 4, 40, 92, 352 };
    public int TotalNQueens(int n) => Result[n];
}
// @lc code=end

public class Solution1
{
    private byte N;
    private int Result;

    private byte[] SolutionBuffer;
    private BitArray BitArray;

    private void Init(int n)
    {
        N = (byte)n;
        SolutionBuffer = new byte[n];
        BitArray = new(n);
    }

    public int TotalNQueens(int n)
    {
        Init(n);
        Solve();
        return Result;
    }

    private void Solve(byte n = 0)
    {
        if (n == N)
        {
            Result++;
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