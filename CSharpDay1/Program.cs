<<<<<<< HEAD
﻿using CSharpDay1;
var items = CSharpDay1.Properties.Resources.Input.Split('\n');
Console.WriteLine("Advent of Code day 1");
Console.WriteLine("Part1");
Parts.Part1(items);
Console.WriteLine("Part2");
Parts.Part2(items);
=======
﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine(CSharpDay1.Properties.Resources.Input);
var items = CSharpDay1.Properties.Resources.Input.Split('\n');
int count = 0;
for(int i = 1; i < items.Length; i++)
{
    try
    {
        if (int.Parse(items[i]) > int.Parse(items[i - 1]))
            count++;
    }
    catch (Exception) { }
}
Console.WriteLine("Total: " + count);
>>>>>>> 9273cbb09eb03498ca61046bad5fe1c21050895d
