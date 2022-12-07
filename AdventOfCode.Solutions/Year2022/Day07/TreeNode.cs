using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions.Year2022.Day07
{
    public class TreeNode
    {
        public string Name { get; set; }
        public TreeNode Parent { get; set; }
        public long Size { get; set; }
        public Dictionary<string, TreeNode> Children { get; set; }

        public TreeNode(string name, TreeNode parent = null)
        {
            Name = name;
            Parent = parent;
            Size = 0;
            Children = new();
        }
    }
}
