using System.Collections.Generic;

namespace WebApplication
{
    public class ArrayHelper
    {
        
        public void SimplifyMatrix(int[,] matrix)
        {
            int min;

            for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
            {
                min = 10000;
                
                for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
                {
                    if (matrix[rowNumber, columnNumber] < min)
                    { 
                        min = matrix[rowNumber, columnNumber];
                    }
                }

                for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
                {
                    matrix[rowNumber, columnNumber] -= min;
                }
            }

            for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
            {
                min = 10000;

                for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
                {
                    if (matrix[rowNumber, columnNumber] < min)
                    {
                        min = matrix[rowNumber, columnNumber];
                    }
                }
                
                for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
                {
                    matrix[rowNumber, columnNumber] -= min;
                }
            }
        }

        public List<int> FindColumnNubersWithRequiredZeroesCount(int requiredZeroesCount, int[,] matrix)
        {
            var columnNubersWithZeroes = new List<int>();

            for (int columnNuber = 0; columnNuber < matrix.GetLength(1); columnNuber++)
            {
                int actualZeroesCount = 0;

                for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
                {
                    if (matrix[rowNumber, columnNuber] == 0)
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