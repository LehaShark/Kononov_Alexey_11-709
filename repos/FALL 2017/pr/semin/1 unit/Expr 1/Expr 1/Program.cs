using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 3;
            a += b;
            b = a - b;
            a = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
