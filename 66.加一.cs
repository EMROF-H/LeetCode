using System.Runtime.Intrinsics.X86;
using System.Globalization;
/*
 * @lc app=leetcode.cn id=66 lang=csharp
 *
 * [66] 加一
 */

// @lc code=start
public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        digits[digits.Length-1]++;
        for(int i=digits.Length-1;i>0;i--)
        {
            if(digits[i]==10)
            {
                digits[i]=0;
                digits[i-1]++;
            }
        }
        if(digits[0]==10)
        {
            digits[0] = 0;

            int[] result = new int[digits.Length+1];
            for(int i=0;i<digits.Length;i++)
            {
                result[i+1] = digits[i];
            }
            result[0] = 1;
            return result;
        }
        else
        {
            return digits;
        }
    }
}
// @lc code=end

