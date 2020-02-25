using System;

namespace HungarianAlgoritm
{
    public class Application
    {              
        public void Run()
        {
            var matrix = new Matrix();
            DisplayMatrix(matrix);

            var implementor = new AlgoritmImplementor();
            implementor.MakePreparationStage(matrix);
            DisplayMatrix(matrix);
            
        }
        
        private void DisplayMatrix(Matrix matrix)
        {
            foreach (string rowMember in matrix.Row) 
            {
                Console.Write($"   {rowMember} ");
            }

            Console.WriteLine();

            int sourcesCount = matrix.Column.Length;
            int destinationsCount = matrix.Row.Length;

            for (int i = 0; i < sourcesCount; i++)
            {
                for(int j = 0; j < destinationsCount; j++)
                {
                    if (j == 0)
                    {
                        string columnMember = matrix.Column[0];
                        Console.Write($" {columnMember} ");
                    }
                   
                    int price = matrix.PriceMatrix[i][j];
                    Console.Write($" {price} ");                        
                    
                }

                Console.WriteLine();
            }
        }
    }
}
