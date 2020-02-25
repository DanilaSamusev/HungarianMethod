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
            var matrix = new []
            {
                new[] { 3, 4, 2, 2, 1},
                new[] { 4, 5, 3, 1, 3},
                new[] { 4, 3, 1, 1, 1},
                new[] { 3, 1, 2, 2, 2},
                new[] { 1, 3, 1, 2, 1}               
            };
            
            _implementor.MakeMatrixOptimal(matrix);
            
            Console.WriteLine("Result");
        }
    }
}
