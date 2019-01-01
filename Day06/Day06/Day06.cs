using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day06
{
    public class Day06
    {
        private List<int> _input;
        
        public Day06(string fileName)
        {
            _input = GetFromResources("Day06." + fileName).Split(' ').Select(int.Parse).ToList();
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
            var tested = new HashSet<string>();
            var working = new List<int>(_input);
            
            while (true)
            {
                var maxIndex = 0;
                var max = 0;

                for (int i = 0; i < working.Count; i++)
                {
                    if (working[i] > max)
                    {
                        maxIndex = i;
                        max = working[i];
                    }
                }

                working[maxIndex] = 0;
                while (max > 0)
                {
                    maxIndex++;
                    working[(maxIndex % working.Count)]++;
                    max--;
                }

                var val = string.Join(" ", working);
                if (tested.Contains(val))
                {
                    return tested.Count + 1;
                }

                tested.Add(val);
            }
        }


        public int PartTwo()
        {
            var tested = new Dictionary<string, int>();
            var working = new List<int>(_input);
            
            while (true)
            {
                var maxIndex = 0;
                var max = 0;

                for (var i = 0; i < working.Count; i++)
                {
                    if (working[i] <= max) continue;
                    maxIndex = i;
                    max = working[i];
                }

                working[maxIndex] = 0;
                while (max > 0)
                {
                    maxIndex++;
                    working[(maxIndex % working.Count)]++;
                    max--;
                }

                var val = string.Join(" ", working);
                if (tested.ContainsKey(val))
                {
                    return tested.Count - tested[val];
                }

                tested.Add(val, tested.Count);
            }
        }

    }
}