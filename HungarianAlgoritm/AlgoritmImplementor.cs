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
            for (int j = 0; j < matrix.Row.Length - 1; j++)
            {
                int maxPrice = FindMaxInColumn(matrix.PriceMatrix, j);

                for (int i = 0; i < matrix.Column.Length; i++)
                {
                    matrix.PriceMatrix[i][j] = maxPrice - matrix.PriceMatrix[i][j];
                }
            }
        }

        private int FindMaxInColumn(int[][] matrix, int columnNumber)
        {
            int max = matrix[0][columnNumber];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i][columnNumber] > max)
                {
                    max = matrix[i][columnNumber];
                }
            }

            return max;
        }

        private void MinusMinElement(Matrix matrix)
        {
            for (int i = 0; i < matrix.Column.Length; i++)
            {
                int min = FindMinInRow(matrix.PriceMatrix, i);
                
                for (int j = 0; j < matrix.Column.Length; j++)
                {
                    matrix.PriceMatrix[i][j] -= min;
                }
            }
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
