using System.Reflection.Metadata;
/*
 * @lc app=leetcode.cn id=37 lang=csharp
 *
 * [37] 解数独
 */

// @lc code=start
using System.Runtime.CompilerServices;

public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        Sudoku sudoku = new(board);
        try
        {
            sudoku.Solve();
        }
        catch { }
    }
}

internal class Sudoku
{
    private readonly char[][] Result;
    private readonly byte[,] Grid;
    private readonly BitArray[] Row;
    private readonly BitArray[] Column;
    private readonly BitArray[,] House;

    public byte this[byte row, byte column]
    {
        get => Grid[row, column];
        set
        {
            Row[row][Grid[row, column]] = false;
            Column[column][Grid[row, column]] = false;
            House[row / 3, column / 3][Grid[row, column]] = false;

            Grid[row, column] = value;

            Row[row][Grid[row, column]] = true;
            Column[column][Grid[row, column]] = true;
            House[row / 3, column / 3][Grid[row, column]] = true;
        }
    }

    public Sudoku(char[][] board)
    {
        Result = board;
        Grid = new byte[9, 9];
        for (byte i = 0; i < 9; i++)
        {
            for (byte j = 0; j < 9; j++)
            {
                Grid[i, j] = (byte)(board[i][j] == '.' ? 0 : board[i][j] - '0');
            }
        }

        Row = new BitArray[9];
        Column = new BitArray[9];
        for (byte index = 0; index < 9; index++)
        {
            Row[index] = new(10);
            Column[index] = new(10);
        }
        House = new BitArray[3, 3];
        for (byte i = 0; i < 3; i++)
        {
            for (byte j = 0; j < 3; j++)
            {
                House[i, j] = new(10);
            }
        }

        for (byte i = 0; i < 9; i++)
        {
            for (byte j = 0; j < 9; j++)
            {
                if (this[i, j] != 0)
                {
                    if ((!Row[i][this[i, j]]) && (!Column[j][this[i, j]]) && (!House[i / 3, j / 3][this[i, j]]))
                    {
                        this[i, j] = this[i, j];
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
    }

    public void Solve(byte row = 0, byte column = 0)
    {
        if (row == 9)
        {
            for (byte i = 0; i < 9; i++)
            {
                for (byte j = 0; j < 9; j++)
                {
                    Result[i][j] = (char)(Grid[i, j] + '0');
                }
            }
            throw new Exception();
            return;
        }

        for (byte i = row; i < 9; i++)
        {
            for (byte j = (i == row) ? column : (byte)0; j < 9; j++)
            {
                if (this[i, j] == 0)
                {
                    BitArray rowJudge = Row[i];
                    BitArray columnJudge = Column[j];
                    BitArray houseJudge = House[i / 3, j / 3];
                    for (byte number = 1; number <= 9; number++)
                    {
                        if ((!rowJudge[number]) && (!columnJudge[number]) && (!houseJudge[number]))
                        {
                            this[i, j] = number;
                            SolveNext(i, j);
                            this[i, j] = 0;
                        }
                    }
                    return;
                }
            }
        }
        Solve(9);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SolveNext(byte i, byte j)
    {
        if (j == 8) Solve((byte)(i + 1), 0);
        else Solve(i, (byte)(j + 1));
    }
}
// @lc code=end

