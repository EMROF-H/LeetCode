public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int[] result = new int[cost.Length];
        (result[0], result[1]) = (cost[0], cost[1]);
        for (int i = 2; i < cost.Length; i++)
        {
            result[i] = Math.Min(result[i - 1], result[i - 2]) + cost[i];
        }
        return Math.Min(result[^1], result[^2]);
    }
}