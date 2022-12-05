using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day03;

class Solution : SolutionBase
{
    public Solution() : base(03, 2022, "Rucksack Reorganization") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(true, true).ToList();
        long sum = 0;
        foreach (string line in lines)
        {
            HashSet<char> unique = new HashSet<char>();
            for (int i = 0; i < line.Length / 2; i++)
            {
                unique.Add(line[i]);
            }

            for (int i = line.Length / 2; i < line.Length; i++)
            {
                if (unique.Contains(line[i]))
                {
                    if (line[i] >= 'a' && line[i] <= 'z')
                    {
                        sum += line[i] - 'a' + 1;
                    } 
                    else
                    {
                        sum += line[i] - 'A' + 27;
                    }
                    break;
                }
            }
        }

        return sum.ToString();
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(false, true).ToList();
        long sum = 0;
        for (int i = 0; i < lines.Count; i += 3)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                break;
            }

            Dictionary<char, int> count = new ();
            UpdateUniqueItemCount(lines[i], count);
            UpdateUniqueItemCount(lines[i + 1], count);
            UpdateUniqueItemCount(lines[i + 2], count);

            foreach (char letter in count.Keys)
            {
                if (count[letter] == 3)
                {
                    if (letter >= 'a' && letter <= 'z')
                    {
                        sum += letter - 'a' + 1;
                    }
                    else
                    {
                        sum += letter - 'A' + 27;
                    }

                    break;
                }
            }
        }
        return sum.ToString();
    }

    private void UpdateUniqueItemCount(string line, Dictionary<char, int> count)
    {
        HashSet<char> unique = new ();
        foreach(char letter in line)
        {
            if (unique.Contains(letter))
            {
                continue;
            }

            count[letter] = count.GetValueOrDefault(letter, 0) + 1;
            unique.Add(letter);
        }
    }
}
