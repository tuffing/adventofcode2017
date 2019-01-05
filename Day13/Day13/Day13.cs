using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day13
{
    public class Day13
    {
        private List<List<int>> _input;

        public Day13(string fileName)
        {
            var lines = GetFromResources("Day13." + fileName).Split('\n').ToList();
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
            int total = 0;

            foreach (var i in _input)
            {
                if ((i[0] + 1) % (i[1] - 1) == 1)
                {
                    total += i[0] * i[1];
                }
            }
            
            
            return total;
        }
        
        
        public int PartTwo()
        {
            var count = 0;

            while (true)
            {
                int total = 0;

                foreach (var i in _input)
                {
                    var test = (i[0] + count) % ((i[1]-1) * 2);
                    if ((i[0] + count) % ((i[1]-1) * 2) == 0)
                    {
                        total ++;
                    }
                }

                if (total == 0)
                    break;
                
                count++;
            }


            return count;
        }
    }
}