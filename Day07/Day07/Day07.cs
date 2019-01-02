using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Day07
{
    public class Day07
    {
        private Node _tree;
        
        public Day07(string fileName)
        {
            var input = GetFromResources("Day07." + fileName).Split('\n').ToList();
            
            var nodes = new Dictionary<string, Node>();
            
            //build the nodes
            foreach (var i in input)
            {
                var node = ProcessNode(i);
                nodes.Add(node.Name, node);
            }
            
            //build the tree
            foreach (var i in input)
            {
                var parts = i.Split(' ').ToList();
                var node = nodes[parts[0]];

                parts.Reverse();
                foreach (var ele in parts)
                {
                    if (ele[0] == '(' || ele == "->")
                        break;

                    var name = ele.Replace(",", "");
                    
                    node.Children.Add(nodes[name]);
                    var child = nodes[name];
                    child.Parent.Add(node);
                }
            }
            
            //find the parent
            foreach (var n in nodes.Values)
            {
                if (n.Parent.Count != 0) continue;
                
                _tree = n;
                break;
            }
        }

        private string GetFromResources(string resourceName)
        {
            var assem = this.GetType().Assembly;
            using (Stream stream = assem.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private Node ProcessNode(string line)
        {
            var parts = line.Split(' ');
            var regex = new Regex(@"\((.*?)\)");
            var matches = regex.Matches(parts[1]);
            
            //var re = Regex.Matches(parts[1], @"\((.*?)\)");
            var m = matches[0];
            return new Node(parts[0], int.Parse(m.Groups[1].Value));

        }


        public string PartOne()
        {
            return _tree.Name;
        }

        public int PartTwo()
        {
            var answer = 0;

            FindUnbalanced(_tree, ref answer);
            
            return answer;
        }

        public int FindUnbalanced(Node n, ref int answer)
        {
            var totals = new List<int>();

            if (n.Children.Count == 0)
                return n.Value;

            foreach (var child in n.Children)
                totals.Add(FindUnbalanced(child, ref answer));
            
            var g = totals.GroupBy(i => i);

            if (answer > 0 || g.Count() == 1)
                return totals.Sum() + n.Value;

            var min = totals.Min();
            var max = totals.Max();

            foreach (var groups in g)
            {
                if (groups.Count() == 1)
                {
                    var ind = totals.IndexOf(groups.Key == min ? min : max);
                    var val = n.Children[ind].Value;
                    answer = groups.Key == min ? val + (max - min) : val - (max - min);
                }
            }

            return totals.Sum() + n.Value;

        }
    }
}