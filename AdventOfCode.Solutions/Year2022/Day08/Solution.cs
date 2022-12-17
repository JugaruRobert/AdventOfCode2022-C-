using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day08;

class Solution : SolutionBase
{
    public Solution() : base(08, 2022, "Treetop Tree House") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(false, false).ToList();
        int[,] trees = new int[lines.Count, lines[0].Length];

        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                trees[i, j] = int.Parse(lines[i][j].ToString());
            }
        }

        HashSet<(int, int)> visited = new();
        int visibleTrees = 0;
        for (int i = 0; i < trees.GetLength(0); i++)
        {
            int min = -1;
            for (int j = 0; j < trees.GetLength(1); j++)
            {
                if (trees[i, j] > min)
                {
                    min = trees[i, j];
                    if (!visited.Contains((i, j)))
                    {
                        visibleTrees++;
                        visited.Add((i, j));
                    }
                }
            }
        }

        for (int j = 0; j < trees.GetLength(1); j++)
        {
            int min = -1;
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                if (trees[i, j] > min)
                {
                    min = trees[i, j];
                    if (!visited.Contains((i, j)))
                    {
                        visibleTrees++;
                        visited.Add((i, j));
                    }
                }
            }
        }

        for (int i = 0; i < trees.GetLength(0); i++)
        {
            int min = -1;
            for (int j = trees.GetLength(1) - 1; j >= 0; j--)
            {
                if (trees[i, j] > min)
                {
                    min = trees[i, j];
                    if (!visited.Contains((i, j)))
                    {
                        visibleTrees++;
                        visited.Add((i, j));
                    }
                }
            }
        }

        for (int j = 0; j < trees.GetLength(1); j++)
        {
            int min = -1;
            for (int i = trees.GetLength(0) - 1; i >= 0; i--)
            {
                if (trees[i, j] > min)
                {
                    min = trees[i, j];
                    if (!visited.Contains((i, j)))
                    {
                        visibleTrees++;
                        visited.Add((i, j));
                    }
                }
            }
        }
        return visibleTrees.ToString();
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(false, false).ToList();
        int[,] trees = new int[lines.Count, lines[0].Length];

        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                trees[i, j] = int.Parse(lines[i][j].ToString());
            }
        }

        long score = 0;
        for (int i = 1; i < trees.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < trees.GetLength(1) - 1; j++)
            {
                score = Math.Max(score, CheckScenicScore(trees, i, j));
            }
        }

        return score.ToString();
    }

    private int CheckScenicScore(int[,] trees, int i, int j)
    {
        int score = 1, count = 0;

        int auxI = i - 1;
        while (auxI >= 0)
        {
            count++;
            if (trees[auxI, j] >= trees[i, j])
                break;
            auxI--;
        }

        score *= count;

        count = 0;
        auxI = i + 1;
        while (auxI < trees.GetLength(0))
        {
            count++;
            if (trees[auxI, j] >= trees[i, j])
                break;
            auxI++;
        }

        score *= count;

        count = 0;
        int auxJ = j - 1;
        while (auxJ >= 0)
        {
            count++;
            if (trees[i, auxJ] >= trees[i, j])
                break;
            auxJ--;
        }

        score *= count;
        count = 0;
        auxJ = j + 1;
        while (auxJ < trees.GetLength(1))
        {
            count++;
            if (trees[i, auxJ] >= trees[i, j])
                break;
            auxJ++;
        }

        score *= count;
        return score;
    }
}
