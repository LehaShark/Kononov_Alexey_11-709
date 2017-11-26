using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Jopa1(2, 1, 0));
            Console.WriteLine(Jopa(4, 0, 1));
        }
        public static int Jopa (int n, int sum, int i)
        {
            sum += i;
            if (i < n)
            {
                i++;
                return Jopa(n, sum, i);
            }
            return sum;
        }
        public static string Jopa1 (int n, int i, int k)
        {
            if (i < n)
            {
                i *= 2;
                k += 1;
                return Jopa1(n, i, k);
            }
            else if (i == k)
                return "Yes";
            else
                return "No";
        }
        public static string Jopa2 (string n)
        {

        }
}
