/*
 * @lc app=leetcode.cn id=434 lang=c
 *
 * [434] 字符串中的单词数
 */

// @lc code=start

int countSegments(char *s)
{
    int result = 0;
    for (int i = 0; s[i]; i++)
    {
        if ((i == 0 || s[i - 1] == ' ') && s[i] != ' ')
            result++;
    }
    return result;
}
// @lc code=end
