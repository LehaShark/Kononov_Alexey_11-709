using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_week_1_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 4, 6 };
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
        }
    }
}
