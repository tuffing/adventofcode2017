using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
{
    public class Day02
    {
        private List<List<int>> _input;
        
        public Day02(string fileName)
        {
            _input = new List<List<int>>();
            List<string> lines = File.ReadAllLines(fileName).ToList();

            foreach (var l in lines)
            {
                var line = l.Split(' ').Select(int.Parse).ToList();
                _input.Add(line);
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