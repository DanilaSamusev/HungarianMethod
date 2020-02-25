namespace HungarianAlgoritm
{
    class AlgoritmImplementor
    {
        public void MakePreparationStage(Matrix matrix)
        {
            MinusMaxElement(matrix);
            MinusMinElement(matrix);
        }
       
        public void MinusMaxElement(Matrix matrix)
        {
            int sourcesCount = matrix._colomn.Length;
            int destinationsCount = matrix._row.Length;

            for (int j = 0; j < destinationsCount - 1; j++)
            {
                int maxPrice = FindMaxInColomn(matrix._priceMatrix, j);

                for (int i = 0; i < sourcesCount; i++)
                {
                    matrix._priceMatrix[i][j] = maxPrice - matrix._priceMatrix[i][j];
                }
            }
        }

        private int FindMaxInColomn(int[][] matrix, int colomnNumber)
        {
            int max = matrix[0][colomnNumber];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i][colomnNumber] > max)
                {
                    max = matrix[i][colomnNumber];
                }
            }

            return max;
        }

        private void MinusMinElement(Matrix matrix)
        {
            int min = FindMinInRow(matrix._priceMatrix, 2);
            int b = 1;
        }  
        
        private int FindMinInRow(int[][] matrix, int rowNumber)
        {
            int min = matrix[rowNumber][0];

            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[rowNumber][i] < min)
                {
                    min = matrix[rowNumber][i];
                }
            }

            return min;
        }
    }
}
