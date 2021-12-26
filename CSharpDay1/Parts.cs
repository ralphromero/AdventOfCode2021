using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDay1
{
    internal class Parts
    {
        public static void Part1(string[] items)
        {
            int count = 0;
            for (int i = 1; i < items.Length; i++)
            {
                try
                {
                    if (int.Parse(items[i]) > int.Parse(items[i - 1]))
                        count++;
                }
                catch (Exception) { }
            }
            Console.WriteLine("Total: " + count);
        }

        public static void Part2(string[] items)
        {
            var output = new string[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                var first = int.Parse(items[i]);
                var second = (i + 1) < items.Length ? int.Parse(items[i+1]) : 0;
                var third = (i + 2) < items.Length ? int.Parse(items[i + 2]) : 0;
                
                output[i] = Convert.ToString(first + second + third);
            }
            Part1(output);
        }
    }
}
