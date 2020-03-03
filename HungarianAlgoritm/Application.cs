using System;
using System.Collections.Generic;

namespace HungarianAlgoritm
{
    public class Application
    {
        public void Run()
        {
            var goods1 = new [] {130, 50, 260};
            var needs1 = new [] {150, 170, 30, 90, 10};
            var matrix1 = new int[,]
            {
                { 0, 0, 0, 0, 10},
                { 0, 0, 3, 2, 0},
                { 1, 0, 5, 0, 1}
            };
            
            var goods2 = new [] {10,20,30};
            var needs2 = new [] {15,20,25};
            var matrix2 = new int[,]
            {
                { 2, 1, 0},
                { 0, 0, 3},
                { 1, 0, 0}
            };

            var distributer = new Distributer();
            List<DistributedGood> res = distributer.Distribute(matrix1, goods1, needs1);
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