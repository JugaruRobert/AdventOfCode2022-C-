using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day02;

class Solution : SolutionBase
{
    private readonly Dictionary<string, int> combinations = new()
    {
        { "A X", 4 },
        { "A Y", 8 },
        { "A Z", 3 },

        { "B X", 1 },
        { "B Y", 5 },
        { "B Z", 9 },

        { "C X", 7 },
        { "C Y", 2 },
        { "C Z", 6 }
    };

    private readonly Dictionary<string, string> replacements = new()
    {
        { "A X", "A Z" },
        { "A Y", "A X" },
        { "A Z", "A Y" },

        { "B X", "B X" },
        { "B Y", "B Y" },
        { "B Z", "B Z" },

        { "C X", "C Y" },
        { "C Y", "C Z" },
        { "C Z", "C X" }
    };

    public Solution() : base(02, 2022, "Rock Paper Scissors") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();
        long sum = 0;
        foreach(string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                sum += combinations[line];
            }
        }
        return sum.ToString();
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();
        long sum = 0;
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                sum += combinations[replacements[line]];
            }
        }
        return sum.ToString();
    }
}
