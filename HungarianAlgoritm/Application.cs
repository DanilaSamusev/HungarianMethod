using System;
using System.Collections.Generic;

namespace HungarianAlgoritm
{
    public class Application
    {
        public void Run()
        {
            var goods1 = new [] {140, 50, 260};
            var needs1 = new [] {150, 170, 30, 90, 10};
            var matrix1 = new[]
            {
                new[] {3, 4, 6, 4, 10},
                new[] {9, 10, 15, 12, 6},
                new[] {8, 8, 14, 8, 5},
            };
            
            var goods2 = new [] {10,20,30};
            var needs2 = new [] {15,20,25};
            var matrix2 = new[]
            {
                new[] {5,3,1},
                new[] {3,2,4},
                new[] {4,1,2},
            };
            
            var implementor = new AlgorithmImplementor(matrix1, goods1, needs1);
            List<DistributedGood> res = implementor.DistributeGoods();
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