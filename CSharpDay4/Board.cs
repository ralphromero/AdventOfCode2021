using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDay4
{
    internal class Board
    {
        //var winSequences = new List<int>();
        public Board(string[] board)
        {
            if (board.Length != 5)
                throw new ArgumentException("Board should be 5x5");
            for(int i=0; i<board.Length; i++)
            {

            }
        }
    }
}
