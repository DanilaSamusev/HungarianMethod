namespace HungarianAlgoritm
{
    class Matrix
    {
        public string[] Row { get; set; }
        public string[] Column { get; set; }
        public int[][] PriceMatrix { get; set; }

        public Matrix()
        {
            PriceMatrix = new int[][]
           {
                new int[] { 3, 4, 2, 2, 1},
                new int[] { 4, 5, 3, 1, 3},
                new int[] { 4, 3, 1, 1, 1},
                new int[] { 3, 1, 2, 2, 2},
                new int[] { 1, 3, 1, 2, 1}               
           };
            Row = new string[] {" ", " ", " ", " ", " " };
            Column = new string[] { " ", " ", " ", " ", " " };
        }
    }
}
