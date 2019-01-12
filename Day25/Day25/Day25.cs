using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day25
{
    public class Day25
    {
        private Dictionary<string, State> _states;
        private string _state1;
        private int _diag;
        
        public Day25(string fileName)
        {
            var input = new Queue<string>(GetFromResources("Day25." + fileName).Split('\n').ToList());
            _states = new Dictionary<string, State>();

            var line = input.Dequeue().Split();
            _state1 = line[line.Length - 2] + " " + line[line.Length - 1].Remove(line[line.Length - 1].Length -1);

            line = input.Dequeue().Split();
            _diag = int.Parse(line[line.Length-2]);

            input.Dequeue();

            
            /***In state A:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state B.
  If the current value is 1:
    - Write the value 0.
    - Move one slot to the left.
    - Continue with state B.*/
            while (input.Count > 0)
            {
                line = input.Dequeue().Split();
                var name = line[line.Length - 2] + " " + line[line.Length - 1].Remove(line[line.Length - 1].Length -1);
                input.Dequeue();
                //0
                line = input.Dequeue().Split();
                var value0 = int.Parse(line[line.Length-1].Remove(line[line.Length - 1].Length -1));
                
                line = input.Dequeue().Split();
                var dir0 = line[line.Length - 1].Remove(line[line.Length - 1].Length -1);
                
                line = input.Dequeue().Split();
                var next0 = line[line.Length - 2] + " " + line[line.Length - 1].Remove(line[line.Length - 1].Length -1);
                
                //1
                input.Dequeue();
                line = input.Dequeue().Split();
                var value1 = int.Parse(line[line.Length-1].Remove(line[line.Length - 1].Length -1));
                
                line = input.Dequeue().Split();
                var dir1 = line[line.Length - 1].Remove(line[line.Length - 1].Length -1);
                
                line = input.Dequeue().Split();
                var next1 = line[line.Length - 2] + " " + line[line.Length - 1].Remove(line[line.Length - 1].Length -1);

                input.Dequeue();
                var s = new State(name, value0, dir0, next0, value1, dir1, next1);
                
                _states.Add(name, s);
            }

            foreach (var s in _states)
            {
                s.Value.IniNextStates(_states);
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

        public int PartOne()
        {
            var tape = new LinkedList<int>();
            tape.AddFirst(0);

            var next = (tape.First, _states[_state1]);

            for (int i =0; i < _diag; i++)
            {
                next = next.Item2.RunMachine(next.Item1, tape);                
            }

            return tape.Sum();

        }
    }
}