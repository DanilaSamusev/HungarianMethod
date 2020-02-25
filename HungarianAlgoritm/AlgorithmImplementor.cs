namespace HungarianAlgoritm
{
    class AlgorithmImplementor
    {
        private readonly MatrixHelper _helper;
        
        public AlgorithmImplementor()
        {
            _helper = new MatrixHelper();
        }

        public void MakeMatrixOptimal(int[][] matrix)
        {
            MakePreparationStage(matrix);
        }
        
        private void MakePreparationStage(int[][] matrix)
        {
            MinusMaxElement(matrix);
            MinusMinElement(matrix);
        }
        
        private void MinusMaxElement(int[][] matrix)
        {
            for (int j = 0; j < matrix.Length; j++)
            {
                int maxPrice = _helper.FindMaxInColumn(matrix, j);

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i][j] = maxPrice - matrix[i][j];
                }
            }
        }
        
        private void MinusMinElement(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                int min = _helper.FindMinInRow(matrix, i);
                
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[i][j] -= min;
                }
            }
        }  
        
        
    }
}
