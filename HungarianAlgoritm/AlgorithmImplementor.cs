using System.Collections.Generic;
using System.Linq;

namespace HungarianAlgoritm
{
    class AlgorithmImplementor
    {
        private readonly ArrayHelper _helper;

        public AlgorithmImplementor()
        {
            _helper = new ArrayHelper();
        }

        public string DistributeGoods(int[][] matrix, int[] goods, int[] needs)
        {
            string result = "";

            for (var j = 0; j < needs.Length; j++)
            {
                int positionOfMinimalNeed = _helper.FindPositionOfMinimalElement(needs);
                List<int> cheapestGoods = GetCheapestGoods(matrix, goods, positionOfMinimalNeed);

                for (int i = 0; i < cheapestGoods.Count; i++)
                {
                    if (GoodIsMax(cheapestGoods, cheapestGoods[i]))
                    {
                        int maxGoodPosition;
                        
                        if (needs[positionOfMinimalNeed] <= cheapestGoods[i])
                        {
                            maxGoodPosition = goods.ToList().IndexOf(cheapestGoods[i]);
                            goods[maxGoodPosition] -= needs[positionOfMinimalNeed];
                            cheapestGoods[i] -= needs[positionOfMinimalNeed];
                            result += $"{maxGoodPosition}-{positionOfMinimalNeed} ({needs[positionOfMinimalNeed]})\n";
                            needs[positionOfMinimalNeed] = 0;
                            break;
                        }
                        
                        maxGoodPosition = goods.ToList().IndexOf(cheapestGoods[i]);
                        result += $"{maxGoodPosition}-{positionOfMinimalNeed} ({cheapestGoods[i]})\n";
                        needs[positionOfMinimalNeed] -= cheapestGoods[i];
                        goods[maxGoodPosition] = 0;
                        cheapestGoods[i] = 0;
                        i = 0;
                    }
                }
            }

            return result;
        }

        private List<int> GetCheapestGoods(int[][] matrix, int[] goods, int columnNumber)
        {
            var goodsWithZeroes = new List<int>();

            for (var i = 0; i < goods.Length; i++)
            {
                if (matrix[i][columnNumber] == 0)
                {
                    goodsWithZeroes.Add(goods[i]);
                }
            }

            return goodsWithZeroes;
        }

        private bool GoodIsMax(List<int> goods, int good)
        {
            for (var i = 0; i < goods.Count; i++)
            {
                if (goods[i] > good)
                {
                    return false;
                }
            }

            return true;
        }
    }
}