using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions.Year2022.Day09
{
    public class Knot
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public HashSet<(int, int)> Visited { get; } = new();

        public Knot (int x, int y)
        {
            X = x;
            Y = y;
            Visited.Add((x, y));
        }

        public void Move(char direction)
        {
            if (direction == 'R') X++;
            else if (direction == 'L') X--;
            else if (direction == 'U') Y++;
            else if (direction == 'D') Y--;

            Visited.Add((X, Y));
        }

        public void Follow(Knot knot)
        {
            if (Math.Abs(knot.X - X) < 2 && Math.Abs(knot.Y - Y) < 2)
            {
                return;
            }

            if (knot.X == X)
            {
                Y += (knot.Y > Y) ? 1 : -1;
            }
            else if (knot.Y == Y)
            {
                X += (knot.X > X) ? 1 : -1;
            } 
            else
            {
                X += (knot.X > X) ? 1 : -1;
                Y += (knot.Y > Y) ? 1 : -1;
            }

            Visited.Add((X, Y));
        }
    }
}
