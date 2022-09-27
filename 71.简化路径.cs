/*
 * @lc app=leetcode.cn id=71 lang=csharp
 *
 * [71] 简化路径
 */

// @lc code=start
using System.Text;

public class Solution
{
    public string SimplifyPath(string path)
    {
        LinkedList<string> deque = new();
        string[] paths = path.Trim().Split('/');
        foreach (string p in paths)
        {
            switch (p)
            {
                case "": break;
                case ".": break;
                case "..":
                    if (deque.Count > 0)
                    {
                        deque.RemoveLast();
                    }
                    break;
                default:
                    deque.AddLast(p);
                    break;
            }
        }
        if (deque.Count == 0) return "/";
        StringBuilder result = new();
        foreach (string p in deque)
        {
            result.Append('/');
            result.Append(p);
        }
        return result.ToString();
    }
}
// @lc code=end

