using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Day21
{
    public class Day21
    {
        
        private Dictionary<string, HashSet<string>> _input;

        public Day21(string fileName)
        {
            var lines = GetFromResources("Day21." + fileName).Split('\n').ToList();
            _input = new Dictionary<string, HashSet<string>>();
            
            foreach (var l in lines)
            {
                var set = new HashSet<string>();
                var parts = l.Split(new string[] {"=>"}, StringSplitOptions.None);
                
                var inputA = parts[0].Trim().Split('/').Select(x => x.ToCharArray().Select(y => y.ToString()).ToList()).ToList();
                //first set of rotations
                Rotate(inputA, set);

                _input.Add(parts[1].Trim(), set);
                
                if (inputA.Count <= 2)
                    continue;
                
                var newBlock = new List<List<string>>();
                
                //flip it
                for (int i = inputA.Count - 1; i >= 0; i--)
                {
                   newBlock.Add(inputA[i]);
                }
                
                //rotate that a bunch of times too
                Rotate(newBlock, set);
            } 
        }

        private void Rotate(List<List<string>> block, ISet<string> set)
        {
            for (int c = 0; c < 4; c++)
            {
                var newBlock = new List<List<string>>();

                for (int i = 0; i < block.Count; i++)
                {
                    var row = new List<string>();
                    for (int j = 0; j < block.Count; j++)
                    {
                        row.Add(block[j][block.Count -1 - i]);
                    }
                    newBlock.Add(row);
                }

                var blockString = new List<string>();
                foreach (var row in newBlock)
                {
                    blockString.Add(string.Join("", row));
                }

                set.Add(string.Join("/n", blockString));

                block = newBlock;
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

        public int PartOne(int steps)
        {
            //.#.
            //..#
            //###
            //set up initial
            var square = new List<List<string>>();
            square.Add(new List<string>(new [] {".","#","."}));
            square.Add(new List<string>(new [] {".",".","#"}));
            square.Add(new List<string>(new [] {"#","#","#"}));
            var totalPixels = 0;

            for (int i = 0; i < steps; i++)
            {
                totalPixels = 0;
                var breaks = square.Count % 2 == 0 ? 2 : 3;
                var newSquare = new List<List<string>>();
                var newSquareSize = (breaks + 1) * (square.Count / breaks);
                
                for (int j = 0; j < newSquareSize; j++)
                    newSquare.Add(new List<string>());

                for (int y = 0; y < square.Count; y += breaks)
                {
                    for (int x = 0; x < square.Count; x += breaks)
                    {
                        //find the block
                        var check = new List<string>();
                        for (int yblock = y; yblock < y + breaks; yblock++)
                        {
                            check.Add(string.Join("", square[yblock].GetRange(x, breaks)));
                        }

                        var checkString = string.Join("/n", check);

                        //find the match
                        foreach (var rule in _input)
                        {
                            if (!rule.Value.Contains(checkString)) continue;
                            checkString = rule.Key;
                            totalPixels += checkString.Count(f => f == '#');
                            break;
                        }

                        //Add it to our new Square
                        var genned = checkString.Split('/');
                        var count = 0;
                        var start = y / breaks * (breaks + 1);
                        for (int row = start; row < start + genned.Length; row++)
                        {
                            newSquare[row].AddRange(genned[count].ToCharArray().Select(l => l.ToString()));
                            count++;
                        }

                    }
                }

                square = newSquare;
            }

            return totalPixels;
        }
    }
}