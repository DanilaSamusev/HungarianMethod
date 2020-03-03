using System;
using System.Collections.Generic;

namespace HungarianAlgoritm
{
    class Distributer
    {
        private int[,] zeroMatrix;
        private int[] _goods;
        private int[] _needs;
        private List<DistributedGood> _distributedGoods = new List<DistributedGood>();
        private readonly ArrayHelper _arrayHelper; 

        public Distributer()
        {
            _arrayHelper = new ArrayHelper();
        }

        public List<DistributedGood> Distribute(int[,] matrix, int[] goods, int[] needs)
        {
            SetZeroMatrix(matrix);
            Array.Copy(needs, _needs, needs.Length);
            Array.Copy(goods, _goods, goods.Length);

            while (true)
            {
                int requiredZeroesCount = 1;

                while (true)
                {
                    List<int> columnNumbers = _arrayHelper.FindColumnNubersWithRequiredZeroesCount(requiredZeroesCount, zeroMatrix);

                    if (columnNumbers.Count != 0)
                    {
                        DistributeByColumns(columnNumbers);
                    }

                    List<int> rowNumbers;

                    if (rowNumbers.Count != 0)
                    {
                        DistributeByRows(rowNumbers);

                        if (DistributionIsOptimal())
                        {
                            return;
                        }

                        requiredZeroesCount = 1;
                        continue;
                    }

                    break;
                }

                requiredZeroesCount++;
            }
        }

        private void SetZeroMatrix(int[,] matrix)
        {
            zeroMatrix = new int[matrix.Length, matrix.GetLength(0)];

            for (int rowNumber = 0; rowNumber < matrix.Length; rowNumber++)
            {

                for (int columnNumber = 0; columnNumber < matrix.GetLength(0); columnNumber++)
                {

                    if (matrix[rowNumber, columnNumber] == 0)
                    {
                        zeroMatrix[rowNumber, columnNumber] = 0;
                    }
                    else
                    {
                        zeroMatrix[rowNumber, columnNumber] = 1;
                    }
                }
            }
        }

        private void DistributeByColumns(List<int> columnNumbers)
        {
            foreach (int columnNumber in columnNumbers)
            {
                for (int rowNumber = 0; rowNumber < zeroMatrix.Length; rowNumber++)
                {
                    if (zeroMatrix[rowNumber, columnNumber] == 0)
                    {
                        Disrtibute(rowNumber, columnNumber);
                    }
                }
            }
        }

        private void Disrtibute(int rowNumber, int columnNumber)
        {
            int good = _goods[columnNumber];
            int need = _needs[rowNumber];

            if (need <= good)
            {
                _distributedGoods.Add(new DistributedGood(rowNumber, columnNumber, need));
                good -= need;
                need = 0;
            }
            else
            {
                _distributedGoods.Add(new DistributedGood(rowNumber, columnNumber, good));
                need -= good;
                good = 0;
            }
        }
    }       
}
