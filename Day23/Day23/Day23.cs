using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day23
{
    public class Day23
    {
        private List<string> _input;
        private Dictionary<string, long> _regs;
        private int _pos = 0;
        private  Dictionary<string, Delegate> _coms;
        
        public Day23(string fileName)
        {
            _input = GetFromResources("Day23." + fileName).Split('\n').ToList();
            _regs = new Dictionary<string, long>();
            _coms = new Dictionary<string, Delegate>
            {
                {"sub", new Func<string, long, Dictionary<string, long>, long>(Sub)},
                {"set", new Func<string, long, Dictionary<string, long>, long>(Set)},
                {"mul", new Func<string, long, Dictionary<string, long>,  long>(Mul)},
                {"jnz", new Func<string, long, Dictionary<string, long>, long>(Jgz)}
            };

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
        
        private long GetValue(string val, IDictionary<string, long> regs)
        {
            long num;
            if (long.TryParse(val, out num)) return num;
            
            if (regs.ContainsKey(val))
                num = regs[val];
            else
            {
                num = 0;
                regs.Add(val, 0);
            }

            return num;
        }
        
        private long Set(string x, long y, Dictionary<string, long> regs)
        {
            //set X Y sets register X to the value of Y.
            regs[x] = y;
            return 0;
        }
        
        private long Sub(string x, long y, Dictionary<string, long> regs)
        {
            // decreases register X by the value of Y.
            regs[x] -= y;
            return regs[x];
        }
        
        private long Mul(string x, long y, Dictionary<string, long> regs)
        {
            //  sets register X to the result of multiplying the value contained in register X by the value of Y.
            regs[x] *= y;
            return regs[x];

        }
        
        private long Jgz(string x, long y, Dictionary<string, long> regs)
        {
            /**
             * jumps with an offset of the value of Y, but only if the value of X is not zero.
             * (An offset of 2 skips the next instruction, an offset of -1 jumps to the previous instruction, and so on.)
             */
            
            var valX = GetValue(x, regs);
            
            if (valX != 0)
            {
                _pos += (int)y;
            }

            return _pos;
        }
        
        public long PartOne()
        {
            var count = 0;
            
            while (true)
            {
                var prev = _pos;

                var command = _input[_pos].Split(' ');
                var x = command[1];
                var xVal = 0;
                
                if (!int.TryParse(x, out xVal) && !_regs.ContainsKey(x))
                {
                    _regs.Add(x, 0);
                }

                if (command[0] == "mul")
                    count++;
                
                var y = command.Length == 3 ? GetValue(command[2], _regs) : 0;

                _coms[command[0]].DynamicInvoke(x, y, _regs);

                if (prev == _pos)
                    _pos++;

                if (_pos >= _input.Count || _pos < 0)
                    break;
            }

            return count;
        }


        public long partTwo()
        {
            _regs = new Dictionary<string, long> {{"a", 1}, {"b", 0}, {"c", 0}, {"d", 0}, {"e", 0}, {"f", 0}, {"g", 0}, {"h", 0}};

            int nonPrime = 0;
            var starting = (57 * 100 + 100000);
            for (int i = starting; i <= starting + 17000; i += 17)
            {
                bool prime = !(i == 1);
 
                var limit = Math.Ceiling(Math.Sqrt(i));

                for (int j = 2; j <= limit; ++j)  {
                    if (i % j != 0) continue;
                    
                    prime = false;
                    break;
                }
                
                if (i == 2)
                    prime = true;
                
                if (!prime)
                {
                    nonPrime++;
                }
            }

            return nonPrime++;
        }
    }
}