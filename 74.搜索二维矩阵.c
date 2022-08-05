/*
 * @lc app=leetcode.cn id=74 lang=c
 *
 * [74] 搜索二维矩阵
 */

#include <stdbool.h>
#include <stddef.h>

// @lc code=start
/*
int **Matrix;
size_t ColSize;

/*
inline int getMatrix(i)
{
    return *(*(Matrix + i / ColSize) + i % ColSize);
}
*/

#define MATRIX(i) (*(*(matrix + (i) / *matrixColSize) + (i) % *matrixColSize))

bool searchMatrix(int **matrix, int matrixSize, int *matrixColSize, int target)
{
    size_t size = matrixSize * *matrixColSize;

    int this, last = MATRIX(0);
    bool haveTrget = last == target, isAscend = true;
    for (size_t i = 1; i < size; i++)
    {
        this = MATRIX(i);
        if (this == target)
        {
            haveTrget = true;
        }
        if (this < last)
        {
            isAscend = false;
        }
        last = this;
    }
    return haveTrget && isAscend;
}
// @lc code=end
