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
            var matrix1 = new [,]
            {
                { 3, 4, 6, 4, 10},
                { 9, 10, 15, 12, 6},
                { 8, 8, 14, 8, 5}
            };
            
            var goods2 = new [] {10,20,30};
            var needs2 = new [] {15,20,25};
            var matrix2 = new [,]
            {
                { 2, 1, 0},
                { 0, 0, 3},
                { 1, 0, 0}
            };

            var goods3 = new []{100, 200};
            var needs3 = new[] { 50, 100, 75, 75};
            var matrix3 = new [,]
            {
                {4,3,5,6},
                {8,2,4,7}
            };
            
            var distributer = new Distributer();
            List<DistributedGood> res = distributer.Distribute(matrix3, goods3, needs3);
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