using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
{
    public class Day08
    {
        private List<string> _input;
        private int _max = int.MinValue;
        
        public Day08(string fileName)
        {
            _input = GetFromResources("Day08." + fileName).Split('\n').ToList();
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
            // > < != >= == <=
            //b inc 5 if a > 1
            var dico = new Dictionary<string, Delegate>();
            dico.Add(">", new Func<int, int, int, int, int>(GreaterThan));
            dico.Add(">=", new Func<int, int, int, int, int>(GreaterThanOrEquals));
            dico.Add("<", new Func<int, int, int, int, int>(LessThan));
            dico.Add("<=", new Func<int, int, int, int, int>(LessThanOrEquals));
            dico.Add("==", new Func<int, int, int, int, int>(Equals));
            dico.Add("!=", new Func<int, int, int, int, int>(NotEquals));
            
            var regs = new Dictionary<string, int>();

            foreach (var i in _input)
            {
                var q = i.Split(' ');
                var regA = q[0];
                var change = q[1] == "inc" ? int.Parse(q[2]) : -int.Parse(q[2]);
                var regB = q[4];
                var op = q[5];
                var comp = int.Parse(q[6]);
                
                if (!regs.ContainsKey(regA))
                    regs.Add(regA, 0);
                
                if (!regs.ContainsKey(regB))
                    regs.Add(regB, 0);
                
                //regs[regA] = dico[op].DynamicInvoke(regs[regA], regs[regB], change, comp);
                var val = dico[op].DynamicInvoke(regs[regA], regs[regB], change, comp);
                regs[regA] = (int)val;

                if ((int) val > _max)
                {
                    _max = (int) val;
                }
            }
            
            return regs.Values.Max();
        }

        public int PartTwo()
        {
            return _max;
        }

        private int GreaterThan(int regA, int regB, int change, int comparison)
        {
            if (regB > comparison)
            {
                return regA + change;
            }

            return regA;
        }
        
        private int GreaterThanOrEquals(int regA, int regB, int change, int comparison)
        {
            if (regB >= comparison)
            {
                return regA + change;
            }

            return regA;
        }
        
        private int LessThan(int regA, int regB, int change, int comparison)
        {
            if (regB < comparison)
            {
                return regA + change;
            }

            return regA;
        }
        
        private int LessThanOrEquals(int regA, int regB, int change, int comparison)
        {
            if (regB <= comparison)
            {
                return regA + change;
            }

            return regA;
        }
        
        private int Equals(int regA, int regB, int change, int comparison)
        {
            if (regB == comparison)
            {
                return regA + change;
            }

            return regA;
        }
        
        private int NotEquals(int regA, int regB, int change, int comparison)
        {
            if (regB != comparison)
            {
                return regA + change;
            }

            return regA;
        }
    }
}