using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._20_sem
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            while (k != 0)
            {
                if ((k % 2) == 0)
                    Console.WriteLine(0);
                k /= 2;
            }
        }
    }
}
