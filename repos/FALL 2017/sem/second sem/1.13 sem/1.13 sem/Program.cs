using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._13_sem
{
    class Program
    {
        public static double Function (double x, int k)
        {
            return (Math.Pow(-1, k) * Math.Pow(2, 2 * k - 1) * Math.Pow(x, 2 * k)) / Fact(2 * k);
        }
        public static double Fact(double number)
        {
            if (number > 1)
            {
                return Fact(number - 1) * number;
            }
            else return 1;
        }
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            double epsilon = double.Parse(Console.ReadLine());
            int k = 1;
            double preSum = 0;
            double sum = 0;
            while (true)
            {
                preSum = sum;
                sum += Function(x, k);
                k++;
                if (Math.Abs(Function(x, k)) <= epsilon) break;
                Console.WriteLine(k);
                Console.WriteLine(sum);
                Console.WriteLine(preSum);
            }
            Console.WriteLine(k - 1);
            Console.WriteLine(1 + sum);
            Console.WriteLine(preSum);
        }
    }
}