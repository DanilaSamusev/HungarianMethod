using System;
using System.Collections.Generic;
using System.Linq;

namespace HungarianAlgoritm
{
    class AlgorithmImplementor
    {
        private readonly ArrayHelper _helper;
        private readonly List<DistributedGood> _distributedGoods;
        private readonly int[][] _matrix;
        private readonly int[] _needs;
        private readonly int[] _goods;
        private readonly int[] _sourceGoods;
        private readonly int[] _sourceNeeds;

        public AlgorithmImplementor(int[][] matrix, int[] goods, int[] needs)
        {
            _helper = new ArrayHelper();
            _sourceGoods = goods;
            _sourceNeeds = needs;
            _distributedGoods = new List<DistributedGood>();
            
            _matrix = matrix;
            _needs = new int[needs.Length];
            _goods = new int[goods.Length];
            
            ResetDistribution();
        }

        public List<DistributedGood> DistributeGoods()
        { 
            bool isDistributionOptimal = false;
            
            _helper.SimplifyMatrix(_matrix);
            
            while (!isDistributionOptimal)
            {
                Distribute(_matrix, _goods, _needs);
                isDistributionOptimal = DistributionIsOptimal();

                if (!isDistributionOptimal)
                {
                    ResetDistribution();
                    OptimizeMatrix();
                }
            }

            return _distributedGoods;
        }

        private void Distribute(int[][] matrix, int[] goods, int[] needs)
        {
            int iterationsAmount = needs.Length;
            
            for (var k = 0; k < iterationsAmount; k++)
            {
                var positionOfMinimalNeed = _helper.FindPositionOfMinimalElement(needs);
                List<int> cheapestGoods = GetCheapestGoods(matrix, goods, positionOfMinimalNeed);

                for (int i = 0; i < cheapestGoods.Count; i++)
                {
                    if (GoodIsMax(cheapestGoods, cheapestGoods[i]))
                    {
                        DistributedGood good;
                        var maxGoodPosition = goods.ToList().IndexOf(cheapestGoods[i]); 
                        
                        if (needs[positionOfMinimalNeed] <= cheapestGoods[i])
                        {
                            goods[maxGoodPosition] -= needs[positionOfMinimalNeed];
                            cheapestGoods[i] -= needs[positionOfMinimalNeed];
                            good = new DistributedGood(maxGoodPosition, positionOfMinimalNeed,
                                needs[positionOfMinimalNeed]);
                            needs[positionOfMinimalNeed] = 0;
                            _distributedGoods.Add(good);
                            break;
                        }

                        good = new DistributedGood(maxGoodPosition, positionOfMinimalNeed,
                            cheapestGoods[i]);
                        needs[positionOfMinimalNeed] -= cheapestGoods[i];
                        goods[maxGoodPosition] = 0;
                        cheapestGoods[i] = 0;
                        i = 0;

                        _distributedGoods.Add(good);
                    }
                }
            }
        }

        private List<int> GetCheapestGoods(int[][] matrix, int[] goods, int columnNumber)
        {
            return goods.Where((t, i) => matrix[i][columnNumber] == 0 && goods[i] != 0).ToList();
        }

        private bool GoodIsMax(List<int> goods, int good)
        {
            return goods.All(t => t <= good);
        }

        private bool DistributionIsOptimal()
        {
            return _needs.ToList().Sum() == 0;
        }

        private void OptimizeMatrix()
        {
            int rowNumber;
            int min;
            var zeroesInRows = new List<int>();
            var columns = new List<int>();

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                zeroesInRows.Add(_matrix[i].Count(x => x == 0));
            }

            rowNumber = zeroesInRows.IndexOf(zeroesInRows.Min());
            min = _matrix[rowNumber].Where(x => x != 0).Min();
            
            for (int j = 0; j < _matrix[rowNumber].Length; j++)
            {
                if (_matrix[rowNumber][j] == 0)
                {
                    columns.Add(j);
                }
                
                _matrix[rowNumber][j] -= min;
            }

            foreach (int columnNumber in columns)
            {
                for (int i = 0; i < _matrix.Length; i++)
                {
                    _matrix[i][columnNumber] += min;
                }
            }
        }
        
        private void ResetDistribution()
        {
            Array.Copy(_sourceNeeds, _needs, _sourceNeeds.Length);
            Array.Copy(_sourceGoods, _goods, _sourceGoods.Length);
            _distributedGoods.Clear();
        }
    }
}