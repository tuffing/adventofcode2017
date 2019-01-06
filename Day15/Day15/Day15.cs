using System;
using System.Collections.Generic;

namespace Day15
{
    public class Day15
    {
        private long _valueA;
        private long _valueB;
        
        public Day15(int startA, int startB)
        {
            _valueA = startA;
            _valueB = startB;
        }


        public int PartOne()
        {
            /*The generators both work on the same principle.
             To create its next value, a generator will take the previous value it produced, multiply it by a factor
              (generator A uses 16807; generator B uses 48271), 
              and then keep the remainder of dividing that resulting product by 2147483647.
               That final remainder is the value it produces next.*/
            var total = 0;
            const int cap = 40000000;
            const int divideBy = 2147483647;
            for (var i = 0; i < cap; i++)
            {
                _valueA = _valueA * 16807 % divideBy;
                _valueB = _valueB * 48271 % divideBy;

                var b1 = Convert.ToString(_valueA, 2).PadLeft(16, '0');
                var b2 = Convert.ToString(_valueB, 2).PadLeft(16,'0');

                if (b1.Substring(b1.Length - 16) != b2.Substring(b2.Length - 16)) continue;
                
                total++;
            }

            return total++;
        }
        
        public int PartTwo()
        {
            /*The generators both work on the same principle.
             To create its next value, a generator will take the previous value it produced, multiply it by a factor
              (generator A uses 16807; generator B uses 48271), 
              and then keep the remainder of dividing that resulting product by 2147483647.
               That final remainder is the value it produces next.*/
            var total = 0;
            const int cap = 5000000;
            const int divideBy = 2147483647;
            var valA = new List<long>();
            var valB = new List<long>();
            
            while(true)
            {
                _valueA = _valueA * 16807 % divideBy;
                _valueB = _valueB * 48271 % divideBy;

                if (_valueA % 4 == 0)
                {
                    valA.Add(_valueA);
                    total += CompareVals(valA, valB);
                }
                
                if (_valueB % 8 == 0)
                {
                    valB.Add(_valueB);
                    total += CompareVals(valB, valA);
                }

                if (valA.Count >= cap && valB.Count >= cap)
                    break;
            }

            return total++;
        }

        private static int CompareVals(IList<long> changed, IList<long> other)
        {
            if (changed.Count > other.Count)
                return 0;
            
            var b1 = Convert.ToString(changed[changed.Count -1], 2).PadLeft(16, '0');
            var b2 = Convert.ToString(other[changed.Count -1], 2).PadLeft(16,'0');

            if (b1.Substring(b1.Length - 16) != b2.Substring(b2.Length - 16)) return 0;
            
            
            System.Console.Write("C: {0} \n", changed.Count);

            
            return 1;
        }
    }
}