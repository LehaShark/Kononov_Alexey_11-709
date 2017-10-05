using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._20_sem
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 1;
            int c = 2;
            for (c = 2; c <= 1000; c++)
            {
                for (b = 1; b < c; b++)
                {
                    for (a = 0; a < b; a++)
                    {
                        if ((a * a + b * b == c * c) && (a + b + c == 1000))
                        {
                            Console.WriteLine(a * b * c);
                        }
                    }
                }
            }
        }
    }
}
