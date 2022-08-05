/*
 * @lc app=leetcode.cn id=76 lang=cpp
 *
 * [76] 最小覆盖子串
 */

#include <string>
#include <cstdint>

using namespace std;

// @lc code=start
class LetterMap
{
public:
    typedef int Number_T;
    typedef unsigned char Index_T;
    const static LetterMap::Index_T Size = 56;

private:
    Number_T Map[Size] = {0};

    static LetterMap::Index_T Index(char letter)
    {
        if (letter >= 'a')
        {
            return letter - 'a';
        }
        else
        {
            return letter - 'A' + ('z' - 'a' + 1);
        }
    }

public:
    LetterMap(string &s)
    {
        for (LetterMap::Number_T i = 0; s[i] != '\0'; i++)
        {
            (*this)[s[i]]--;
        }
    }

    void Push(char letter)
    {
        (*this)[letter]++;
    }

    bool Pop(char letter)
    {
        if ((*this)[letter] <= 0)
        {
            return false;
        }
        else
        {
            (*this)[letter]--;
            return true;
        }
    }

    bool IsLegal(void)
    {
        for (LetterMap::Index_T i = 0; i < LetterMap::Size; i++)
        {
            if (Map[i] < 0)
                return false;
        }
        return true;
    }

    Number_T &operator[](char letter)
    {
        return Map[LetterMap::Index(letter)];
    }

    void operator+=(char letter)
    {
        this->Push(letter);
    }

    bool operator-=(char letter)
    {
        return (this->Pop(letter));
    }
};

class Solution
{
public:
    string minWindow(string s, string t)
    {
        LetterMap::Number_T result_left = 0, result_size = UINT16_MAX;

        LetterMap letterMap(t);

        bool isLeftMove = false;
        LetterMap::Number_T left = 0, right = 0;
        while (true)
        {
            if (isLeftMove)
            {
                if (letterMap -= s[left])
                {
                    left++;
                }
                else
                {
                    if (right - left < result_size)
                    {
                        result_left = left;
                        result_size = right - left;
                    }
                    if (s[right] == '\0')
                    {
                        break;
                    }
                    isLeftMove = false;
                }
            }
            else
            {
                if (s[right] == '\0')
                {
                    return "";
                }
                else
                {
                    letterMap += s[right++];
                    isLeftMove = letterMap.IsLegal();
                }
            }
        }
        return s.substr(result_left, result_size);
    }
};
// @lc code=end
