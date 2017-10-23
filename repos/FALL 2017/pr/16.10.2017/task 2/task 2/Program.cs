using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            while (begin <= end)
            {
                Console.Write(begin + " ");
                begin += step;
            }
        }
    }
}
