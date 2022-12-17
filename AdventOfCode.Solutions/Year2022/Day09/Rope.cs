using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions.Year2022.Day09
{
    public class Rope
    {
        public List<Knot> Knots { get; }

        public Rope(int numberOfKnots)
        {
            Knots = Enumerable.Range(0, numberOfKnots).Select(_ => new Knot(0, 0)).ToList();
        }

        public void PerformMotions(List<Motion> motions)
        {
            foreach (Motion motion in motions)
            {
                for (int i = 0; i < motion.Moves; i++)
                {
                    Knots[0].Move(motion.Direction);
                    for (int k = 1; k < Knots.Count; k++)
                    {
                        Knots[k].Follow(Knots[k-1]);
                    }
                }
            }
        }
    }
}
