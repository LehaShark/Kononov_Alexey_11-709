using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            if (x > y)
            {
                if (z > y)
                {
                    if (z > x)
                    {
                        Console.Write(z);
                        Console.Write("," + x);
                        Console.Write("," + y);
                    }
                    if (x > z)
                    {
                        Console.Write(x);
                        Console.Write("," + z);
                        Console.Write("," + y);
                    }
                }
                if (y > z)
                {
                    Console.Write(x);
                    Console.Write("," + y);
                    Console.Write("," + z);
                }
            }
            if (y > x)
            {
                if (z > x)
                {
                    if (z > y)
                    {
                        Console.Write(z);
                        Console.Write("," + y);
                        Console.Write("," + x);
                    }
                    if (y > z)
                    {
                        Console.Write(y);
                        Console.Write("," + z);
                        Console.Write("," + x);
                    }
                }
                if (x > z)
                {
                    Console.Write(y);
                    Console.Write("," + x);
                    Console.Write("," + z);
                }
            }
        }
    }
}
