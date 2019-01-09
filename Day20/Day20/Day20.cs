using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Day20
{
    public class Day20
    {
        private List<List<int>> _input;

        public Day20(string fileName)
        {
            var lines = GetFromResources("Day20." + fileName).Split('\n').ToList();
            _input = new List<List<int>>();
            foreach (var l in lines)
            {
                _input.Add(Regex.Matches(l, @"-?\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToList());
            } 
        }
        
        private string GetFromResources(string resourceName)
        {
            Assembly assem = this.GetType().Assembly;
            using (var stream = assem.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public int PartOne()
        {
            var accs = new List<int>();

            foreach (var p in _input)
            {
                accs.Add(Math.Abs(p[6]) + Math.Abs(p[7]) + Math.Abs(p[8]));
            }

            var min = accs.Min();
            var idxLowest = -1;
            var vel = int.MaxValue;

            for (var i = 0; i < accs.Count; i++)
            {
                var dist = Math.Abs(_input[i][3]) + Math.Abs(_input[i][4]) + Math.Abs(_input[i][5]);
                if (accs[i] == min && dist < vel)
                {
                    idxLowest = i;
                    vel = dist;
                }
            }
            
            return idxLowest;
        }

        public int PartTwo()
        {
            //
            //Increase the X velocity by the X acceleration.
            //    Increase the Y velocity by the Y acceleration.
            //    Increase the Z velocity by the Z acceleration.
            //    Increase the X position by the X velocity.
            //    Increase the Y position by the Y velocity.
            //    Increase the Z position by the Z velocity.

            for (int i = 0; i < 40; i++)
            {
                var coords = new Dictionary<string, List<int>>();
                for (int j = 0; j < _input.Count; j++)
                {
                    var p = _input[j];

                    if (p == null)
                        continue;
                    
                    //velocity
                    p[3] += p[6];
                    p[4] += p[7];
                    p[5] += p[8];
                    
                    //position
                    p[0] += p[3];
                    p[1] += p[4];
                    p[2] += p[5];
                    
                    var c = p[0] + "," + p[1] + "," + p[2];
                    
                    if (!coords.ContainsKey(c))
                        coords.Add(c, new List<int>());
                    coords[c].Add(j);
                }

                foreach (var coord in coords)
                {
                    if (coord.Value.Count <= 1)
                        continue;

                    foreach (var c in coord.Value)
                    {
                        _input[c] = null;
                    }
                }
            }

            var count = 0;
            foreach (var i in _input)
            {
                if (i != null)
                    count++;
            }

            return count;
        }
    }
}