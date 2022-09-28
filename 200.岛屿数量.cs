/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution
{
    private char[][] Grid;
    private int Height;
    private int Width;

    public int NumIslands(char[][] grid)
    {
        Grid = grid;
        (Height, Width) = (grid.Length, grid[0].Length);

        int result = 0;
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (RemoveIsland(i, j)) result++;
            }
        }
        return result;
    }

    private bool RemoveIsland(int row, int column)
    {
        if (row < 0 || row >= Height) return false;
        if (column < 0 || column >= Width) return false;
        if (Grid[row][column] != '1') return false;
        Grid[row][column] = '2';

        RemoveIsland(row - 1, column);
        RemoveIsland(row + 1, column);
        RemoveIsland(row, column - 1);
        RemoveIsland(row, column + 1);

        return true;
    }
}
// @lc code=end

