using CSharpDay4;

var items = CSharpDay4.Resources.Input.Split('\n');
//var items = CSharpDay4.Resources.Sample.Split('\n');
var notEmpty = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();
Console.WriteLine("Advent of Code day 4");
Parts parts = new Parts(notEmpty);
Console.WriteLine("Part1");
parts.Part1();
Console.WriteLine("Part2");
parts.Part2();