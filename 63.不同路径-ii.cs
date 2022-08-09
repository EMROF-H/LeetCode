/*
 * @lc app=leetcode.cn id=63 lang=csharp
 *
 * [63] 不同路径 II
 */

// @lc code=start
public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var (row, column) = (obstacleGrid.Length, obstacleGrid[0].Length);
        if (obstacleGrid[row - 1][column - 1] == 1) return 0;

        {
            bool haveBarrier = false;
            for (int i = 0; i < row; i++)
            {
                if (obstacleGrid[i][0] == 1)
                {
                    haveBarrier = true;
                }
                else
                {
                    obstacleGrid[i][0] = haveBarrier ? 0 : -1;
                }
            }
        }

        {
            bool haveBarrier = false;
            for (int j = 0; j < column; j++)
            {
                if (obstacleGrid[0][j] == 1)
                {
                    haveBarrier = true;
                }
                else
                {
                    obstacleGrid[0][j] = haveBarrier ? 0 : -1;
                }
            }
        }

        for (int i = 1; i < row; i++)
        {
            for (int j = 1; j < column; j++)
            {
                if (obstacleGrid[i][j] != 1)
                {
                    obstacleGrid[i][j] = (obstacleGrid[i - 1][j] == 1 ? 0 : obstacleGrid[i - 1][j]) +
                                         (obstacleGrid[i][j - 1] == 1 ? 0 : obstacleGrid[i][j - 1]);
                }
            }
        }
        return -obstacleGrid[row - 1][column - 1];
    }
}
// @lc code=end

