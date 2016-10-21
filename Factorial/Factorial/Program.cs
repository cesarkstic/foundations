using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int i;
            int factor = 1;

            Console.Write("Enter your number: ");
            x = Int32.Parse(Console.ReadLine());

            for (i = 1; i <= x; i++)
            {
                factor = factor * i;
            }

            Console.Write("Factorial is: ");
            Console.WriteLine(factor);
            Console.ReadLine();
        }
    }
}
