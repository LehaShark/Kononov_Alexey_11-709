using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._11_sem
{
    //По вещественным координатам треугольника (шесть чисел) найти площадь этого треугольника
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            Console.WriteLine(0.5 * ((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)));
        }
    }
}
