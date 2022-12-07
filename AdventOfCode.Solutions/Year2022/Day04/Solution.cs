using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day04;

class Solution : SolutionBase
{
    public Solution() : base(04, 2022, "Camp Cleanup") { }

    protected override string SolvePartOne()
    {
        int nrPairs = 0;
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        foreach(string line in lines)
        {
            string[] pairs = line.Split(',');
            string[] sectionOne = pairs[0].Split("-");
            string[] sectionTwo = pairs[1].Split("-");

            long a = int.Parse(sectionOne[0]);
            long b = int.Parse(sectionOne[1]);
            long x = int.Parse(sectionTwo[0]);
            long y = int.Parse(sectionTwo[1]);

            if ((a >= x && b <= y) || (x >= a && y <= b))
            {
                nrPairs++;
            }
        }

        return nrPairs.ToString();
    }

    protected override string SolvePartTwo()
    {
        int nrPairs = 0;
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        foreach (string line in lines)
        {
            string[] pairs = line.Split(',');
            string[] sectionOne = pairs[0].Split("-");
            string[] sectionTwo = pairs[1].Split("-");

            long a = int.Parse(sectionOne[0]);
            long b = int.Parse(sectionOne[1]);
            long x = int.Parse(sectionTwo[0]);
            long y = int.Parse(sectionTwo[1]);

            if (b < x || a > y)
            {
                continue;
            }

            nrPairs++;
        }

        return nrPairs.ToString();
    }
}
