using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6_sem
{
    //По заданному году (от 1 до 9999) вывести в формате DD/MM/YYYY дата празднования дня
//программиста(с учетом високосности года (високосный – делится на 400 или делится на 4, но не
//делится на 100)
    class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            if ((((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) == false)
            {
                Console.WriteLine($"13/09/{year}");
            }
            else
            {
                Console.WriteLine($"12/09/{year}");
            }
        }
    }
}
