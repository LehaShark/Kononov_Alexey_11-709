using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_sem
{
    //Вычислить НОК нескольких натуральных чисел <10^9. Количество чисел <10000
    class Program
    {
        public static int GCD(int a, int b)
        {
            int gCD = 0;
            if (a > b)
            {
                for (int i = 1; i < b; i++)
                {
                    if ((a % i == 0) && (b % i == 0))
                    {
                        gCD = i;
                    }
                }
            }
            else
            {
                for (int i = 1; i < a; i++)
                {
                    if ((a % i == 0) && (b % i == 0))
                    {
                        gCD = i;
                    }
                }
            }
            return gCD;
        }
        static void Main(string[] args)
        {
            int lCM = 1;
            int amount = int.Parse(Console.ReadLine());
            while (amount != 0)
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                lCM *= (number1 * number2) / (GCD(number1, number2));
                amount -= 1;
            }
            Console.WriteLine(lCM);
        }
    }
}
