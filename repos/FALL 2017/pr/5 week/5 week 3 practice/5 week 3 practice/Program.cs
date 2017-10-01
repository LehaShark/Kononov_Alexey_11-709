using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_week_3_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 7, 1, 3 };
            int countPlus = 0;
            int countMinus = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    countMinus++;
                }
                if (array[i] > 0)
                {
                    countPlus++;
                }
            }
            Console.WriteLine(Math.Max(countPlus , countMinus));
            if (countPlus == countMinus)
            {
                Console.WriteLine("ravni");
            }
        }
    }
}
