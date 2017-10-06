using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._10_sem
{
    //Найти длину и значение суммы элементов последовательности простых чисел, в сумме дающих
    //простое число, меньшее 1000
    class Program
    {
        public static bool PrimeNumber (int number1)
        {
            int amount = 0;
            for (int del = 1; del <= number1; del++)
            {
                if (number1 % del == 0)
                {
                    amount++;
                }
            }
            if (amount == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int length = 0;
            int sum = 0;
            int primeSum = 0;
            for (int number = 2;; number++)
            {           
                if (PrimeNumber(number) == true)
                {
                    sum += number;
                    length++;
                    if (PrimeNumber(sum) == true)
                    {
                        primeSum = sum;
                    }
                }
                if (sum >= 1000)
                    break;
            }
            Console.WriteLine($"Length is {length}");
            Console.WriteLine($"Sum is {primeSum}");
        }
    }
}
