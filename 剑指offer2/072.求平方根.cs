public class Solution
{
    public int MySqrt(int x)
    {
        int max = 0xB504;
        if (x >= max * max) return max;

        int min = 0;
        int result = -1;
        while (min <= max)
        {
            int mid = min + (max - min) / 2;
            int minSquare = mid * mid;
            if (minSquare <= x)
            {
                result = mid;
                if (minSquare == x)
                {
                    break;
                }

                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }
        return result;
    }
}