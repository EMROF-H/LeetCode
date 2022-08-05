public class Solution
{
    public double MyPow(double x, int n)
    {
        long N = n;
        if (n < 0) N = -N;
        double result = 1;
        while (N != 0)
        {
            if (N % 2 == 1) result *= x;
            x *= x;
            N >>= 1;
        }
        return n < 0 ? 1 / result : result;
    }
}