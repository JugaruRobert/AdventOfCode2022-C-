using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day11;

class Solution : SolutionBase
{
    public Solution() : base(11, 2022, "") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();
        List<List<long>> monkeys = new();
        List<long> inspections = new();

        for (int i = 0; i < lines.Count; i += 7)
        {
            int monkey = int.Parse(lines[i].Split(" ")[1].Split(":")[0]);
            monkeys.Add(new List<long>(lines[i + 1].Split(": ")[1].Split(", ").Select(item => long.Parse(item)).ToList()));
            inspections.Add(0);
        }

        for (int i = 0; i < 20; i++)
        {
            for (int monkey = 0; monkey < monkeys.Count; monkey++)
            {
                int startingLine = monkey * 7;
                string operation = lines[startingLine + 2].Split("= ")[1];
                int test = int.Parse(lines[startingLine + 3].Split("divisible by ")[1]);
                int trueMonkey = int.Parse(lines[startingLine + 4].Split("monkey ")[1]);
                int falseMonkey = int.Parse(lines[startingLine + 5].Split("monkey ")[1]);

                foreach (int item in monkeys[monkey])
                {
                    inspections[monkey]++;
                    long newWorryLevel = GetWorryLevel(item, operation);
                    newWorryLevel = (int)Math.Floor((double)newWorryLevel / 3);
                    if (newWorryLevel % test == 0)
                    {
                        monkeys[trueMonkey].Add(newWorryLevel);
                    }
                    else
                    {
                        monkeys[falseMonkey].Add(newWorryLevel);
                    }
                }

                monkeys[monkey].Clear();
            }
        }

        inspections.Sort();
        long monkeyLevel = inspections[^1] * inspections[^2];
        return monkeyLevel.ToString();
    }

    private long GetWorryLevel(long item, string operation)
    {
        string[] parts = operation.Split(" ");
        long left = parts[0] == "old" ? item : long.Parse(parts[0]);
        string op = parts[1];
        long right = parts[2] == "old" ? item : long.Parse(parts[2]);

        return op switch
        {
            "+" => left + right,
            "-" => left - right,
            "*" => left * right,
            _ => left / right,
        };
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();
        List<List<long>> monkeys = new();
        List<long> inspections = new();

        long factor = 1;
        for (int i = 0; i < lines.Count; i += 7)
        {
            int monkey = int.Parse(lines[i].Split(" ")[1].Split(":")[0]);
            monkeys.Add(new List<long>(lines[i + 1].Split(": ")[1].Split(", ").Select(item => long.Parse(item)).ToList()));
            inspections.Add(0);

            int test = int.Parse(lines[i + 3].Split("divisible by ")[1]);
            factor *= test;
        }

        for (int i = 0; i < 10000; i++)
        {
            for (int monkey = 0; monkey < monkeys.Count; monkey++)
            {
                int startingLine = monkey * 7;
                string operation = lines[startingLine + 2].Split("= ")[1];
                int test = int.Parse(lines[startingLine + 3].Split("divisible by ")[1]);
                int trueMonkey = int.Parse(lines[startingLine + 4].Split("monkey ")[1]);
                int falseMonkey = int.Parse(lines[startingLine + 5].Split("monkey ")[1]);

                foreach (long item in monkeys[monkey])
                {
                    inspections[monkey]++;
                    long newWorryLevel = GetWorryLevel(item, operation) % factor;
                    if (newWorryLevel % test == 0)
                    {
                        monkeys[trueMonkey].Add(newWorryLevel);
                    }
                    else
                    {
                        monkeys[falseMonkey].Add(newWorryLevel);
                    }
                }

                monkeys[monkey].Clear();
            }
        }

        inspections.Sort();
        long monkeyLevel = inspections[^1] * inspections[^2];
        return monkeyLevel.ToString();
    }
}
