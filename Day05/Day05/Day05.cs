using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day05
{
    public class Day05
    {
        private List<int> _input;

        public Day05(string fileName)
        {
             _input = GetFromResources("Day05." + fileName).Split('\n').Select(int.Parse).ToList();
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
            var pos = 0;
            var count = 0;
            List<int> working = new List<int>(_input);

            while (true)
            {
                var step = working[pos];
                working[pos]++;
                pos += step;

                count++;
                
                if (pos < 0 || pos >= working.Count)
                    break;
            }

            return count;
        }
        
        public int PartTwo()
        {
            var pos = 0;
            var count = 0;
            List<int> working = new List<int>(_input);

            while (true)
            {
                var step = working[pos];
                if (step < 3)
                    working[pos]++;
                else
                    working[pos]--;
                
                pos += step;

                count++;
                
                if (pos < 0 || pos >= working.Count)
                    break;
            }

            return count;
        }
    }
}