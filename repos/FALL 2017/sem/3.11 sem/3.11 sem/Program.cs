using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._11_sem
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            int max = 0;
            int min = int.MaxValue;
            while (number != 0)
            {
                number = int.Parse(Console.ReadLine());
                if (number >= max)
                {
                    max = number;
                }
                if (number <= min)
                {
                    min = number;
                }
            }
            Console.WriteLine($"A min is {min}");
            Console.WriteLine($"A max is {max}");
            Console.ReadKey();
        }
    }
}
