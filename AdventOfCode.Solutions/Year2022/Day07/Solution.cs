using AdventOfCode.Solutions.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day07;

class Solution : SolutionBase
{
    private readonly TreeNode root;

    public Solution() : base(07, 2022, "No Space Left On Device") 
    {
        root = ReadTree();
        UpdateSizes(root);
    }

    protected override string SolvePartOne()
    { 
        return PartOneRecursively(root).ToString();
    }

    private long PartOneRecursively(TreeNode node)
    {
        long count = (node.Size <= 100000 ? node.Size : 0);
        foreach (string child in node.Children.Keys)
        {
            count += PartOneRecursively(node.Children[child]);
        }
        return count;
    }

    protected override string SolvePartTwo()
    {
        long totalSpace = 70000000;
        long updateSize = 30000000;
        long availableSpace = totalSpace - root.Size;
        long requiredSpace = updateSize - availableSpace;
        return PartTwoRecursively(root, requiredSpace).ToString();
    }

    private long PartTwoRecursively(TreeNode node, long requiredSpace)
    {
        long minSize = node.Size > requiredSpace ? node.Size : long.MaxValue;
        foreach (string child in node.Children.Keys)
        {
            minSize = Math.Min(minSize, PartTwoRecursively(node.Children[child], requiredSpace));
        }
        return minSize;
    }

    private TreeNode ReadTree()
    {
        List<string> lines = Input.SplitByNewline(true, false).ToList();
        TreeNode rootNode = new(".");
        TreeNode current = rootNode;

        for (int i = 2; i < lines.Count; i++)
        {
            string line = lines[i];
            if (string.IsNullOrEmpty(line))
                continue;

            string[] parts = line.Split(' ');
            if (parts[0] == "$")
            {
                if (parts[1] == "ls")
                    continue;

                if (parts[2] == "..")
                {
                    current = current.Parent;
                }
                else
                {
                    current = current.Children[parts[2]];
                }
            }
            else if (parts[0] == "dir")
            {
                current.Children[parts[1]] = new(parts[1], current);
            }
            else
            {
                current.Size += long.Parse(parts[0]);
            }
        }

        return rootNode;
    }

    private long UpdateSizes(TreeNode node)
    {
        foreach (string child in node.Children.Keys)
        {
            node.Size += UpdateSizes(node.Children[child]);
        }
        return node.Size;
    }
}
