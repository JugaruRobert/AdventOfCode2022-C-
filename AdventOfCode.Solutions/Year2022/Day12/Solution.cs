using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day12;

class Solution : SolutionBase
{
    public Solution() : base(12, 2022, "Hill Climbing Algorithm") { }

    protected override string SolvePartOne()
    {
        List<string> lines = Input.SplitByNewline(false, false).ToList();
        List<(int, int)> path = FindShortestPath(lines, 'S', 'E');
        return (path.Count - 1).ToString();
    }

    protected override string SolvePartTwo()
    {
        List<string> lines = Input.SplitByNewline(false, false).ToList();
        List<(int, int)> path = FindShortestPath(lines, 'E', 'a');
        return (path.Count - 1).ToString();
    }

    private List<(int, int)> FindShortestPath(List<string> map, char start, char end)
    {
        bool reverse = GetHeight(start) > GetHeight(end);
        (int, int) root = FindCoordonates(map, start);
        HashSet<(int, int)> visited = new();
        Queue<List<(int, int)>> queue = new();

        queue.Enqueue(new List<(int, int)> { root });
        visited.Add(root);

        while (queue.Count > 0)
        {
            List<(int, int)> path = queue.Dequeue();
            (int x, int y) = path.Last();
            if (map[x][y] == end)
            {
                return path;
            }

            List<(int, int)> neighbors = GetNeightbors(map, x, y, reverse);
            foreach((int, int) next in neighbors)
            {
                if (!visited.Contains(next))
                {
                    List<(int, int)> newPath = path.ToList();
                    newPath.Add(next);
                    visited.Add(next);
                    queue.Enqueue(newPath);
                }
            }
        }

        return new List<(int, int)>();
    }

    private List<(int, int)> GetNeightbors(List<string> map, int x, int y, bool reverse)
    {
        int rows = map.Count, cols = map.First().Length;
        List<(int, int)> neighbors = new();
        List<(int, int)> directions = new() { (1, 0), (-1, 0), (0, 1), (0, -1) };
        char height = GetHeight(map[x][y]);
        foreach((int dx, int dy) in directions)
        {
            int neighX = x + dx, neighY = y + dy;
            if ((0 <= neighX && neighX < rows) && (0 <= neighY && neighY < cols))
            {
                char newHeight = GetHeight(map[neighX][neighY]);
                
                if ((reverse && newHeight + 1 >= height) ||
                    (!reverse && newHeight - 1 <= height))
                {
                    neighbors.Add((neighX, neighY));
                }
            }
        }

        return neighbors;
    }

    private char GetHeight(char point)
    {
        return point switch
        {
            'S' => 'a',
            'E' => 'z',
            _ => point,
        };
    }
    private (int, int) FindCoordonates(List<string> map, char character)
    {
        for (int i = 0; i < map.Count; i++)
        {
            int index = map[i].IndexOf(character);
            if (index > -1)
            {
                return (i, index);
            }
        }

        return (-1, -1);
    }
}
