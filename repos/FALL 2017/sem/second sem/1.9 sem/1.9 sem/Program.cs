﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._9_sem
{
    class Program
    {
        public static double Function (double x, int k)
        {
            return Math.Pow(x, 2 * k + 1) / Fact(2 * k + 1);
        }
        public static double Fact(int number)
        {
            if (number > 0)
            {
                return Fact(number - 1) * number;
            }
            else return 1;
        }
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            int k = 0;
            double sum = 0;
            double preSum = 0;
            double epsilon = double.Parse(Console.ReadLine());
            for (; ; k++)
            {
                preSum = sum;
                sum += Function(x, k);
                Console.WriteLine(k);
                Console.WriteLine(sum);
                Console.WriteLine(preSum);
                if (Math.Abs(sum - preSum) <= epsilon) break;
            }
            Console.WriteLine(k);
            Console.WriteLine(sum);
            Console.WriteLine(preSum);
        }
    }
}
