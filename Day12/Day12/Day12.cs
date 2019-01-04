using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day12
{
    public class Day12
    {
        private List<List<int>> _input;
        private Dictionary<int, HashSet<int>> _grps = new Dictionary<int, HashSet<int>>();

        public Day12(string fileName)
        {
            var lines = GetFromResources("Day12." + fileName).Split('\n').ToList();
            _input = new List<List<int>>();
            foreach (var l in lines)
            {
                _input.Add(Regex.Matches(l, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToList());
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


        public int PartOne()
        {
            var zeroIndex = 0;

            foreach (var line in _input)
            {
                var val = line[0];
                line.RemoveAt(0);
                int group = -1;
                
                foreach (var link in line)
                {
                    var keys = _grps.Keys.ToList();
                    foreach (var k in keys)
                    {
                        if (!_grps[k].Contains(link) || group == k)
                            continue;


                        if (group < 0)
                        {
                            _grps[k].Add(val);
                            group = k;
                        }
                        else
                        {
                            _grps[group].UnionWith(_grps[k]);
                            _grps.Remove(k);
                        }

                        if (_grps[group].Contains(0))
                            zeroIndex = group;
                    }
                }

                if (group >= 0) continue;
                
                _grps.Add(val, new HashSet<int>(new [] {val}));
                _grps[val].UnionWith(line);
            }
            
            return _grps[zeroIndex].Count;
        }

        public int PartTwo()
        {
            return _grps.Count;
        }
    }
}