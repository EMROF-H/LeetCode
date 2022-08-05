/*
 * @lc app=leetcode.cn id=14 lang=c
 *
 * [14] 最长公共前缀
 */

#include <malloc.h>
#include <stdint.h>
#include <stdbool.h>

// @lc code=start

char *longestCommonPrefix(char **strs, int strsSize)
{
    if (strsSize == 1)
        return strs[0];
    if (strs[0][0] == '\0')
        return strs[0];

    char *result = strs[0];
    for (uint8_t i = 0; true; i++)
    {
        for (uint8_t j = 1; j < strsSize; j++)
        {
            if (strs[j][i] == '\0' || strs[j][i] != result[i])
            {
                result[i] = '\0';
                return result;
            }
        }
        i++;
    }
}
// @lc code=end
