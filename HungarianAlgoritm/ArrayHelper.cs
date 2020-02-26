using System;
using System.Linq;

namespace HungarianAlgoritm
{
    public class ArrayHelper
    {
        public int FindPositionOfMin(int[] array)
        {
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);
            Array.Sort(temp);
            temp = temp.Where(elem => elem != 0).ToArray();
            return array.ToList().IndexOf(temp[0]);
        }
    }
}