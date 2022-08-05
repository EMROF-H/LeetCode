/*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 */

// @lc code=start
public class Solution
{
    class LowerLetterMap
    {
        int[] number;

        public int this[char c]
        {
            get => number[c - 'a'];
            set => number[c - 'a'] = value;
        }

        public LowerLetterMap(string s) : this()
        {
            foreach (char c in s)
            {
                this[c]++;
            }
        }

        public LowerLetterMap()
        {
            number = new int[26];
        }

        public bool Complete()
        {
            foreach (int i in number)
            {
                if (i != 0) return false;
            }
            return true;
        }
    }

    public IList<int> FindAnagrams(string s, string p)
    {
        if (s.Length < p.Length) return new List<int>();
        IList<int> result = new List<int>();
        LowerLetterMap map = new LowerLetterMap(p);

        for (int i = 0; i < p.Length - 1; i++)
        {
            map[s[i]]--;
        }

        for (int i = 0; i <= s.Length - p.Length; i++)
        {
            map[s[i + p.Length - 1]]--;
            if (map.Complete()) result.Add(i);
            map[s[i]]++;
        }

        return result;
    }
}
// @lc code=end

