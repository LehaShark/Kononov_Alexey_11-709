using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_N_
{
    class Program
    {
        // ~ O(width*(n + range))
        // width - максимальное колличество разрядов.
        // range - количество возможных значений одного разряда (10).
        public static int[] GetUnite(int[][] array)
        {
            var array1 = new int[array.Length];
            foreach (int[] e in array)
            {
                foreach (int r in e)
                {
                    for (int i = 0; i < array1.Length; i++)
                    {
                        array1[i] = r;
                    }
                }
            }
            return array1;
        }
        public static int[][] FillingPockets(int[] array)
        {
            var pocket = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                int counter = 0;
                foreach (int e in array)
                {
                    if (e % 10 == i)
                        counter++;
                }
                pocket[i] = new int[counter];
                for (int j = 0; j < pocket[i].Length; j++)
                {
                    foreach (int e in array)
                    {
                        // чтобы записывалось все в свои места.(костыль!!!)
                        if (j != 0)
                        {
                            if (e == pocket[i][j - 1])
                            {
                                continue;
                            }
                        }
                        if (e % 10 == i)
                        {
                            pocket[i][j] = e;
                            break;
                        }
                    }
                }

            }
            return pocket;
        }
        public static int GetMaxDigit(int[] array)
        {
            var maxDigit = 0;
            foreach (var e in array)
            {
                var digit = GetCountOfDigits(e);
                if (digit > maxDigit)
                    maxDigit = digit;
            }
            return maxDigit;
        }
        public static int GetCountOfDigits(int number)
        {
            int countOfDigits = 0;
            while (number != 0)
            {
                number /= 10;
                countOfDigits++;
            }
            if (countOfDigits == 0)
                return 1;
            else
                return countOfDigits;
        }
        static void Main(string[] args)
        {
            var array = new int[] { 343, 57, 100, 856, 1486, 4, 0 };

            int[][] pocket = FillingPockets(array);
            int[] arrayOf = GetUnite(pocket);

            foreach (int e in arrayOf)
                Console.WriteLine(e);
            Console.WriteLine(" ");



            foreach (int[] e in pocket)
            {
                foreach (int r in e)
                {
                    Console.WriteLine(r);
                }
            }
        }
    }
}
