// See https://aka.ms/new-console-template for more information
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