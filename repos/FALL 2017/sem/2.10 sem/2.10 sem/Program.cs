using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._10_sem
{
    //Вывести биты натурального числа n в обратном порядке (n<=10^9)
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
