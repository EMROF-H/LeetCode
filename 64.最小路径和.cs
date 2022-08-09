/*
 * @lc app=leetcode.cn id=64 lang=csharp
 *
 * [64] 最小路径和
 */

// @lc code=start
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
            get => Matrices[matrixIndex][row + OriginRowIndex, column + OriginColumnIndex];
            set => Matrices[matrixIndex][row + OriginRowIndex, column + OriginColumnIndex] = value;
        }
        public T this[int matrixIndex, int borderIndex]
        {
            get
            {
                if (OriginRowIndex == 0 && OriginColumnIndex != 0)
                {
                    return this[matrixIndex, 0, borderIndex];
                }
                if (OriginRowIndex != 0 && OriginColumnIndex == 0)
                {
                    return this[matrixIndex, borderIndex, 0];
                }
                throw new Exception("Element is not border.");
            }
            set
            {
                if (OriginRowIndex == 0 && OriginColumnIndex != 0)
                {
                    this[matrixIndex, 0, borderIndex] = value; return;
                }
                if (OriginRowIndex != 0 && OriginColumnIndex == 0)
                {
                    this[matrixIndex, borderIndex, 0] = value; return;
                }
                throw new Exception("Element is not border.");
            }
        }
        public T OriginElement
        {
            get => this[0, 0, 0];
            set => this[0, 0, 0] = value;
        }
        public int OriginRowIndex { get; set; }
        public int OriginColumnIndex { get; set; }

        public ElementOriginIndexer(Matrix<T> matrix, int row, int column)
        {
            Matrices = new() { matrix };
            OriginRowIndex = row;
            OriginColumnIndex = column;
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
    public T this[Index row, Index column]
    {
        get => Array[row.IsFromEnd ? Row - 1 - row.Value : row.Value]
                    [column.IsFromEnd ? Column - 1 - column.Value : column.Value];
        set => Array[row.IsFromEnd ? Row - 1 - row.Value : row.Value]
                    [column.IsFromEnd ? Column - 1 - column.Value : column.Value] = value;
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
#pragma warning restore CS8618
    private void IndexerInitialize(IList<Matrix<T>> matrices)
    {
        Indexer = new(this, 0, 0);
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

    public void SetBorder(ElementOriginIndexer.MatrixProcess process, int startIndex = 1)
    {
        for (Indexer.OriginRowIndex = startIndex,
             Indexer.OriginColumnIndex = 0;
             Indexer.OriginRowIndex < Row;
             Indexer.OriginRowIndex++)
        {
            process(Indexer);
        }
        for (Indexer.OriginRowIndex = 0,
             Indexer.OriginColumnIndex = startIndex;
             Indexer.OriginColumnIndex < Column;
             Indexer.OriginColumnIndex++)
        {
            process(Indexer);
        }
    }

    public void SetBody(ElementOriginIndexer.MatrixProcess process, int startIndex = 1)
    {
        for (Indexer.OriginRowIndex = startIndex;
             Indexer.OriginRowIndex < Row;
             Indexer.OriginRowIndex++)
        {
            for (Indexer.OriginColumnIndex = startIndex;
                 Indexer.OriginColumnIndex < Column;
                 Indexer.OriginColumnIndex++)
            {
                process(Indexer);
            }
        }
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
    #endregion
}

public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        Matrix<int> Grid = new(grid);
        Matrix<int> result = new(Grid.Row, Grid.Column, Grid);
        result[0, 0] = Grid[0, 0];
        result.SetBorder(indexer =>
        {
            indexer[0, 0] = indexer[0, -1] + indexer[1, 0];
        });
        result.SetBody(indexer =>
        {
            indexer[0, 0, 0] = Math.Min(indexer[0, -1, 0], indexer[0, 0, -1]) + indexer[1, 0, 0];
        });
        return result[^0, ^0];
    }
}
// @lc code=end

