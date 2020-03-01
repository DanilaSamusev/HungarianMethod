using System.Collections.Generic;
using System.Linq;

namespace HungarianAlgoritm
{
    class AlgorithmImplementor
    {
        private readonly ArrayHelper _helper;
        private readonly List<DistributedGood> _distributedGoods;
        private int[] _needs;

        public AlgorithmImplementor()
        {
            _helper = new ArrayHelper();
            _distributedGoods = new List<DistributedGood>();
        }

        public List<DistributedGood> DistributeGoods(int[][] matrix, int[] goods, int[] needs)
        {
            _needs = needs;
            _helper.SimplifyMatrix(matrix);
            bool isDistributionOptimal = false;

            while(!isDistributionOptimal)
            {
                Distribute(matrix, goods, needs);
                isDistributionOptimal = DistributionIsOptimal();
            }

            return _distributedGoods;
        }

        private void Distribute(int[][] matrix, int[] goods, int[] needs)
        {
            for (var j = 0; j < needs.Length; j++)
            {
                var positionOfMinimalNeed = _helper.FindPositionOfMinimalElement(needs);
                List<int> cheapestGoods = GetCheapestGoods(matrix, goods, positionOfMinimalNeed);

                for (int i = 0; i < cheapestGoods.Count; i++)
                {
                    if (GoodIsMax(cheapestGoods, cheapestGoods[i]))
                    {
                        var maxGoodPosition = goods.ToList().IndexOf(cheapestGoods[i]);
                        DistributedGood good;

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
            return goods.Where((t, i) => matrix[i][columnNumber] == 0).ToList();
        }

        private bool GoodIsMax(List<int> goods, int good)
        {
            return goods.All(t => t <= good);
        }

        private bool DistributionIsOptimal()
        {
            int totalNeed = _needs.ToList().Sum();
            int totalDistribution = _distributedGoods.Select(good => good.Amount).Sum();

            return totalDistribution >= totalNeed;
        }
    }
}