var items = CSharpDay2.Resources.Input.Split('\n');
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
    //Console.WriteLine($"Horizontal: {horizontal}, Vertical: {vertical}, Multiplied: {horizontal * vertical}");
    //Console.ReadLine();
}

Console.WriteLine($"Horizontal: {horizontal}, Vertical: {vertical}, Multiplied: {horizontal * vertical}");