using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Day14
{
    public class Day14
    {
        private readonly string _input;
        private List<int> _hash;
        
        private int _pos = 0;
        private int _skip = 0;

        private List<List<int>> _grid;

        public Day14(string input)
        {
            _input = input;
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
        
        public string GenerateKnotHash(string input)
        {
            _hash = Enumerable.Range(0, 256).ToList();

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

        public int PartOne()
        {
            _grid = new List<List<int>>();
            var total = 0;
            for (int i = 0; i < 128; i++)
            {
                var result = GenerateKnotHash(_input + "-" + i);
                var binary = result.ToCharArray().Aggregate(String.Empty, (current, s) => current + Convert.ToString(Convert.ToInt32(s.ToString(), 16), 2).PadLeft(4, '0'));
                total += Regex.Matches(binary, "1").Count;

                //var b = new List<string>();
                var b = binary.ToCharArray().Select(x=> int.Parse(x.ToString())).ToList();
                _grid.Add(b);
            }

            return total;
        }

        public int PartTwo()
        {
            var count = 1;

            for (int y = 0; y < _grid.Count; y++)
            {
                for (int x = 0; x < _grid[0].Count; x++)
                {
                    if (_grid[y][x] != 1)
                        continue;

                    BuildGroup(x, y, -count);
                    count++;
                }
            }

            return count -1;
        }

        private void BuildGroup(int x, int y, int count)
        {
            _grid[y][x] = count;
            if (y != 0 && _grid[y - 1][x] == 1)
                BuildGroup(x, y-1, count);
            if (y + 1 < _grid.Count && _grid[y + 1][x] == 1)
                BuildGroup(x, y+1, count);
            if (x != 0 && _grid[y][x-1] == 1)
                BuildGroup(x-1, y, count);
            if (x + 1 != _grid[0].Count && _grid[y][x+1] == 1)
                BuildGroup(x+1, y, count);
        }
    }
}