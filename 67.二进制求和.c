/*
 * @lc app=leetcode.cn id=67 lang=c
 *
 * [67] 二进制求和
 */

// @lc code=start

#include <malloc.h>
#include <stddef.h>
#include <string.h>

char *addBinary(char *a, char *b)
{
    if (*a == '0')
        return b;
    if (*b == '0')
        return a;

    int i, aSize, bSize;
    for (i = 0; a[i] != 0 && b[i] != 0; i++)
    {
    }
    bSize = i;
    if (a[bSize] == 0 && b[bSize] != 0)
    {
        int *temp = a;
        a = b;
        b = temp;
    }
    for (; a[i] != 0; i++)
    {
    }
    aSize = i;

    char next = 0;
    for (i = 0; i < bSize; i++)
    {
        a[aSize - i - 1] += next + b[bSize - i - 1] - '0';
        if (a[aSize - i - 1] >= '2')
        {
            a[aSize - i - 1] -= 2;
            next = 1;
        }
        else
        {
            next = 0;
        }
    }

    if (next == 0)
    {
        return a;
    }

    for (; i < aSize; i++)
    {
        a[aSize - i - 1] += next;
        if (a[aSize - i - 1] >= '2')
        {
            a[aSize - i - 1] -= 2;
            next = 1;
        }
        else
        {
            next = 0;
        }
    }

    if (next == 0)
    {
        return a;
    }
    else
    {
        char *result = (char *)malloc(sizeof(char) * (aSize + 2));
        result[0] = '0' + next;
        strcpy(result + 1, a);
        return result;
    }
}
// @lc code=end
