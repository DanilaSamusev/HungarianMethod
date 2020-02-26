using System;

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
            var goods = new int[] {140, 50, 260};
            var needs = new int[] {150, 170, 30, 90, 10};

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

            string res = _implementor.DistributeGoods(matrix1, goods, needs);
            Console.WriteLine(res);
        }
    }
}