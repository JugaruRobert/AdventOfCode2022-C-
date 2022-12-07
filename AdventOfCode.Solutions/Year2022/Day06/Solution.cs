using AdventOfCode.Solutions.Utils;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day06;

class Solution : SolutionBase
{
    public Solution() : base(06, 2022, "Tuning Trouble") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        string buffer = lines[0];
        for (int i = 3; i < buffer.Length; i++)
        {
            HashSet<char> unique = new ()
            {
                buffer[i],
                buffer[i-1],
                buffer[i-2],
                buffer[i-3]
            };

            if (unique.Count == 4)
                return (i + 1).ToString();
        }

        return "";
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        string buffer = lines[0];
        for (int i = 13; i < buffer.Length; i++)
        {
            HashSet<char> unique = new();
            for (int j = 0; j <= 13; j++)
                unique.Add(buffer[i - j]);

            if (unique.Count == 14)
                return (i + 1).ToString();
        }

        return "";
    }
}
