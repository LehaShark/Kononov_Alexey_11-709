using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (Simple(i) == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static int Simple(int a)
        {
            int k = 0;
            for (int i = 2; i < (int)a/2; i++)
            {
                if (a % i == 0)
                {
                    k++; 
                }
            }
            return k;
        }
    }
}
