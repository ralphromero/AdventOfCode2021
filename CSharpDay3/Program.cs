using CSharpDay3;

var items = CSharpDay3.Resources.Input.Split('\n');
var notEmpty = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();
Console.WriteLine("Advent of Code day 1");
Console.WriteLine("Part1");
Parts.Part1(notEmpty);
//Console.WriteLine("Part2");
//Parts.Part2(cleanedItems);
