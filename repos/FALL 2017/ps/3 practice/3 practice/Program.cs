using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if (x * x - y * y >= 0)
            {
                Console.WriteLine("Yas");
            }
            if (x * x - y * y <= 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
