internal class Parts
{
    private readonly string[] input;
    private readonly int[] bingoCall;

    public IEnumerable<string[]> Boards { get; }

    public Parts(string[] input)
    {
        this.input = input;
        this.bingoCall = input[0].Split(',').Select(x=>Convert.ToInt32(x)).ToArray();
        this.Boards = GetBoards();
    }

    internal void Part1()
    {
        (int lowestMax, string[] currentBoard) = (int.MaxValue, null);
        foreach (var board in Boards)
        {
            var boardArray = new int[5,5];
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                var b = SplitBoardItem(board[i]);
                for(int j = 0; j < b.Length; j++)
                {
                    boardArray[i,j] = b[j];
                }
            }
            //verticals
            var vertSequence = new int[5];
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for(int j = 0;j < vertSequence.Length; j++)
                {
                    vertSequence[j] = boardArray[j,i];
                }
                var max = EvaluateMax(vertSequence);
                if (max != null && max < lowestMax)
                {
                    lowestMax = (int)max;
                    currentBoard = board;
                    Console.WriteLine("New winner:" + string.Join(',', vertSequence) + " with lowest max: " + lowestMax);
                }
            }
            //horizontals
            for (int i = 0; i < board.Length; i++)
            {
                var b = SplitBoardItem(board[i]);
                var max = EvaluateMax(b);
                if(max != null && max < lowestMax)
                {
                    lowestMax = (int)max;
                    currentBoard = board;
                    Console.WriteLine("New winner:" + string.Join(',',b) + " with lowest max: " + lowestMax);
                }
            }
        }
        Console.WriteLine("Current Board");
        for(int i = 0;i < 5;i++)
        {
            Console.WriteLine(currentBoard[i]);
        }
        int result = ScoreBoard(lowestMax, currentBoard);
        Console.WriteLine("Score of winning board: " + result);
    }

    private static int[] SplitBoardItem(string line)
    {
        string[] temp = { line.Substring(0,2), line.Substring(3,2), line.Substring(6,2), line.Substring(9,2), line.Substring(12,2) };
        return temp.Select(x => Convert.ToInt32(x)).ToArray();
    }

    /// <summary>
    /// Determine final score of winning board
    /// </summary>
    /// <param name="maxValue">is also the winning number</param>
    /// <param name="board"></param>
    /// <returns></returns>
    private int ScoreBoard(int maxValue, string[] board)//TODO
    {
        var sequence = board.SelectMany(x => SplitBoardItem(x));
        var callSubset = bingoCall[0..(maxValue+1)];
        var markedRemoved = sequence.Where(x=>!callSubset.Contains(x));
        var summed = markedRemoved.Sum();
        Console.WriteLine($"Sum: {summed}");
        return summed * bingoCall[maxValue];
    }

    /// <summary>
    /// Finds the max index value in a sequence
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    private int? EvaluateMax(int[] sequence)
    {
        var found = sequence.Select(x => Array.IndexOf(bingoCall, x));
        //If value not found in bingo call, then sequence can not call bingo.
        if (found.Contains(-1))    
            return null;
        return found.Max();
    }

    private IEnumerable<string[]> GetBoards()
    {
        var boards = new List<string[]>();
        for (int i = 1; i < input.Length-1; i += 6)
        {
            var x = input[(i + 1)..(i + 6)];
            boards.Add(x);
        }
        return boards;
    }
}