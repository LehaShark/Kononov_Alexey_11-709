using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 2._10_sem
{
    class Program
    {
        static void Main(string[] args)
        {
            int natureNumber = int.Parse(Console.ReadLine());
            while (natureNumber != 0)
            {
                Console.WriteLine(natureNumber % 2);
                natureNumber /= 2;
            }
        }
    }
}
