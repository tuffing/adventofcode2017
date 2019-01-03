using System.Collections.Generic;
using System.IO;

namespace Day09
{
    public class Day09
    {
        private string _input;
        private int _gCount = 0;
        
        public Day09(string fileName)
        {
            _input = GetFromResources("Day09." + fileName);
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
            var q = new Queue<char>(_input.ToCharArray());

            var total = 0;
            
            var open = 0;
            var garbage = false;
            var skip = false;

            while (q.Count > 0)
            {
                var val = q.Dequeue();

                if (skip)
                {
                    skip = false;
                    continue;
                }

                if (val == '!')
                {
                    skip = true;
                }
                else if (!garbage)
                {
                    switch (val)
                    {
                        case '{':
                            open++;
                            total += open;
                            break;
                        case '}':
                            open--;
                            break;
                        case '<':
                            garbage = true;
                            break;
                    }
                }
                else if (val == '>')
                {
                    garbage = false;
                }
                else
                {
                    _gCount++;
                }
            }

            return total;
        }

        public int PartTwo()
        {
            return _gCount;
        }
    }
}