using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day10
{
    public class Day10
    {
        private List<int> _input;
        private List<int> _hash;
        
        private int _pos = 0;
        private int _skip = 0;

        private string _filename;
        private int _length;
        
        public Day10(string fileName, int length)
        {
            _filename = fileName;
            _length = length;
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

        private void Hash(IEnumerable<int> input)
        {
            /*
                Reverse the order of that length of elements in the list, starting with the element at the current position.
                Move the current position forward by that length plus the skip size.
                Increase the skip size by one.
            */
            
            var q = new Queue<int>(input);

            while (q.Count > 0)
            {
                var val = q.Dequeue();
                if (_pos + val < _hash.Count)
                    _hash.Reverse(_pos, val);
                else
                {
                    var toReverse = new List<int>();

                    toReverse.AddRange(_hash.GetRange(_pos, _hash.Count - _pos));
                    toReverse.AddRange(_hash.GetRange(0, _pos + val - _hash.Count));
                    toReverse.Reverse();

                    var i = _pos;
                    foreach (var n in toReverse)
                    {
                        _hash[i % _hash.Count] = n;
                        i++;
                    }
                }

                _pos = (_pos + val + _skip) % _hash.Count;
                _skip++;
            }
        }

        public int PartOne()
        {
            _hash = Enumerable.Range(0, _length).ToList();

            Hash(GetFromResources("Day10." + _filename).Split(',').Select(int.Parse).ToList());

            return _hash[0] * _hash[1];
        }

        public string PartTwo()
        {
            _hash = Enumerable.Range(0, _length).ToList();

            var input = GetFromResources("Day10." + _filename);
            var chars = Encoding.ASCII.GetBytes(input).Select(x => (int) x).ToList();
            chars.AddRange(new []{17, 31, 73, 47, 23});
            
            _pos = 0;
            _skip = 0;

            for (var i = 0; i < 64; i++)
            {
                Hash(new List<int>(chars));
            }

            var result = "";
            for (var i = 0; i < 256; i = i + 16)
            {
                var total = _hash[i];
                foreach (var h in _hash.GetRange(i+1, 15))
                {
                    total ^= h;
                }

                result += total.ToString("X").PadLeft(2, '0');
            }

            return result.ToLower();
        }
    }
}