using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16
{
    public class Day16
    {
        private List<string> _input;
        private List<char> _letters;
        
        public Day16(string fileName, List<char> letters)
        {
            _letters = letters;
            _input = GetFromResources("Day16." + fileName).Split(',').ToList();
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

        public string PartOne()
        {
            /*
                Spin, written sX, makes X programs move from the end to the front, but maintain their order otherwise. (For example, s3 on abcde produces cdeab).
                Exchange, written xA/B, makes the programs at positions A and B swap places.
                Partner, written pA/B, makes the programs named A and B swap places.
            */
            var commands = new Queue<string>(_input);
            //var progs = new Queue<char>(_letters);
            var progs = _letters;


            while (commands.Count > 0)
            {
                var com = commands.Dequeue();
                char temp;
                switch (com[0])
                {
                    case 's':
                        var test = int.Parse(com.Substring(1));
                        for (int i = 0; i < int.Parse(com.Substring(1)); i++)
                        {    
                            progs.Insert(0, progs.Last());
                            progs.RemoveAt(progs.Count - 1);
                        }

                        break;
                    case 'x':
                        var inds = com.Substring(1).Split('/').Select(int.Parse).ToList();
                        temp = progs[inds[0]];
                        progs[inds[0]] = progs[inds[1]];
                        progs[inds[1]] = temp;
                    
                        break;
                    
                    case 'p':
                        var chars = com.Substring(1).Split('/').ToList();
                        var indA = progs.IndexOf(chars[0][0]);
                        var indB = progs.IndexOf(chars[1][0]);
                        
                        temp = progs[indA];
                        progs[indA] = progs[indB];
                        progs[indB] = temp;
                        break;
                    
                }
            }


            return new string(progs.ToArray());

        }

        /// <summary>
        /// Finds the 1 billionth result of the dance.
        /// The dance produces a pattern that repeats every 60.
        /// So solution just generates the first 60 and selects what the billionth would be
        /// </summary>
        /// <returns></returns>
        public string PartTwo()
        {
            var items = new List<string>();
            items.Add(new string(_letters.ToArray()));
            for (int i = 0; i < 60; i++)
            {
                var v = PartOne();
                items.Add(v);
            }

            return items[1000000000 % 60 - 1];
        }
    }
}