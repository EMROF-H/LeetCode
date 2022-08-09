/*
 * @lc app=leetcode.cn id=1277 lang=csharp
 *
 * [1277] 统计全为 1 的正方形子矩阵
 */

// @lc code=start
public class Solution
{
    public int CountSquares(int[][] matrix)
    {
        Matrix<int> result = new(null, matrix);

        result.Origin = result[1].Origin;
        result.SetBorder(indexer =>
        {
            indexer.Current = indexer[1, 0];
        });
        result.SetBody(indexer =>
        {
            if (indexer[1, 0, 0] == 0) indexer.Current = 0;
            else indexer.Current =
                1 + Mathmium.Min(indexer[0, -1, -1], indexer[0, -1, 0], indexer[0, 0, -1]);
        });

        return result.Sum();
    }
}

public class Matrix<T>
{
    #region Class
    public delegate void SingleLoopBody(int i);
    public delegate void DoubleLoopBody(int i, int j);
    public class Placeholder { private Placeholder() { } }
    public class ElementOriginIndexer
    {
        public delegate void MatrixProcess(ElementOriginIndexer indexer);

        public readonly List<Matrix<T>> Matrices;
        public T this[int matrixIndex, int row, int column]
        {
            get => Matrices[matrixIndex][row + CurrentRowIndex, column + CurrentColumnIndex];
            set => Matrices[matrixIndex][row + CurrentRowIndex, column + CurrentColumnIndex] = value;
        }
        public T this[int matrixIndex, int borderIndex]
        {
            get
            {
                if (CurrentRowIndex == 0 && CurrentColumnIndex != 0)
                {
                    return this[matrixIndex, 0, borderIndex];
                }
                if (CurrentRowIndex != 0 && CurrentColumnIndex == 0)
                {
                    return this[matrixIndex, borderIndex, 0];
                }
                throw new Exception("Element is not border.");
            }
            set
            {
                if (CurrentRowIndex == 0 && CurrentColumnIndex != 0)
                {
                    this[matrixIndex, 0, borderIndex] = value; return;
                }
                if (CurrentRowIndex != 0 && CurrentColumnIndex == 0)
                {
                    this[matrixIndex, borderIndex, 0] = value; return;
                }
                throw new Exception("Element is not border.");
            }
        }
        public Matrix<T> this[int index] { get => Matrices[index]; }
        public T Current
        {
            get => this[0, 0, 0];
            set => this[0, 0, 0] = value;
        }
        public int CurrentRowIndex { get; set; }
        public int CurrentColumnIndex { get; set; }

        public ElementOriginIndexer(Matrix<T> matrix, int rowIndex = 0, int columnIndex = 0)
        {
            Matrices = new() { matrix };
            CurrentRowIndex = rowIndex;
            CurrentColumnIndex = columnIndex;
        }

        public void Add(Matrix<T> matrix)
        {
            if ((matrix.Row, matrix.Column) == (Matrices[0].Row, Matrices[0].Column)) Matrices.Add(matrix);
            else throw new Exception(nameof(matrix));
        }
    }
    #endregion

    #region Property
    private readonly T[][] Array;
    public Matrix<T> this[int index] { get => Indexer[index]; }
    public T this[Index row, Index column]
    {
        get => Array[row.IsFromEnd ? Row - row.Value : row.Value]
                    [column.IsFromEnd ? Column - column.Value : column.Value];
        set => Array[row.IsFromEnd ? Row - row.Value : row.Value]
                    [column.IsFromEnd ? Column - column.Value : column.Value] = value;
    }
    public IReadOnlyList<T> this[Index row, Placeholder? ANY]
    {
        get
        {
            T[] result = new T[Column];
            ForColumn(j => result[j] = this[row, j]);
            return result;
        }
        set
        {
            ForColumn(j => this[row, j] = value[j]);
        }
    }
    public IReadOnlyList<T> this[Placeholder? ANY, Index column]
    {
        get
        {
            T[] result = new T[Column];
            ForRow(i => result[i] = this[i, column]);
            return result;
        }
        set
        {
            ForRow(i => this[i, column] = value[i]);
        }
    }

    public int Row { get => Array.Length; }
    public int Column { get => Array[0].Length; }
    public T Origin
    {
        get => this[0, 0];
        set => this[0, 0] = value;
    }
    public T End
    {
        get => this[^1, ^1];
        set => this[^1, ^1] = value;
    }
    private ElementOriginIndexer Indexer;
    #endregion

    #region Constructor
#pragma warning disable CS8618
    public Matrix(int row, int column, IList<Matrix<T>> matrices)
    {
        Array = new T[row][];
        ForRow(i => Array[i] = new T[column]);
        IndexerInitialize(matrices);
    }

    public Matrix(int row, int column, Matrix<T>? matrix = null)
    {
        Array = new T[row][];
        ForRow(i => Array[i] = new T[column]);
        IndexerInitialize(matrix);
    }

    public Matrix(T[][] array, IList<Matrix<T>> matrices)
    {
        Array = array;
        IndexerInitialize(matrices);
    }

    public Matrix(T[][] array, Matrix<T>? matrix = null)
    {
        Array = array;
        IndexerInitialize(matrix);
    }

    public Matrix(T[][]? array, T[][] syncArray)
    {
        Matrix<T> syncMatrix = new(syncArray);
        if (array == null)
        {
            Array = new T[syncMatrix.Row][];
            for (int i = 0; i < syncMatrix.Row; i++)
            {
                Array[i] = new T[syncMatrix.Column];
            }
        }
        else
        {
            Array = array;
        }
        IndexerInitialize(syncMatrix);
    }
#pragma warning restore CS8618
    private void IndexerInitialize(IList<Matrix<T>> matrices)
    {
        Indexer = new(this);
        foreach (var matrix in matrices)
        {
            Indexer.Add(matrix);
        }
    }

    private void IndexerInitialize(Matrix<T>? matrix)
    {
        Indexer = new(this, 0, 0);
        if (matrix != null)
        {
            Indexer.Add(matrix);
        }
    }

    public static Matrix<T> MatrixFactory(T[][] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array), $"Argument {nameof(array)} is not a matrix.");
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Length != array[0].Length) throw new ArgumentNullException(nameof(array), $"Argument {nameof(array)} is not a matrix.");
        }
        return new Matrix<T>(array);
    }
    #endregion

    #region Set
    public void SetAll(T value)
    {
        ForAll((i, j) => this[i, j] = value);
    }

    public void SetBorder(ElementOriginIndexer.MatrixProcess Process, int startIndex = 1)
    {
        for (Indexer.CurrentRowIndex = startIndex,
             Indexer.CurrentColumnIndex = 0;
             Indexer.CurrentRowIndex < Row;
             Indexer.CurrentRowIndex++)
        {
            Process(Indexer);
        }
        for (Indexer.CurrentRowIndex = 0,
             Indexer.CurrentColumnIndex = startIndex;
             Indexer.CurrentColumnIndex < Column;
             Indexer.CurrentColumnIndex++)
        {
            Process(Indexer);
        }
    }

    public void SetBody(ElementOriginIndexer.MatrixProcess Process, int startIndex = 1)
    {
        ForAll(Process, startIndex, startIndex);
    }
    #endregion

    #region Loop
    public void ForRow(SingleLoopBody loopBody, int startIndex = 0)
    {
        for (int i = startIndex; i < Row; i++) loopBody(i);
    }

    public void ForColumn(SingleLoopBody loopBody, int startIndex = 0)
    {
        for (int j = startIndex; j < Column; j++) loopBody(j);
    }

    public void ForAll(DoubleLoopBody loopBody, int startRowIndex = 0, int startColumnIndex = 0)
    {
        for (int i = startRowIndex; i < Row; i++)
            for (int j = startColumnIndex; j < Column; j++)
                loopBody(i, j);
    }

    public void ForAll(ElementOriginIndexer.MatrixProcess Process, int startRowIndex = 0, int startColumnIndex = 0)
    {
        for (Indexer.CurrentRowIndex = startRowIndex;
             Indexer.CurrentRowIndex < Row;
             Indexer.CurrentRowIndex++)
        {
            for (Indexer.CurrentColumnIndex = startColumnIndex;
                 Indexer.CurrentColumnIndex < Column;
                 Indexer.CurrentColumnIndex++)
            {
                Process(Indexer);
            }
        }
    }
    #endregion
}

public static class MatrixExtension
{
    public static int Sum(this Matrix<int> matrix)
    {
        int result = 0;
        matrix.ForAll(indexer => { result += indexer.Current; });
        return result;
    }

    public static int Sum<T>(this Matrix<T> matrix, Func<T, int> function)
    {
        int result = 0;
        matrix.ForAll(indexer => { result += function(indexer.Current); });
        return result;
    }
}

public static class Mathmium
{
    public static T Min<T>(params T[] values) where T : IComparable<T>
    {
        T min = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            if (min.CompareTo(values[i]) > 0) min = values[i];
        }
        return min;
    }

    public static T Max<T>(params T[] values) where T : IComparable<T>
    {
        T max = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            if (max.CompareTo(values[i]) < 0) max = values[i];
        }
        return max;
    }

    public static long Factorial(int n)
    {
        if (n > 20) throw new ArgumentOutOfRangeException(nameof(n));
        long result = 1;
        for (int i = 2; i <= n; i++) result *= i;
        return result;
    }

    public static long Permutation(int element, int set)
    {
        if (!(0 <= element && element <= set)) throw new ArgumentOutOfRangeException(nameof(element) + nameof(set));
        long result = 1;
        for (int i = set - element + 1; i <= set; i++) result *= i;
        return result;
    }

    public static long Combination(int element, int set)
    {
        if (!(0 <= element && element <= set)) throw new ArgumentOutOfRangeException(nameof(element) + nameof(set));
        if (element > set / 2) element = set - element;
        long result = 1;
        for (int i = 1; i <= element; i++)
        {
            result *= set - i + 1;
            result /= i;
        }
        return result;
    }
}
// @lc code=end

