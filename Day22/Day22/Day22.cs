using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day22
{
    public class Day22
    {
        //private >> _input;
        private Dictionary<string, int> _input;
        private int _startX;
        private int _startY;

        public Day22(string fileName)
        {
            _input = new Dictionary<string, int>();
            var lines = GetFromResources("Day22." + fileName).Split('\n').ToList();

            for (var y = 0; y < lines.Count; y++)
            {
                var points = lines[y].ToCharArray();
                for (var x = 0; x < points.Length; x++)
                {
                    _input.Add(CoordHash(x,y), points[x] == '#' ? 1:0);
                }
            }

            _startX = lines[0].Length / 2;
            _startY = lines.Count / 2;

            //_input = lines.Select(x => x.ToCharArray().Select(y => y.ToString()).ToList()).ToList();
        }

        private string CoordHash(int x, int y)
        {
            return x + "," + y;
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

        private string ChangeDir(int status, string currentDir)
        {
            switch (currentDir)
            {
                case "up":
                    return status == 1 ? "right" : "left";
                case "left":
                    return status == 1 ? "up" : "down";
                case "down":
                    return status == 1 ? "left" : "right";
                case "right":
                    return status == 1 ? "down" : "up";
            }

            return "";
        }

        public int PartOne(int bursts)
        {
            /**
             * 
            If the current node is infected, it turns to its right. Otherwise, it turns to its left. (Turning is done in-place; the current node does not change.)
            If the current node is clean, it becomes infected. Otherwise, it becomes cleaned. (This is done after the node is considered for the purposes of changing direction.)
            The virus carrier moves forward one node in the direction it is facing.

             */
            int infected = 0;
            int x = _startX;
            int y = _startY;
            
            var input = new Dictionary<string, int>(_input);
            
            string dir = "up";
            
            for (int i = 0; i < bursts; i++)
            {
                var coords = CoordHash(x, y);
                if (!input.ContainsKey(coords))
                {
                    input.Add(coords, 0);
                }

                var status = input[coords];
                dir = ChangeDir(status, dir);

                if (status == 0)
                {
                    input[coords] = 1;
                    infected++;
                }
                else
                {
                    input[coords] = 0;
                }

                switch (dir)
                {
                    case "up":
                        y--;
                        break;
                    case "left":
                        x--;
                        break;
                    case "down":
                        y++;
                        break;
                    case "right":
                        x++;
                        break;
                }

            }

            return infected;
        }
        
        private string ChangeDirAdvanced(int status, string currentDir)
        {
            /**
             * Decide which way to turn based on the current node:
                If it is clean (0), it turns left.
                If it is weakened (2), it does not turn, and will continue moving in the same direction.
                If it is infected (1), it turns right.
                If it is flagged (3), it reverses direction, and will go back the way it came.
            Modify the state of the current node, as described above.**/
           
            //weakened
            if (status == 2) 
                return currentDir;
            
            //flagged
            if (status == 3)
            {
                switch (currentDir)
                {
                    case "up":
                        return "down";
                    case "left":
                        return "right";
                    case "down":
                        return "up";
                    case "right":
                        return "left";
                }   
            }
            
            //clean and infected
            switch (currentDir)
            {
                case "up":
                    return status == 1 ? "right" : "left";
                case "left":
                    return status == 1 ? "up" : "down";
                case "down":
                    return status == 1 ? "left" : "right";
                case "right":
                    return status == 1 ? "down" : "up";
            }

            return "";
        }
        
        public int PartTwo(int bursts)
        {
            /**
             * 
            If the current node is infected, it turns to its right. Otherwise, it turns to its left. (Turning is done in-place; the current node does not change.)
            If the current node is clean, it becomes infected. Otherwise, it becomes cleaned. (This is done after the node is considered for the purposes of changing direction.)
            The virus carrier moves forward one node in the direction it is facing.


            Decide which way to turn based on the current node:
                If it is clean, it turns left.
                If it is weakened, it does not turn, and will continue moving in the same direction.
                If it is infected, it turns right.
                If it is flagged, it reverses direction, and will go back the way it came.
            Modify the state of the current node, as described above.
            The virus carrier moves forward one node in the direction it is facing.


            Clean nodes become weakened.
            Weakened nodes become infected.
            Infected nodes become flagged.
            Flagged nodes become clean.

             */
            int infected = 0;
            int x = _startX;
            int y = _startY;
            
            var input = new Dictionary<string, int>(_input);
            
            string dir = "up";
            
            for (int i = 0; i < bursts; i++)
            {
                var coords = CoordHash(x, y);
                if (!input.ContainsKey(coords))
                {
                    input.Add(coords, 0);
                }

                var status = input[coords];
                dir = ChangeDirAdvanced(status, dir);


                switch (status)
                {
                    case 0: //clean
                        input[coords] = 2;
                        break;
                    case 2: //weakend
                        input[coords] = 1;
                        infected++;
                        break;
                    case 1: //infected
                        input[coords] = 3;
                        break;
                    case 3: //flagged
                        input[coords] = 0;
                        break;
                }

                switch (dir)
                {
                    case "up":
                        y--;
                        break;
                    case "left":
                        x--;
                        break;
                    case "down":
                        y++;
                        break;
                    case "right":
                        x++;
                        break;
                }

            }

            return infected;
        }
    }
}