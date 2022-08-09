/*
 * @lc app=leetcode.cn id=139 lang=csharp
 *
 * [139] 单词拆分
 */

// @lc code=start
public class Array<T>
{
    private readonly T[] Value;

    public int StartIndex { get; private set; }
    public T Start { get => Value[0]; }
    public int EndIndex { get => Value.Length - 1 - StartIndex; }
    public T End { get => Value[^1]; }

    public int Length { get => Value.Length; }

    public T this[int index]
    {
        get => Value[index - StartIndex];
        set => Value[index - StartIndex] = value;
    }

    public T this[Index index]
    {
        get => Value[index.IsFromEnd ? index : (index.Value - StartIndex)];
        set => Value[index.IsFromEnd ? index : (index.Value - StartIndex)] = value;
    }

    public Array(int startIndex, int length)
    {
        StartIndex = startIndex;
        Value = new T[length];
    }

    public Array(int startIndex, T[] array)
    {
        StartIndex = startIndex;
        Value = array;
    }
}

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> dictionary = new(wordDict);
        int maxLength = wordDict.Aggregate(string.Empty,
            (last, current) => current.Length > last.Length ? current : last).Length;
        Array<bool> result = new(-1, s.Length + 1);
        result[-1] = true;

        for (int i = 0; i < s.Length; i++)
        {
            result[i] = false;
            for (int j = 0; j < maxLength && j <= i; j++)
            {
                if (result[i - j - 1] && dictionary.Contains(s.Substring(i - j, j + 1)))
                {
                    result[i] = true;
                    break;
                }
            }
        }

        return result[^1];
    }
}
// @lc code=end

