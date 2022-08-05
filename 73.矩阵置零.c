/*
 * @lc app=leetcode.cn id=73 lang=c
 *
 * [73] 矩阵置零
 */

// @lc code=start

void setZeroes(int **matrix, int matrixSize, int *matrixColSize)
{
    **matrix = matrixSize;
    *(*matrix + 1) = matrixColSize;
    *(*matrix + 2) = *matrixColSize;
    // #define MATRIX(row, col) (*(matrix + (col) + (row)*matrixColSize))

    //     if (matrixSize == 0)
    //         return;

    // #undef MATRIX(row, col)
}
// @lc code=end
