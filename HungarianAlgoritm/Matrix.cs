namespace HungarianAlgoritm
{
    class Matrix
    {
        public string[] _row { get; set; }
        public string[] _colomn { get; set; }
        public int[][] _priceMatrix { get; set; }

        public Matrix()
        {
            _priceMatrix = new int[][]
           {
                new int[] { 3, 4, 2, 2, 1},
                new int[] { 4, 5, 3, 1, 3},
                new int[] { 4, 3, 1, 1, 1},
                new int[] { 3, 1, 2, 2, 2},
                new int[] { 1, 3, 1, 2, 1}               
           };
            _row = new string[] {" ", " ", " ", " ", " " };
            _colomn = new string[] { " ", " ", " ", " ", " " };
        }
    }
}
