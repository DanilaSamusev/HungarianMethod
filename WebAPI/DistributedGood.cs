namespace HungarianAlgoritm
{
    public class DistributedGood
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Amount { get; set; }

        public DistributedGood(int row, int column, int amount)
        {
            Row = row;
            Column = column;
            Amount = amount;
        }
    }
}