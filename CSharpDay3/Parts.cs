using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDay3
{
    internal class Parts
    {
        private readonly string[] items;
        private readonly int[,] frequencies;
        private readonly string freqencyString;

        public Parts(string[] items)
        {
            this.items = items;
            this.frequencies = GetFrequencies();
            this.freqencyString = BuildFrequencyBinary();
        }
        internal void Part1()
        {
            var gamma = new StringBuilder(items.Length);
            for(int i = 0; i < frequencies.GetLength(1); i++)
            {
                //if equal, will be set to 1
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
            int epsilonValue = ConvertBinaryStringToDecimal(epsilon.ToString());

            Console.WriteLine($"Gamma is: {gammaValue}, Epsilon is: {epsilonValue}, Multiplied is: {gammaValue * epsilonValue}");
        }

        private int ConvertBinaryStringToDecimal(string binaryString)
        {
            return Convert.ToInt32(binaryString.TrimEnd('\r'), 2);
        }

        private string BuildFrequencyBinary()
        {
            var arrayLength = frequencies.GetLength(1);
            var output = new StringBuilder(arrayLength);
            for(int i=0; i< arrayLength; i++)
            {
                if (frequencies[0, i] > frequencies[1, i])
                {
                    output.Append('0');
                }
                else
                {
                    output.Append('1');
                }
            }
            Console.WriteLine("Frequency String: " + output.ToString());
            return output.ToString();
        }

        internal void Part2()
        {
            (IEnumerable<string>, int) findO2Rating(IEnumerable<string> items, int position)
            {
                if (items.Count() <= 1 || position >= items.First().Length)
                    return (items, position);
                int count0 = items.Where(x => x.ElementAt(position) == '0').Count();
                int count1 = items.Where(x => x.ElementAt(position) == '1').Count();
                if(count0 > count1)
                {
                    return findO2Rating(items.Where(x => x.ElementAt(position) == '0'), position + 1);
                }
                return findO2Rating(items.Where(x => x.ElementAt(position) == '1'), position + 1);
            }

            (IEnumerable<string>, int) findCO2Rating(IEnumerable<string> items, int position)
            {
                if (items.Count() <= 1 || position >= items.First().Length)
                    return (items, position);
                int count0 = items.Where(x => x.ElementAt(position) == '0').Count();
                int count1 = items.Where(x => x.ElementAt(position) == '1').Count();
                if (count1 >= count0)
                {
                    return findCO2Rating(items.Where(x => x.ElementAt(position) == '0'), position + 1);
                }
                return findCO2Rating(items.Where(x => x.ElementAt(position) == '1'), position + 1);
            }

            (IEnumerable<string> items, int position) o2Result = findO2Rating(items, 0);
            (IEnumerable<string> items, int position) co2Result = findCO2Rating(items, 0);
            var o2Raw = o2Result.items.First();
            var co2Raw = co2Result.items.First();
            Console.WriteLine("O2raw: " + o2Raw);
            Console.WriteLine("CO2raw: " + co2Raw);
            var o2Decimal = ConvertBinaryStringToDecimal(o2Raw);
            var co2Decimal = ConvertBinaryStringToDecimal(co2Raw);
            Console.WriteLine("Part2 Result: ");
            Console.WriteLine($"O2 in decimal: {o2Decimal}");
            Console.WriteLine($"CO2 in decimal: {co2Decimal}");
            Console.WriteLine($"Multiplied: {o2Decimal * co2Decimal}");
        }

        /// <summary>
        /// Get frequencies of 1 and 0 from an array.
        /// </summary>
        /// <param name="items"></param>
        /// <returns>First index = 0, second index = 1</returns>
        private int[,] GetFrequencies()
        {
            string sample = items[0].TrimEnd('\r');
            int[,] frequencies = new int[2, sample.Length];
            foreach (var item in items)
            {
                var singles = item.ToCharArray();
                for (int i = 0; i < sample.Length; i++)
                {
                    if (singles[i] == '0')
                    {
                        frequencies[0, i] += 1;
                    }
                    else
                    {
                        frequencies[1, i] += 1;
                    }
                }
            }
            for (int i = 0; i < frequencies.GetLength(1); i++)
            {
                Console.Write($"[{frequencies[0, i]}:{frequencies[1, i]}],");
            }
            Console.WriteLine();
            return frequencies;
        }
    }
}
