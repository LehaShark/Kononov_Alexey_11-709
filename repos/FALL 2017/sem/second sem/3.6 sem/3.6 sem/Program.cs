using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _3._6_sem
{
    class Program
    {
        public static double GetFunction(double x)
        {
            return Math.Cos(Math.Sin(x));
        }
        public static double LeftToRight(double a, double step, double b)
        {
            double area = 0;
            double aBack = a;
            while (a < b)
            {
                aBack = a;
                a += step;

                // Чтобы искал площадь до границы.

                if (a > b)
                    area += (b - aBack) * GetFunction(b);
                else
                    area += (a - aBack) * GetFunction(a);
            }
            return area;
        }
        public static double RightToLeft(double a, double step, double b)
        {
            double area = 0;
            double bBack = b;
            while (b > a)
            {
                bBack = b;
                b -= step;

                // Чтобы искал площадь до границы.

                if (b < a)
                    area += (bBack - a) * GetFunction(a);
                else
                    area += (bBack - b) * GetFunction(b);
            }
            return area;
        }
        public static double Trapeze(double a, double step, double b)
        {
            double area = 0;
            double aBack = a;
            while (a < b)
            {
                aBack = a;
                a += step;

                // Чтобы искал площадь до границы.

                if (a > b)
                    area += 0.5 * (GetFunction(b) + GetFunction(aBack)) * step;
                else
                    area += 0.5 * (GetFunction(a) + GetFunction(aBack)) * step;
            }
            return area;
        }
        public static double SimpsonsMethod(double a, double countsOfLineSegment, double b)
        {
            {
                double delta = (b - a) / countsOfLineSegment;
                countsOfLineSegment /= 2;
                double sum1 = 0;
                for (int i = 1; i < countsOfLineSegment; i++)
                    sum1 += GetFunction(a + 2 * i * delta);
                double sum2 = 0;
                for (int i = 1; i <= countsOfLineSegment; i++)
                    sum2 += GetFunction(a + (2 * i - 1) * delta);
                return delta / 3 * (GetFunction(a) + GetFunction(b) + 2 * sum1 + 4 * sum2);
            }
        }
            public static double MonteCarlo(double a, int countsOfDots, double b)
        {
            // Не хочу реализовывать метод нахождения производной, так как тут все очевидно.
            int squareOfSquare = 4;

            int k = countsOfDots;
            int counter = 0;
            Random rndmNumber = new Random();
            while (k != 0)
            {
                k -= 1;
                double randomX = rndmNumber.NextDouble() * 4;
                double randomY = rndmNumber.NextDouble();
                if (randomY < GetFunction(randomX))
                    counter++;
            }
            return squareOfSquare * (counter / (double)countsOfDots);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите левую границу");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите шаг");
            double step = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во отрезков для метода Симпсона");
            int countsOfLineSegments = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во точек для метода Монте Карло");
            int countsOfDots = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите правую границу");
            double b = int.Parse(Console.ReadLine());

            Console.WriteLine(LeftToRight(a, step, b));
            Console.WriteLine(RightToLeft(a, step, b));
            Console.WriteLine(Trapeze(a, step, b));
            Console.WriteLine(SimpsonsMethod(a, countsOfLineSegments, b));
            Console.WriteLine(MonteCarlo(a, countsOfDots, b));
        }
    }
}
