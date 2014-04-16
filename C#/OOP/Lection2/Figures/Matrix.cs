using System;
using System.Linq;

namespace GenericList
{
    public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T[,] matrixofnums;
        private int row, col;

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0) throw new IndexOutOfRangeException("Matrix dimensions must be positive integers.");
            
            this.Row = rows;
            this.Col = cols;
            this.MatrixOfNums = new T[rows, cols];
        }

        public Matrix(T[,] value)
        {
            if (value == null || value.GetLength(0) == 0 || value.GetLength(1) == 0) throw new ArgumentNullException("The two-dimensional initialization array must contain at least one item.");
            
            this.Row = value.GetLength(0);
            this.Col = value.GetLength(1);
            MatrixOfNums = (T[,])value.Clone();
        }

        public T[,] MatrixOfNums
        {
            get
            {
                return this.matrixofnums;
            }

            set
            {
                this.matrixofnums = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }

        public T this[int currentrow, int currentcol]
        {
            get
            {
                if (currentrow >= 0 && currentrow < Row && currentcol >= 0 && currentcol < Col) return MatrixOfNums[currentrow, currentcol];
                else throw new IndexOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", currentrow, currentcol));
            }
            set
            {
                if (currentrow >= 0 && currentrow < Row && currentcol >= 0 && currentcol < Col) MatrixOfNums[currentrow, currentcol] = value;
                else throw new IndexOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", currentrow, currentcol));
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1 == null || m2 == null) throw new ArgumentNullException("Matrices are not initialized.");
            if (m1.Row != m2.Row || m1.Col != m2.Col) throw new IndexOutOfRangeException("Matrices must have the same dimensions.");

            try
            {
                Matrix<T> result = new Matrix<T>(m1.Row, m1.Col);

                for (int row = 0; row < result.Row; row++)
                    for (int col = 0; col < result.Col; col++)
                    {
                        checked
                        {
                            result[row, col] = (dynamic)m1[row, col] + m2[row, col];
                        }
                    }

                return result;
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Addition resulted in an overflow.", ex);
            }
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1 == null || m2 == null) throw new ArgumentNullException("Matrices are not initialized.");
            if (m1.Row != m2.Row || m1.Col != m2.Col) throw new IndexOutOfRangeException("Matrices must have the same dimensions.");

            Matrix<T> result = new Matrix<T>(m1.Row, m1.Col);

            for (int row = 0; row < result.Row; row++)
                for (int col = 0; col < result.Col; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m1[row, col] - m2[row, col];
                    }
                }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1 == null || m2 == null) throw new ArgumentNullException("Matrices are not initialized.");
            if (m1.Row != m2.Row || m1.Col != m2.Col) throw new IndexOutOfRangeException("Matrices must have the same dimensions.");

            try
            {
                Matrix<T> result = new Matrix<T>(m1.Row, m1.Col);

                for (int row = 0; row < result.Row; row++)
                    for (int col = 0; col < result.Col; col++)
                    {
                        checked
                        {
                            result[row, col] = (dynamic)m1[row, col] * m2[row, col];
                        }
                    }

                return result;
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Multiplication resulted in an overflow.", ex);
            }
        }

        public static bool operator true(Matrix<T> currentMatrix)
        {
            if (currentMatrix == null || currentMatrix.Row == 0 || currentMatrix.Col == 0) return false;

            for (int row = 0; row < currentMatrix.Row; row++)
                for (int col = 0; col < currentMatrix.Col; col++)
                {
                    if (!currentMatrix[row, col].Equals(default(T))) return true;
                }
 
            return false;
        }

        public static bool operator false(Matrix<T> currentMatrix)
        {
            if (currentMatrix == null || currentMatrix.Row == 0 || currentMatrix.Col == 0) return true;

            for (int row = 0; row < currentMatrix.Row; row++)
                for (int col = 0; col < currentMatrix.Col; col++)
                {
                    if (!currentMatrix[row, col].Equals(default(T))) return false;
                }
   
            return true;
        }

    }
}
