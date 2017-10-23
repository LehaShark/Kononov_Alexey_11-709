using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        public bool YesOrNo (string c, string d)
        {
            if (c.Length > d.Length)
            {
                int lengthA = c.Length;
                int lengthB = d.Length;
                int a = int.Parse(c);
                int b = int.Parse(d);
                int[] digitsA = new int[lengthA - 1];
                int[] digitsB = new int[lengthB - 1];
                while (a != 0)
                {
                    for (int i = 0; i <= lengthA - 1; i++)
                    {
                        digitsA[i] = a % 10;
                    }
                    a /= 10;
                }
                while (b != 0)
                {
                    for (int i = 0; i <= lengthB - 1; i++)
                    {
                        digitsB[i] = b % 10;
                    }
                    b /= 10;
                }
                for (int i = lengthB - 1; i >= 0; i -= 1)
                {
                    for (int j = lengthA - 1; j >= 0; j -= 1)
                    {
                        lengthA =
                        if(digitsB[i] == digitsA[j])
                    }
                }
            }
            else return false;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
