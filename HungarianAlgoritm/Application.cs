using System;
using System.Collections.Generic;

namespace HungarianAlgoritm
{
    public class Application
    {
        private readonly AlgorithmImplementor _implementor;

        public Application()
        {
            _implementor = new AlgorithmImplementor();
        }

        public void Run()
        {
            var goods = new [] {140, 50, 260};
            var needs = new [] {150, 170, 30, 90, 10};

            var matrix1 = new[]
            {
                new[] {0, 0, 0, 0, 10},
                new[] {0, 0, 3, 2, 0},
                new[] {1, 0, 4, 0, 1},
            };

            var matrix2 = new[]
            {
                new[] {3, 4, 6, 4, 10},
                new[] {9, 10, 15, 12, 6},
                new[] {8, 8, 14, 8, 5},
            };

            List<DistributedGood> res = _implementor.DistributeGoods(matrix1, goods, needs);
            DisplayGoods(res);
        }

        public void DisplayGoods(List<DistributedGood> goods)
        {
            foreach (var good in goods)
            {
                Console.WriteLine($"{good.Row}-{good.Column} ({good.Amount})");
            }
        }
    }
}