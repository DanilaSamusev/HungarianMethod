namespace HungarianAlgoritm
{
    public class MatrixHelper
    {
        public int FindMaxInColumn(int[][] matrix, int columnNumber)
        {
            int max = matrix[0][columnNumber];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i][columnNumber] > max)
                {
                    max = matrix[i][columnNumber];
                }
            }

            return max;
        }
        
        public int FindMinInRow(int[][] matrix, int rowNumber)
        {
            int min = matrix[rowNumber][0];

            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[rowNumber][i] < min)
                {
                    min = matrix[rowNumber][i];
                }
            }

            return min;
        }
    }
}