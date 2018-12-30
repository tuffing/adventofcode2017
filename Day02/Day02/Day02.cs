using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day02
{
    public class Day02
    {
        private List<List<int>> _input;
        
        public Day02(string fileName)
        {
            _input = new List<List<int>>();
            var lines = GetFromResources("Day02." + fileName).Split('\n').ToList();

            foreach (var l in lines)
            {
                var line = l.Split(' ').Select(int.Parse).ToList();
                _input.Add(line);
            }

        }
        
        internal string GetFromResources(string resourceName)
        {
            Assembly assem = this.GetType().Assembly;
            using (Stream stream = assem.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public int PartOne()
        {
            var total = 0;
            foreach (var i in _input)
            {
                total += i.Max() - i.Min();
            }
            return total;
        }
        
        public int PartTwo()
        {
            var total = 0;
            foreach (var i in _input)
            {
                var diff = FindDiffs(i);
                if (diff > -1)
                {
                    total += diff;
                }
            }
            return total;
        }

        private int FindDiffs(IEnumerable<int> i)
        {
            Queue<int> q = new Queue<int>(i);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                foreach (var num in q)
                {
                    if (curr % num == 0 || num % curr == 0)
                    {
                        return curr > num ? (curr / num) : num / curr;
                    }
                }
            }

            return -1;
        }
    }
}