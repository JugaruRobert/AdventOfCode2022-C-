using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions.Year2022.Day09
{
    public class Motion
    {
        public char Direction { get; set; }
        public int Moves { get; set; }

        public Motion(char direction, int moves)
        {
            Direction = direction;
            Moves = moves;
        }
    }
}
