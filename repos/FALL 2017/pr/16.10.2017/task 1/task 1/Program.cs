using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            int number = int.Parse(Console.ReadLine());
            while (number != 0)
            {
                if (number % 10 > max)
                {
                    max = number % 10;
                }
                number /= 10;
            }
            Console.WriteLine(max);
        }
    }
}
