using CSharpDay5;

var items = CSharpDay5.Resources.Input.Split('\n');
//var items = CSharpDay5.Resources.Sample.Split('\n');
var notEmpty = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();
Console.WriteLine("Advent of Code day 5");
Parts parts = new Parts(notEmpty);
Console.WriteLine("Part1");
parts.Part1();