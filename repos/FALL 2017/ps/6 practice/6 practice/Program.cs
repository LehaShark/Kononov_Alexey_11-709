using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            if (0 == x % 4)
            {
                if (x % 100 == 0)
                {
                    Console.WriteLine("365");
                }
                if (x % 100 > 0)
                {
                    Console.WriteLine("366");
                }
            }
        }
    }
}
