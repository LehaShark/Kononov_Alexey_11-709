using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] array = new int[] { 1, 3, 31, 54, 28 };
            for (int i = 0; i < array.Length; i++)
            {
                while (array[i] != 0)
                {
                    sum += (array[i] % 10); 
                    array[i] /= 10;
                }
            }
        }
    }
}
