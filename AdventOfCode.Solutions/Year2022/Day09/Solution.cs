using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day09;

class Solution : SolutionBase
{
    private List<Motion> motions;

    public Solution() : base(09, 2022, "Rope Bridge")
    {
        motions = Input.SplitByNewline(false, true).Select(motion =>
        {
            string[] parts = motion.Split(' ');
            return new Motion(parts[0][0], int.Parse(parts[1]));
        }).ToList();
    }

    protected override string SolvePartOne()
    {
        Rope rope = new(2);
        rope.PerformMotions(motions);
        Knot tail = rope.Knots.Last();
        return tail.Visited.Count.ToString();
    }

    protected override string SolvePartTwo()
    {
        Rope rope = new(10);
        rope.PerformMotions(motions);
        Knot tail = rope.Knots.Last();
        return tail.Visited.Count.ToString();
    }
}
