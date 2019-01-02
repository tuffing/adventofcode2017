using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day07
{
    public struct Node
    {
        public string Name;
        public int Value;
        public List<Node> Children;
        public List<Node> Parent;

        public Node(string name, int value)
        {
            Name = name;
            Value = value;
            Parent = new List<Node>();
            Children = new List<Node>();
        }
    }
}