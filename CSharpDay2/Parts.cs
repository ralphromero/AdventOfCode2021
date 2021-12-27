using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDay2
{
    internal class Parts
    {
        public static void Part1(string[] items)
        {
            int horizontal = 0;
            int vertical = 0;
            foreach (var item in items)
            {
                if (item.StartsWith("forward"))
                    horizontal += int.Parse(item.Split(' ')[1]);
                if (item.StartsWith("down"))
                    vertical += int.Parse(item.Split(' ')[1]);
                if (item.StartsWith("up"))
                    vertical -= int.Parse(item.Split(' ')[1]);
            }

            Console.WriteLine($"Horizontal: {horizontal}, Vertical: {vertical}, Multiplied: {horizontal * vertical}");
        }

        public static void Part2(string[] items)
        {
            int horizontal = 0;
            int aim = 0;
            int vertical = 0;

            foreach (var item in items)
            {
                if (item.StartsWith("down"))
                    aim += int.Parse(item.Split(' ')[1]);
                if (item.StartsWith("up"))
                    aim -= int.Parse(item.Split(' ')[1]);
                if (item.StartsWith("forward"))
                {
                    var forwardValue = int.Parse(item.Split(' ')[1]);
                    horizontal += forwardValue;
                    vertical += aim * forwardValue;
                }
            }
            Console.WriteLine($"Horizontal: {horizontal}, Vertical: {vertical}, Multiplied: {horizontal * vertical}");
        }
    }
}
