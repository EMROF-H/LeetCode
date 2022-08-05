public class Solution
{
    public bool FindNumberIn2DArray(int[][] matrix, int target)
    {
        if (matrix.Length == 0) return false;
        for (var (i, j) = (0, matrix[0].Length - 1); i < matrix.Length && 0 <= j;)
        {
            if (matrix[i][j] == target) return true;
            else if (matrix[i][j] < target) i++;
            else j--;
        }
        return false;
    }
}