/*
 * @lc app=leetcode.cn id=14 lang=cpp
 *
 * [14] 最长公共前缀
 */

#include <vector>
#include <string>

using namespace std;

// @lc code=start
class Solution
{
public:
    string longestCommonPrefix(vector<string> &strs)
    {
        if (strsSize == 1)
            return strs[0];
        if (strs[0].empty())
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
};
// @lc code=end
