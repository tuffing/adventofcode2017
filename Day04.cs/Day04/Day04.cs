using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day04
{
    public class Day04
    {
        private List<string> _input;
        
        public Day04(string fileName)
        {
            _input = GetFromResources("Day04.cs." + fileName).Split('\n').ToList();
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
            int total = 0;

            foreach (var phrase in _input)
            {
                var words = phrase.Split(' ');
                if (words.Length == words.Distinct().Count())
                {
                    total++;
                }
            }
            
            
            return total;
        }

        public int PartTwo()
        {
            var total = 0;

            foreach (var phrase in _input)
            {
                var words = phrase.Split(' ').Select(w => string.Concat(w.OrderBy(c => c))).ToList();

                
                if (words.Count == words.Distinct().Count())
                {
                    total++;
                }
            }
            
            
            return total;
        }
    }
}