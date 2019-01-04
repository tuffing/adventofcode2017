using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Day11
{
    public class Day11
    {
        private List<string> _input;
        private int _max = 0;
        
        public Day11(string fileName)
        {
            _input = GetFromResources("Day11." + fileName).Split(',').ToList();
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

        public int PartOne()
        {
            var dirs = new Dictionary<string, int[]>();
            dirs.Add("n", new [] {0,1,-1});
            dirs.Add("ne", new [] {1,0,-1});
            dirs.Add("se", new [] {1,-1,0});
            dirs.Add("s", new [] {0,-1,1});
            dirs.Add("sw", new [] {-1,0,1});
            dirs.Add("nw", new [] {-1,1,0});

            var q = new Queue<string>(_input);

            var coords = new[] {0, 0, 0};
            var distance = 0;
            
            while (q.Count > 0)
            {
                var modi = dirs[q.Dequeue()];
                coords[0] += modi[0];
                coords[1] += modi[1];
                coords[2] += modi[2];

                distance = (Math.Abs(coords[0]) + Math.Abs(coords[1]) + Math.Abs(coords[2])) / 2;

                if (distance > _max)
                    _max = distance;

            }

            return distance;
        }

        public int PartTwo()
        {
            return _max;
        }

    }
}