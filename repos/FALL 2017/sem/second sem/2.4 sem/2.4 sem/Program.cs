using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_sem
{
    class Program
    {
        static void Main(string[] args)
        {
            double epsilon = double.Parse(Console.ReadLine());
            double PI = 0;
            int k = 1;
            Console.WriteLine(2 * Math.Log(2));
            for (; ; k++)
            {
                double memberK = (1.0 / ((4 * k - 2) * (4 * k - 1)));
                PI += memberK;
                if (memberK <= epsilon) break;
            }
            Console.WriteLine(k);
            Console.WriteLine(8 * PI + 2 * Math.Log(2));
        }
    }
}