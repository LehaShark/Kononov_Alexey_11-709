using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int d = x % 10;
            x = x / 10;
            int c = x % 10;
            x = x / 10;
            int b = x % 10;
            x = x / 10;
            int a = x % 10;
            Console.WriteLine(a+b+c+d);
        }
    }
}
