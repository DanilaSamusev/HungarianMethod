using System;
using System.Collections.Generic;

namespace HungarianAlgoritm
{
    public class MatrixViewer
    {
        private void DisplayMatrix(
            int[][] matrix,
            Dictionary<int, int> independentZeroes,
            Dictionary<int, int> dependentZeroes,
            int[] independentRows,
            int[] independentColumns,
            int[] dependentRows)
        {
            DisplayIndependentColumns(matrix.Length, independentColumns);

            
        }

        private void DisplayIndependentColumns(int matrixLength, int[] independentColumns)
        {
            var independentColumnsView = new string[matrixLength];

            for (var j = 0; j < independentColumnsView.Length; j++)
            {
                independentColumnsView[j] = "   ";
            }

            if (independentColumns != null)
            {
                foreach (var column in independentColumns)
                {
                    independentColumnsView[column] = " + ";
                }
            }
        }
    }
}