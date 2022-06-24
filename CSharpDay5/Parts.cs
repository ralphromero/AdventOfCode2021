using System.Text.RegularExpressions;

internal class Parts
{
    private string[] input;

    public Parts(string[] input)
    {
        this.input = input;
    }

    /// <summary>
    /// Filter out linear where x1=x2 || y1=y2
    /// Store an array of coordinate hits. Ignore white space.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    internal void Part1()
    {
        var rawCoordinates = input.Select(x => new CoordinateRange(x));
        //only horizontal or vertical
        var filteredCoordinates = rawCoordinates.Where(x => x.xStart == x.xEnd || x.yStart == x.yEnd).ToArray();
        
        var counts = new Dictionary<Coordinate, int>();
        foreach (var plot in filteredCoordinates)
        {
            foreach (var plot2 in plot.GetPlots())
            {
                if (!counts.ContainsKey(plot2))
                {
                    counts.Add(plot2, 1);
                }
                else
                {
                    counts[plot2] = counts[plot2] + 1;
                }
            }
        }

        Console.WriteLine("Counts: " + counts.Where(x => x.Value > 1).Count());
    }

    internal void Part2()
    {
        var rawCoordinates = input.Select(x => new CoordinateRange(x));

        var counts = new Dictionary<Coordinate, int>();
        foreach (var plot in rawCoordinates)
        {
            foreach (var plot2 in plot.GetPlots())
            {
                if (!counts.ContainsKey(plot2))
                {
                    counts.Add(plot2, 1);
                }
                else
                {
                    counts[plot2] = counts[plot2] + 1;
                }
            }
        }

        Console.WriteLine("Counts: " + counts.Where(x => x.Value > 1).Count());
    }

    private readonly struct Coordinate
    {
        public readonly int x;
        public readonly int y;

        public Coordinate(int x, int y)
        {
            this.y = y;
            this.x = x;
        }
    }

    private class CoordinateRange
    {
        public readonly int xStart;
        public readonly int yStart;
        public readonly int xEnd;
        public readonly int yEnd;

        public CoordinateRange(string input)
        {
            var lineEndRemoved = Regex.Replace(input, @"\t|\n|\r", "");
            var cleaned = lineEndRemoved.Replace(" -> ", ",");
            var stuff = cleaned.Split(',', StringSplitOptions.RemoveEmptyEntries);
            this.xStart = Convert.ToInt32(stuff[0]);
            this.yStart = Convert.ToInt32(stuff[1]);
            this.xEnd = Convert.ToInt32(stuff[2]);
            this.yEnd = Convert.ToInt32(stuff[3]);
        }

        public Coordinate[] GetPlots()
        {
            if (xStart == xEnd)
            {
                if (yStart < yEnd)
                {
                    return Enumerable.Range(yStart, (yEnd + 1)-yStart).Select(x => new Coordinate(xStart, x)).ToArray();
                }
                return Enumerable.Range(yEnd, (yStart + 1)-yEnd).Select(x => new Coordinate(xStart, x)).ToArray();

            }
            else if(yStart == yEnd)
            {
                if (xStart < xEnd)
                {
                    return Enumerable.Range(xStart, (xEnd + 1)-xStart).Select(x => new Coordinate(x, yStart)).ToArray();
                }

                return Enumerable.Range(xEnd, (xStart + 1)-xEnd).Select(x => new Coordinate(x, yStart)).ToArray();
            }
            else
            {
                //diagonal case
                var xGoingUp = xStart < xEnd ? true : false;
                var yGoingUp = yStart < yEnd ? true : false;

                var xPlots = xGoingUp ? Enumerable.Range(xStart, (xEnd + 1)-xStart).ToList() : Enumerable.Range(xEnd, (xStart + 1)-xEnd).Reverse().ToList();
                var yPlots = yGoingUp ? Enumerable.Range(yStart, (yEnd + 1)-yStart).ToList() : Enumerable.Range(yEnd, (yStart + 1)-yEnd).Reverse().ToList();
                return xPlots.Select(x => new Coordinate(x, yPlots[xPlots.IndexOf(x)])).ToArray();
            }
        }
    }
}