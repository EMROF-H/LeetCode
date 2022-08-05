public class Solution
{
    public int FindRepeatNumber(int[] nums)
    {
        HashSet<int> set = new();
        foreach (int num in nums)
        {
            if (set.Contains(num))
            {
                return num;
            }
            else
            {
                set.Add(num);
            }
        }
        return 0;
    }
}