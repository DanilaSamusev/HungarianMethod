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
                int positionOfMin = _helper.FindPositionOfMin(needs);
                List<int> goodsWithZeroes = GetGoodsWithZeroes(matrix, goods, positionOfMin);

                for (int i = 0; i < goodsWithZeroes.Count; i++)
                {
                    if (GoodIsMax(goodsWithZeroes, goodsWithZeroes[i]))
                    {
                        int goodId;
                        
                        if (needs[positionOfMin] <= goodsWithZeroes[i])
                        {
                            goodId = goods.ToList().IndexOf(goodsWithZeroes[i]);
                            goods[goodId] -= needs[positionOfMin];
                            goodsWithZeroes[i] -= needs[positionOfMin];
                            result += $"{goodId}-{positionOfMin} ({needs[positionOfMin]})\n";
                            needs[positionOfMin] = 0;
                            break;
                        }
                        
                        goodId = goods.ToList().IndexOf(goodsWithZeroes[i]);
                        result += $"{goodId}-{positionOfMin} ({goodsWithZeroes[i]})\n";
                        needs[positionOfMin] -= goodsWithZeroes[i];
                        goods[goodId] = 0;
                        goodsWithZeroes[i] = 0;
                        i = 0;
                    }
                }
            }

            return result;
        }

        private List<int> GetGoodsWithZeroes(int[][] matrix, int[] goods, int columnNumber)
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