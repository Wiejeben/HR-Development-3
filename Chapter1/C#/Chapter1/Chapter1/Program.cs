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
            Console.WriteLine(smiley(20));

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
                    result += "*";
                }

                result += "\n";
            }

            Console.Write(result);
        }

        // Write a program that draws a smiley on the console
        static string smiley(int diameter)
        {
            string result = "";
            int center_x = diameter / 2;
            int center_y = diameter / 2;

            for (int y = 0; y <= diameter; y++)
            {
                for (int x = 0; x <= diameter; x++)
                {
                    int distance_x = x - center_x;
                    int distance_y = y - center_y;
                    decimal distance = Convert.ToDecimal(Math.Sqrt(Math.Pow(distance_x, 2) + Math.Pow(distance_y, 2)) + 1);
                    int diameter_div3 = Convert.ToInt32(Math.Floor(diameter / 3.0));
                    bool isOoghoogte = y == diameter_div3;

                    bool isLinkeroog = x == diameter_div3;
                    bool isRechteroog = x == Math.Floor(Convert.ToDecimal(diameter_div3 + diameter) / 2 - 1);

                    bool isMondhoogte = y == 2 * (diameter_div3);
                    bool isMond = Math.Abs(x - center_x) < diameter / 4;

                    // implicit truncation to int with /2 for a more healthy face
                    if (Convert.ToDouble(Math.Ceiling(distance)) == Convert.ToDouble(Math.Ceiling(diameter / 2.0)))
                    {
                        result += "#";
                    }
                    else
                    {
                        if (isOoghoogte && (isLinkeroog || isRechteroog))
                        {
                            result += "0";
                        }
                        else if (isMondhoogte && isMond)
                        {
                            result += "-";
                        }
                        else
                        {
                            result += " ";
                        }
                    }
                }

                result += "\n";
            }

            return result;
        }
    }
}
