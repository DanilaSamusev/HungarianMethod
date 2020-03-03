using System.Collections.Generic;
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

        public int FindMinInColumn(int[][] matrix, int columnNumber)
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

        public List<int> FindColumnNubersWithRequiredZeroesCount(int requiredZeroesCount, int[,] matrix)
        {
            var columnNubersWithZeroes = new List<int>();

            for (int columnNuber = 0; columnNuber < matrix.GetLength(0); columnNuber++)
            {
                int actualZeroesCount = 0;

                for (int rowNumber = 0; rowNumber < matrix.Length; rowNumber++)
                {

                    if (matrix[rowNumber,columnNuber] == 0)
                    {
                        actualZeroesCount++;
                    }
                }

                if (actualZeroesCount == requiredZeroesCount)
                {
                    columnNubersWithZeroes.Add(columnNuber);
                }
            }

            return columnNubersWithZeroes;
        }

        public List<int> FindRowNubersWithRequiredZeroesCount(int requiredZeroesCount, int[,] matrix)
        {
            var rowNubersWithZeroes = new List<int>();

            for (int rowNumber = 0; rowNumber < matrix.Length; rowNumber++)
            {
                int actualZeroesCount = 0;

                for (int columnNuber = 0; columnNuber < matrix.Length; columnNuber++)
                {

                    if (matrix[rowNumber, columnNuber] == 0)
                    {
                        actualZeroesCount++;
                    }
                }

                if (actualZeroesCount == requiredZeroesCount)
                {
                    rowNubersWithZeroes.Add(rowNumber);
                }
            }

            return rowNubersWithZeroes;
        }
    }
}
}