using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._17_sem
{
    class Program
    {
        public static int[] NumberOfDividers(int[] bigNumber)
        {
            var counter = new int[bigNumber.Length];
            var divider = new int[bigNumber.Length];
            while (CompareFirstMoreThenSecond(bigNumber, divider))
            {
                divider = AdditionOne(divider);
                var remainder = RemainderOfDivide(bigNumber, divider);
                if (NumberZero(remainder))
                    counter = AdditionOne(counter);
            }
            counter = ArrayFragmentation(counter);
            return counter;
        }
        public static bool NumberZero(int[] array)
        {
            bool a = true;
            foreach (int e in array)
            {
                if (e != 0)
                    a = false;
            }
            return a;
        }
        public static int[] AdditionOne(int[] array)
        {
            if (array[array.Length - 1] == 9)
            {
                array[array.Length - 2]++;
                array[array.Length - 1] = 0;
            }
            else
                array[array.Length - 1]++;
            return array;
        }
        public static bool CompareFirstMoreThenSecond(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length == secondArray.Length)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] > secondArray[i])
                        return true;
                    else if (firstArray[i] < secondArray[i])
                        return false;
                    else
                        continue;
                }
                return true;
            }
            return firstArray.Length > secondArray.Length;
        }
        public static int[] ArrayFragmentation(int[] array)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                    counter++;
                else break;
            }
            var newArray = new int[array.Length - counter];
            for (int i = counter; i < array.Length; i++)
            {
                newArray[i - counter] = array[i];
            }
            return newArray;
        }
        public static int[] DeterminationOfTheNumber(string bigNumber)
        {
            int[] arrayOfDigits = new int[bigNumber.Length];
            for (int i = 0; i < bigNumber.Length; i++)
            {
                string element = bigNumber.Substring(i, 1);
                arrayOfDigits[i] = Int16.Parse(element);
            }
            return arrayOfDigits;
        }
        public static int[] Subtraction(int[] minuend, int[] preSubtrahend)
        {
            // Создание и заполнение массива по длине сравнимого с первым, для удобства счета.
            var subtrahend = new int[minuend.Length];
            int differenceOfDigits = subtrahend.Length - preSubtrahend.Length;
            for (int i = preSubtrahend.Length - 1; i >= 0; i--)
            {
                subtrahend[i + differenceOfDigits] = preSubtrahend[i];
            }

            var quotient = new int[minuend.Length];
            for (int i = subtrahend.Length - 1; i >= 0; i--)
            {
                if (minuend[i] >= subtrahend[i])
                    quotient[i] = minuend[i] - subtrahend[i];
                else
                {
                    minuend[i - 1] -= 1;
                    minuend[i] += 10;
                    quotient[i] = minuend[i] - subtrahend[i];
                }
            }
            return quotient;
        }
        public static int[] RemainderOfDivide(int[] remainder, int[] divider)
        {
            while (CompareFirstMoreThenSecond(remainder, divider))
            { 
                    remainder = Subtraction(remainder, divider);
            }
            return remainder;
        }
        static void Main(string[] args)
        {
            var bigNumber = DeterminationOfTheNumber(Console.ReadLine());
            var countOfDivide = NumberOfDividers(bigNumber);
            foreach(int e in countOfDivide)
            {
                Console.Write(e);
            }
        }
    }
}