using System.Linq;

namespace HungarianAlgoritm
{
    public class ArrayHelper
    {
        public int FindPositionOfMinimalElement(int[] array)
        {
            return array.ToList().IndexOf(
                array.Where(x => x != 0)
                .Min());
        }

        public void SimplifyMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                var min = row.Min();
                for (int i = 0; i < row.Length; i++)
                {
                    row[i] -= min;
                }
            }

            for (int j = 0; j < matrix[0].Length; j++)
            {
                int min = FindMinInColumn(matrix, j);

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i][j] -= min;
                }
            }
        }

        private int FindMinInColumn(int[][] matrix, int columnNumber)
        {
            int min = matrix[0][columnNumber];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i][columnNumber] < min)
                {
                    min = matrix[i][columnNumber];
                }
            }

            return min;
        }
    }
}