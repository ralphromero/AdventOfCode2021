using CSharpDay3;

var items = CSharpDay3.Resources.Input.Split('\n');
//var items = CSharpDay3.Resources.Input_sample.Split('\n');
var notEmpty = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();
Console.WriteLine("Advent of Code day 1");
Parts parts = new Parts(notEmpty);
Console.WriteLine("Part1");
parts.Part1();
Console.WriteLine("Part2");
parts.Part2();
