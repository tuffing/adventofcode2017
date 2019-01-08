using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day18
{
    public class Day18
    {
        private List<string> _input;
        private Dictionary<string, long> _regs;
        private int _pos = 0;
        private long _lastPlayed = 0;
        private long _partOneResult = 0;
        private  Dictionary<string, Delegate> _coms;
        
        private Dictionary<string, long> _regsA;
        private Dictionary<string, long> _regsB;
        private Queue<long> _regAQueue;
        private Queue<long> _regBQueue;
        private bool _aOnHold = false;
        private bool _bOnHold = false;
        private int _posA = 0;
        private int _posB = 0;
        private int count = 0;

        private int _sndATotal = 0;
        
        public Day18(string fileName)
        {
            _input = GetFromResources("Day18." + fileName).Split('\n').ToList();
            _regs = new Dictionary<string, long>();
            _coms = new Dictionary<string, Delegate>
            {
                {"snd", new Func<string, long, Dictionary<string, long>, long>(Snd)},
                {"set", new Func<string, long, Dictionary<string, long>, long>(Set)},
                {"add", new Func<string, long, Dictionary<string, long>, long>(Add)},
                {"mul", new Func<string, long, Dictionary<string, long>,  long>(Mul)},
                {"mod", new Func<string, long, Dictionary<string, long>,  long>(Mod)},
                {"rcv", new Func<string, long, Dictionary<string, long>,  long>(Rcv)},
                {"jgz", new Func<string, long, Dictionary<string, long>, long>(Jgz)}
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

        /// <summary>
        /// 
        ///     

        /// </summary>
        /// <returns></returns>

        private long Snd(string x, long y, Dictionary<string, long> regs)
        {
            //snd X plays a sound with a frequency equal to the value of X.
            _lastPlayed = _regs[x];
            return _lastPlayed;
        }
        
        private long Set(string x, long y, Dictionary<string, long> regs)
        {
            //set X Y sets register X to the value of Y.
            regs[x] = y;
            return 0;
        }
        
        private long Snd2(string x, long y, Dictionary<string, long> regs)
        {
            //snd X sends the value of X to the other program.
            //These values wait in a queue until that program is ready to receive them.
            //Each program has its own message queue, so a program can never receive a message it sent.
            var valX = GetValue(x, regs);

            if (regs == _regsA)
            {
                _regBQueue.Enqueue(valX);
                _bOnHold = false;
            }
            else
            {
                _aOnHold = false;
                _regAQueue.Enqueue(valX);
                _sndATotal++;

            }

            return 0;
        }
        
        private long Add(string x, long y, Dictionary<string, long> regs)
        {
            //add X Y increases register X by the value of Y.
            regs[x] += y;
            return regs[x];
        }
        
        private long Mul(string x, long y, Dictionary<string, long> regs)
        {
            //   mul X Y sets register X to the result of multiplying the value contained in register X by the value of Y.
            regs[x] *= y;
            return regs[x];

        }
        
        private long Mod(string x, long y, Dictionary<string, long> regs)
        {
            //   mod X Y sets register X to the remainder of dividing the value contained in register X by the value of Y (that is, it sets X to the result of X modulo Y).
            regs[x] = regs[x] % y;
            return regs[x];
        }

        private long Rcv(string x, long y, Dictionary<string, long> regs)
        {
            //rcv X recovers the frequency of the last sound played, but only when the value of X is not zero. (If it is zero, the command does nothing.)
            var valX = GetValue(x, regs);

            if (valX > 0)
            {
                _partOneResult = _lastPlayed;
            }

            return 0;
        }
        
        private long Rcv2(string x, long y, Dictionary<string, long> regs)
        {
            //if something is in the queue return it, else wait.
            if (regs == _regsA)
            {
                _aOnHold = true;
                if (_regAQueue.Count <= 0) return 0;

                _aOnHold = false;
                _regsA[x] = _regAQueue.Dequeue();
                
                return _regsA[x];
            }
            
            _bOnHold = true;
            if (_regBQueue.Count <= 0) return 0;

            _bOnHold = false;
            _regsB[x] = _regBQueue.Dequeue();
                
            return _regsB[x];
        }

        private long Jgz(string x, long y, Dictionary<string, long> regs)
        {
            //jgz X Y jumps with an offset of the value of Y, but only if the value of X is greater than zero. (An offset of 2 skips the next instruction, an offset of -1 jumps to the previous instruction, and so on.)
            var valX = GetValue(x, regs);
            
            if (valX > 0)
            {
                _pos += (int)y;
            }

            return _pos;
        }
        
        private long Jgz2(string x, long y, Dictionary<string, long> regs)
        {
            //jgz X Y jumps with an offset of the value of Y, but only if the value of X is greater than zero. (An offset of 2 skips the next instruction,
            //an offset of -1 jumps to the previous instruction, and so on.)
            var valX = GetValue(x, regs);

            if (valX <= 0)
                return 0;

            y--;
            
            if (regs == _regsA)
            {
                _posA += (int)y;
                return _posA;
            }
            
            _posB += (int)y;
            return _posB;
        }

        
        public long PartOne()
        {
            while (_partOneResult == 0)
            {
                count++;
                var prev = _pos;

                var command = _input[_pos].Split(' ');
                var x = command[1];
                var xVal = 0;
                
                if (!int.TryParse(x, out xVal) && !_regs.ContainsKey(x))
                {
                    _regs.Add(x, 0);
                }

                var y = command.Length == 3 ? GetValue(command[2], _regs) : 0;

                _coms[command[0]].DynamicInvoke(x, y, _regs);

                if (prev == _pos)
                    _pos++;

                if (_pos > _input.Count || _pos < 0)
                    break;
            }

            return _partOneResult;
        }

        public int PartTwo()
        {
            _regsA = new Dictionary<string, long>();
            _regsA.Add("p", 0);
            _regsB = new Dictionary<string, long>();
            _regsB.Add("p", 1);

            //_regAQueue = new Queue<long>(new [] {(long)0});
            _regAQueue = new Queue<long>();
            //_regBQueue = new Queue<long>(new [] {(long)1});
            _regBQueue = new Queue<long>();
            
            var coms = new Dictionary<string, Delegate>
            {
                {"snd", new Func<string, long, Dictionary<string, long>, long>(Snd2)},
                {"set", new Func<string, long, Dictionary<string, long>, long>(Set)},
                {"add", new Func<string, long, Dictionary<string, long>, long>(Add)},
                {"mul", new Func<string, long, Dictionary<string, long>,  long>(Mul)},
                {"mod", new Func<string, long, Dictionary<string, long>,  long>(Mod)},
                {"rcv", new Func<string, long, Dictionary<string, long>,  long>(Rcv2)},
                {"jgz", new Func<string, long, Dictionary<string, long>, long>(Jgz2)}
            };

            var terminatedA = false;
            var terminatedB = false;

            count = 0;
            while (!terminatedA && !_aOnHold || !terminatedB && !_bOnHold)
            {
                if (!_aOnHold && !terminatedA)
                {
                    count++;
                    Tick(_regsA, _posA, coms);
                    if (!_aOnHold)
                        _posA++;
                }

                if (!_bOnHold && !terminatedB)
                {
                    Tick(_regsB, _posB, coms);
                    if (!_bOnHold)
                        _posB++;
                   
                }

                if (_posA >= _input.Count || _posA < 0 || !_aOnHold && terminatedB)
                    terminatedA = true;
                
                if (_posB >= _input.Count || _posB < 0 || !_bOnHold && terminatedA)
                    terminatedB = true;

                if (_aOnHold && _bOnHold)
                    break;


            }

            return _sndATotal;
        }

        private void Tick(IDictionary<string, long> regs,  int pos, Dictionary<string, Delegate> coms)
        {
            var command = _input[pos].Split(' ');
            var x = command[1];
            var xVal = 0;
                
            if (!int.TryParse(x, out xVal) && !regs.ContainsKey(x))
            {
                regs.Add(x, 0);
            }

            var y = command.Length == 3 ? GetValue(command[2], regs) : 0;

            coms[command[0]].DynamicInvoke(x, y, regs);
        }
    }
}