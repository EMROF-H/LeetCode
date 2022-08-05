/*
 * @lc app=leetcode.cn id=73 lang=cpp
 *
 * [73] 矩阵置零
 */

#include <vector>

using namespace std;

// @lc code=start
class Solution
{
private:
    void setRowZeros(vector<vector<int>> &matrix, size_t row)
    {
        for (size_t j = 0; j < matrix[row].size(); j++)
        {
            matrix[row][j] = 0;
        }
    }

    void setColZeros(vector<vector<int>> &matrix, size_t column)
    {
        for (size_t i = 0; i < matrix.size(); i++)
        {
            matrix[i][column] = 0;
        }
    }

    void detectAll(vector<vector<int>> &matrix)
    {
    }

public:
    void setZeroes(vector<vector<int>> &matrix)
    {
        bool firstRow = false, firstCol = false;
        for (int i = 0; i < matrix.size(); i++)
        {
            if (matrix[i][0] == 0)
            {
                firstCol = true;
                break;
            }
        }
        for (int j = 0; j < matrix[0].size(); j++)
        {
            if (matrix[0][j] == 0)
            {
                firstRow = true;
                break;
            }
        }

        for (int i = 1; i < matrix.size(); i++)
        {
            for (int j = 1; j < matrix[0].size(); j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        for (int i = 1; i < matrix.size(); i++)
        {
            if (matrix[i][0] == 0)
            {
                setRowZeros(matrix, i);
            }
        }
        for (int j = 1; j < matrix[0].size(); j++)
        {
            if (matrix[0][j] == 0)
            {
                setColZeros(matrix, j);
            }
        }

        if (firstRow)
        {
            setRowZeros(matrix, 0);
        }
        if (firstCol)
        {
            setColZeros(matrix, 0);
        }
    }
};
// @lc code=end
