using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDay3
{
    internal class Parts
    {
        internal static void Part1(string[] items)
        {
            var sample = items[0].Substring(0, items[0].Length - 1); //remove line ending
            var frequencies = new int[2, sample.Length];
            foreach (var item in items)
            {
                var singles = item.ToCharArray();
                for(int i = 0; i < sample.Length; i++)
                {
                        if (singles[i] == '0')
                        {
                            frequencies[0, i] += 1;
                        }
                        else
                        {
                            frequencies[1,i] += 1;
                        }
                }
            }
            for (int i = 0; i < frequencies.GetLength(1); i++)
            {
                Console.Write($"[{frequencies[0, i]}:{frequencies[1, i]}],");
            }
            Console.WriteLine();

            var gamma = new StringBuilder(items.Length);
            for(int i = 0; i < frequencies.GetLength(1); i++)
            {
                if(frequencies[0,i] > frequencies[1,i])
                {
                    gamma.Append('0');
                }
                else
                {
                    gamma.Append('1');
                }
            }
            
            Console.WriteLine($"Gammaraw: {gamma.ToString()}");
            int gammaValue = Convert.ToInt32(gamma.ToString(), 2);
            
            var epsilon = new StringBuilder(items.Length);
            foreach(var item in gamma.ToString().ToCharArray())
            {
                if(item == '0')
                {
                    epsilon.Append('1');
                }
                else
                {
                    epsilon.Append('0');
                }
            }
            Console.WriteLine($"Epsilonraw: {epsilon.ToString()}");
            int epsilonValue = Convert.ToInt32(epsilon.ToString(), 2);

            Console.WriteLine($"Gamma is: {gammaValue}, Epsilon is: {epsilonValue}, Multiplied is: {gammaValue * epsilonValue}");
        }

        

        internal static void Part2(string[] items)
        {
            throw new NotImplementedException();
        }
    }
}
