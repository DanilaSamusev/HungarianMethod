using System;
using System.Collections.Generic;
using System.Linq;

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
            _goods = new int[goods.Length];
            _needs = new int[needs.Length];
            Array.Copy(needs, _needs, needs.Length);
            Array.Copy(goods, _goods, goods.Length);

            int requiredZeroesCount = 1;

            while (true)
            {
                
                while (true)
                {
                    List<int> columnNumbers = _arrayHelper.FindColumnNubersWithRequiredZeroesCount(requiredZeroesCount, zeroMatrix);

                    if (columnNumbers.Count != 0)
                    {
                        DistributeByColumns(columnNumbers);

                        if (DistributionIsOptimal())
                        {
                            return _distributedGoods;
                        }
                        requiredZeroesCount = 1;
                        continue;
                    }

                    List<int> rowNumbers = _arrayHelper.FindRowNubersWithRequiredZeroesCount(requiredZeroesCount, zeroMatrix);

                    if (rowNumbers.Count != 0)
                    {
                        DistributeByRows(rowNumbers);

                        if (DistributionIsOptimal())
                        {
                            return _distributedGoods;
                        }
                        requiredZeroesCount = 1;
                        continue;
                    }

                    if (DistributionIsImpossible())
                    {
                        
                        requiredZeroesCount = 1;
                    }

                    break;
                }

                int a = 0;
                requiredZeroesCount++;
            }
        }

        

        private bool DistributionIsImpossible()
        {
            for (int rowNumber = 0; rowNumber < zeroMatrix.GetLength(0); rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < zeroMatrix.GetLength(1); columnNumber++)
                {
                    if (zeroMatrix[rowNumber, columnNumber] != 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool DistributionIsOptimal()
        {
            return _needs.ToList().Sum() == 0;
        }

        private void SetZeroMatrix(int[,] matrix)
        {
            zeroMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int rowNumber = 0; rowNumber < matrix.GetLength(0); rowNumber++)
            {

                for (int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
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
                for (int rowNumber = 0; rowNumber < zeroMatrix.GetLength(0); rowNumber++)
                {
                    if (zeroMatrix[rowNumber, columnNumber] == 0)
                    {
                        Disrtibute(rowNumber, columnNumber);
                    }
                }
            }
        }

        private void DistributeByRows(List<int> rowNumbers)
        {
            foreach (int rowNumber in rowNumbers)
            {
                for (int columnNumber = 0; columnNumber < zeroMatrix.GetLength(0); columnNumber++)
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
                 
            if (_needs[columnNumber] <= _goods[rowNumber])
            {
                _distributedGoods.Add(new DistributedGood(rowNumber, columnNumber, _needs[columnNumber]));
                _goods[rowNumber] -= _needs[columnNumber];
                _needs[columnNumber] = 0;
            }
            else
            {
                _distributedGoods.Add(new DistributedGood(rowNumber, columnNumber, _goods[rowNumber]));
                _needs[columnNumber] -= _goods[rowNumber];
                _goods[rowNumber] = 0;               
            }

            CrossMatrixColumnOrRow();
        }

        private void CrossMatrixColumnOrRow()
        {

            for (int rowNumber = 0; rowNumber < _goods.Length; rowNumber++)
            {
                if (_goods[rowNumber] == 0)
                {
                    for (var columnNumber = 0; columnNumber < zeroMatrix.GetLength(1); columnNumber++)
                    {
                        zeroMatrix[rowNumber, columnNumber] = -1;
                    }
                }
            }

            for (int columnNumber = 0; columnNumber< _needs.Length; columnNumber++)
            {
                if (_needs[columnNumber] == 0)
                {
                    for (var rowNumber = 0; rowNumber < zeroMatrix.GetLength(0); rowNumber++)
                    {
                        zeroMatrix[rowNumber, columnNumber] = 1;
                    }
                }
            }       
        }
    }       
}
