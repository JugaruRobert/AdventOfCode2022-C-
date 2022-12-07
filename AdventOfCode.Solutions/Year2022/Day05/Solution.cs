using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2022.Day05;

class Solution : SolutionBase
{
    private IEnumerable<string> boxex;

    public Solution() : base(05, 2022, "Supply Stacks") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(true, false).ToList();
        int stacksLine = lines.FindIndex(line => line.StartsWith(" 1"));
        int stacksCount = lines[stacksLine].Trim().Last() - '0';

        List<Stack<string>> stacks = new();
        for (int i = 0; i < stacksCount; i++)
        {
            stacks.Add(new());
        }

        for (int i = stacksLine - 1; i >= 0; i--)
        {
            int stackIndex = 0;
            for (int j = 1; j < lines[i].Length; j += 4)
            {
                string box = lines[i][j].ToString();
                if (!string.IsNullOrWhiteSpace(box))
                {
                    stacks[stackIndex].Push(box);
                }
                stackIndex++;
            }
        }

        for (int i = stacksLine + 2; i < lines.Count; i++)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                string[] moves = lines[i].Split(' ');
                int boxCount = int.Parse(moves[1]);
                int stackFrom = int.Parse(moves[3]) - 1;
                int stackTo = int.Parse(moves[5]) - 1;

                for (int j = 0; j < boxCount; j++)
                {
                    stacks[stackTo].Push(stacks[stackFrom].Pop());
                }
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < stacks.Count; i++)
        {
            sb.Append(stacks[i].Peek());
        }

        return sb.ToString();
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(true, false).ToList();
        int stacksLine = lines.FindIndex(line => line.StartsWith(" 1"));
        int stacksCount = lines[stacksLine].Trim().Last() - '0';

        List<Stack<string>> stacks = new();
        for (int i = 0; i < stacksCount; i++)
        {
            stacks.Add(new());
        }

        for (int i = stacksLine - 1; i >= 0; i--)
        {
            int stackIndex = 0;
            for (int j = 1; j < lines[i].Length; j += 4)
            {
                string box = lines[i][j].ToString();
                if (!string.IsNullOrWhiteSpace(box))
                {
                    stacks[stackIndex].Push(box);
                }
                stackIndex++;
            }
        }

        for (int i = stacksLine + 2; i < lines.Count; i++)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                string[] moves = lines[i].Split(' ');
                int boxCount = int.Parse(moves[1]);
                int stackFrom = int.Parse(moves[3]) - 1;
                int stackTo = int.Parse(moves[5]) - 1;

                Stack<string> reverse = new();
                for (int j = 0; j < boxCount; j++)
                {
                    reverse.Push(stacks[stackFrom].Pop());
                }

                for (int j = 0; j < boxCount; j++)
                {
                    stacks[stackTo].Push(reverse.Pop());
                }
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < stacks.Count; i++)
        {
            sb.Append(stacks[i].Peek());
        }

        return sb.ToString();
    }
}
