using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day01
{
    public class Day01
    {
        private string _input;
        
        public Day01(string fileName)
        {
            _input = System.IO.File.ReadAllText(fileName);

        }

        public int PartOne()
        {
            var last = (int) char.GetNumericValue(_input[_input.Length-1]);
            var total = 0;
            foreach (char c in _input)
            {
                var current = (int) char.GetNumericValue(c);
                
                if (current == last)
                {
                    total += current;
                }

                last = current;
            }

            return total;
        }
        
        public int PartTwo()
        {
            var total = 0;
            var  nums = new List<int>();
            foreach (char c in _input)
            {
               nums.Add((int) char.GetNumericValue(c)); 
            }
            
            for (var i = 0; i < nums.Count; i++)
            {
                var current = nums[i];
                var midChar = nums[(i + nums.Count / 2) % nums.Count];
                
                if (current == midChar)
                {
                    total += current;
                }
            }

            return total;
        }
    }
}