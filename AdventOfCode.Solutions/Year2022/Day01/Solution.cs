using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2022, "Calorie Counting") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();
        long sum = 0, maxSum = 0;
        foreach (string line in lines)
        {
            if (line == string.Empty)
            {
                if (sum > maxSum) maxSum = sum;
                sum = 0;
                continue;
            }

            sum += long.Parse(line);
        }

        if (sum > maxSum) maxSum = sum;
        return maxSum.ToString();
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();

        List<long> allSums = new();
        long sum = 0;

        foreach (string line in lines)
        {
            if (line.Trim() == string.Empty)
            {
                allSums.Add(sum);
                sum = 0;
                continue;
            }

            sum += long.Parse(line);
        }

        allSums.Add(sum);
        allSums.Sort();

        long result = allSums[^1] + allSums[^2] + allSums[^3];
        return result.ToString();
    }
}
