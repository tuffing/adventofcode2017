using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day24
{
    public class Day24
    {
        private List<int> _one;
        private List<int> _two;
        public Day24(string fileName)
        {
            var input = GetFromResources("Day24." + fileName).Split('\n').ToList();
            _one = new List<int>();
            _two = new List<int>();
            
            foreach (var line in input)
            {
                var split = line.Split('/');
                _one.Add(int.Parse(split[0]));
                _two.Add(int.Parse(split[1]));
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

        public int PartOne(out int longestStrength)
        {
            longestStrength = 0;
            var zeroIndexes = new List<int>();
            var strengths = new List<int>();
            var lengths = new List<int>();
            
            
            zeroIndexes.AddRange(Enumerable.Range(0, _one.Count).Where(i => _one[i] == 0).ToArray());
            zeroIndexes.AddRange(Enumerable.Range(0, _two.Count).Where(i => _two[i] == 0).ToArray());

            foreach (var n in zeroIndexes)
            {
                BuildChain(0, n, _one[n] == 0 ? _two[n] : _one[n], 0, strengths, _one, _two, lengths);
            }

            var longest = lengths.Max();
            longestStrength = Enumerable.Range(0, lengths.Count).Where(i => lengths[i] == longest).Select(k => strengths[k]).Concat(new[] {0}).Max();


            return strengths.Max();
        }

        private void BuildChain(int count, int index, int nextMatch, int currentStrength, ICollection<int> strengths, IEnumerable<int> listOne, IEnumerable<int> listTwo, ICollection<int> lengths)
        {
            var one = new List<int>(listOne);
            var two = new List<int>(listTwo);
            count++;
            
            one.RemoveAt(index);
            two.RemoveAt(index);
            
            var next = new HashSet<int>();
            currentStrength += nextMatch;
            
            next.UnionWith(Enumerable.Range(0, one.Count).Where(i => one[i] == nextMatch).ToArray());
            next.UnionWith(Enumerable.Range(0, two.Count).Where(i => two[i] == nextMatch).ToArray());

            if (next.Count == 0)
            {
                strengths.Add(currentStrength);
                lengths.Add(count);
                return;
            }

            currentStrength += nextMatch;

            foreach (var n in next)
            {
                BuildChain( count,n, one[n] == nextMatch ? two[n] : one[n], currentStrength, strengths, one, two, lengths);
            }

        }

    }
}