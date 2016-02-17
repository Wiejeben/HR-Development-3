using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            task1();

            // Do not automatically leave application
            Console.ReadKey(false);
        }

        // 1. Translate the Python-program below to Java or C#:
        static void task1()
        {
            string result = "";

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result = result + "*";
                }

                result = result + "\n";
            }

            Console.Write(result);
        }
    }
}
