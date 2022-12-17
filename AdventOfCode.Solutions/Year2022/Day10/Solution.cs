using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day10;

class Solution : SolutionBase
{
    public Solution() : base(10, 2022, "Cathode-Ray Tube") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        List<int> cycles = new() { 20, 60, 100, 140, 180, 220 };
        long result = 0;
        foreach (int cycle in cycles)
        {
            long cycleResult = GetRegisterValue(lines, cycle);
            result += (cycleResult * cycle);
        }
        return result.ToString();
    }

    private long GetRegisterValue(List<string> lines, int cycles)
    {
        long value = 1;
        int lineIndex = 0;
        while (cycles > 1)
        {
            cycles--;
            string[] instruction = lines[lineIndex].Split(' ');
            if (instruction[0] == "addx")
            {
                if (cycles > 1)
                {
                    value += long.Parse(instruction[1]);
                    cycles--;
                }
            }

            lineIndex++;
        }

        return value;
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        int x = 1, lineIndex = 0;
        bool addx = false;
        for (int row = 0; row < 6; row++)
        {
            for (int pixel = 0; pixel < 40; pixel++)
            {
                string[] instruction = lines[lineIndex].Split(' ');
                Console.Write((pixel >= (x - 1) && pixel <= (x + 1)) ? "#" : ".");

                if (addx)
                {
                    addx = false;
                    x += int.Parse(instruction[1]);
                    lineIndex++;
                    continue;
                }

                if (instruction[0] == "addx")
                {
                    addx = true;
                    continue;
                }

                lineIndex++;
            }
        }

        return "See the pattern above :)";
    }
}
