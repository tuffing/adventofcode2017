using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day19App
{
    public class Day19
    {
        private List<string> _input;
        private int _startX;
        private int _startY;

        public Day19(string fileName, int startX, int startY)
        {
            _input = GetFromResources("Day19App." + fileName).Split('\n').ToList();
            _startX = startX;
            _startY = startY;
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

        public string PartOne(out int count)
        {
            var dirs = new Dictionary<string, int[]>
            {
                {"up", new[] {-1, 0}},
                {"down", new[] {1, 0}},
                {"left", new[] {0, -1}},
                {"right", new[] {0, 1}}
            };

            var res = string.Empty;
            var y = _startY;
            var x = _startX;
            var dir = "down";

            count = 0;

            while (true)
            {
                count++;
                y += dirs[dir][0];
                x += dirs[dir][1];

                if (x < 0 || y < 0 || y > _input.Count || x > _input[y].Length)
                    break;
                
                var val = _input[y][x].ToString();

                if (val == "+")
                {
                    var oppo = dir;
                    switch (dir)
                    {
                        case "up":
                            oppo = "down";
                            break;
                        case "down":
                            oppo = "up";
                            break;
                        case "left":
                            oppo = "left";
                            break;
                        case "right":
                            oppo = "left";
                            break;
                    }

                    foreach (var k in dirs.Keys)
                    {
                        var tX = x + dirs[k][1];
                        var ty = y + dirs[k][0];
                        if (k == oppo || ty < 0 || tX < 0 || ty >= _input.Count || tX >= _input[ty].Length ||
                            _input[ty][tX] == ' ') continue;
                        dir = k;
                        break;
                    }
                }
                else if (val != "-" && val != "|" && val != " ")
                {
                    res += _input[y][x];
                }

                if (val == " ")
                {
                    break;
                }

            }

            return res;
        }
    }
}