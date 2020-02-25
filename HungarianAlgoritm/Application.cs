using System;

namespace HungarianAlgoritm
{
    public class Application
    {              
        public void Run()
        {
            Matrix matrix = new Matrix();
            DisplayMatrix(matrix);

            AlgoritmImplementor implementor = new AlgoritmImplementor();
            implementor.MakePreparationStage(matrix);
            DisplayMatrix(matrix);

        }

        

        private void DisplayMatrix(Matrix matrix)
        {
            foreach (string rowMember in matrix._row) 
            {
                Console.Write($"   {rowMember} ");
            }

            Console.WriteLine();

            int sourcesCount = matrix._colomn.Length;
            int destinationsCount = matrix._row.Length;

            for (int i = 0; i < sourcesCount; i++)
            {
                for(int j = 0; j < destinationsCount; j++)
                {
                    if (j == 0)
                    {
                        string colomnMember = matrix._colomn[0];
                        Console.Write($" {colomnMember} ");
                    }
                   
                    int price = matrix._priceMatrix[i][j];
                    Console.Write($" {price} ");                        
                    
                }

                Console.WriteLine();
            }
        }
    }
}
