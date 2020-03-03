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

        public void SimplifyMatrix(int[,] matrix)
        {
            int min = 1;

            for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
            {
                min = matrix[rowNumber, 0];

                for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
                {
                    if (matrix[rowNumber, columnNumber] < min)
                    {
                        min = matrix[rowNumber, columnNumber];
                    }
                }
            }

            for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
            {
                min = matrix[rowNumber, 0];

                for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
                {
                    matrix[rowNumber, columnNumber] -= min;
                }
            }

            for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
            {
                min = matrix[columnNumber, 0];

                for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
                {
                    if (matrix[rowNumber, columnNumber] < min)
                    {
                        min = matrix[rowNumber, columnNumber];
                    }
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

            for (int columnNuber = 0; columnNuber < matrix.GetLength(1); columnNuber++)
            {
                int actualZeroesCount = 0;

                for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
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

            for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
            {
                int actualZeroesCount = 0;

                for (int columnNuber = 0; columnNuber < matrix.GetLength(1); columnNuber++)
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
