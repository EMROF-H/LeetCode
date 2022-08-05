public class Solution
{
    struct Matrix
    {
        int A11;
        int A12;
        int A21;
        int A22;

        public static Matrix UNIT { get => new(1, 0, 0, 1); }

        public int this[int row, int column]
        {
            get
            {
                switch ((row, column))
                {
                    case (0, 0): return A11;
                    case (0, 1): return A12;
                    case (1, 0): return A21;
                    case (1, 1): return A22;
                    default: return -1;
                }
            }

            set
            {
                switch ((row, column))
                {
                    case (0, 0): A11 = value; return;
                    case (0, 1): A12 = value; return;
                    case (1, 0): A21 = value; return;
                    case (1, 1): A22 = value; return;
                }
            }
        }

        public Matrix(int a11, int a12, int a21, int a22)
        {
            A11 = a11;
            A12 = a12;
            A21 = a21;
            A22 = a22;
        }

        public Matrix Power(int n)
        {
            Matrix result = Matrix.UNIT;
            while (n != 0)
            {
                if (n % 2 == 1) result *= this;
                this *= this;
                n >>= 1;
            }
            return result;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            Matrix result = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = (int)(((long)left[i, 0] * right[0, j] + (long)left[i, 1] * right[1, j]) % MOD);
                }
            }
            return result;
        }
    }

    const int MOD = 1000000007;

    public int NumWays(int n)
    {
        if (n == 0 || n == 1) return 1;
        Matrix transfer = new(1, 1, 1, 0);
        transfer = transfer.Power(n - 1);
        return (transfer[0, 0] + transfer[0, 1]) % MOD;
    }
}