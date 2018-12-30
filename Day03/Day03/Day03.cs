using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public class Day03
    {
        private int _input;
        public Day03(int val)
        {
            _input = val;
        }

        public int PartOne()
        {
            int count = 1;
            int step = 8;
            int curr = 2;

            while (true)
            {
                if (curr + step > _input)
                {
                    break;
                }

                curr += step;
                step += 8;
                count++;
            }

                        
            //somewhere on our spiral is our input.
            if (_input == curr + step - 1)
            {
                return count + count;
            }
            
            //right column
            int topRight = curr + count * 2 - 1;
            if (_input < topRight)
            {
                return count + Math.Abs(-count + 1 + (_input - curr));
            }

            //the other three
            int topLeft = topRight + (count * 2);
            for (int i = topLeft; i <= curr + step; i += count * 2)
            {
                if (_input < i)
                {
                    return count + Math.Abs(-count + (i - _input));
                }                
            }

            return 0;
        }

        public int PartTwo()
        {    
            var grid = new Dictionary<Tuple<int,int>, int>();
            int count = 1;
            //int current = 1;
            grid[new Tuple<int, int>(0,0)] = 1;

            while (true)
            {    
                
                //right col
                var start = -count + 1;
                var end = count;
                var result = calculateRow(start, end, count,grid, false);
                if (result > -1)
                    return result;
                
                //top col
                start = count;
                end = -count;
                result = calculateRow(start, end, count,grid, true);
                if (result > -1)
                    return result;
                
                //right
                start--;
                result = calculateRow(start, end, -count,grid, false);
                if (result > -1)
                    return result;

                //bottom
                start = -count +1;
                end = count;
                result = calculateRow(start, end, -count,grid, true);
                if (result > -1)
                    return result;

                count++;
            }

        }

        private int calculateRow(int start, int end,int count, IDictionary<Tuple<int, int>, int> grid, bool countIsY)
        {
            var s = start;
            var e = end;

            if (start > end)
            {
                s = end;
                e = start;
            }

            for (var ind = s; ind <= e; ind++)
            {
                var i = (start > end) ? start - Math.Abs(end-ind) : ind;
                
                var x = count;
                var y = i;
                if (countIsY)
                {
                    x = i;
                    y = count;
                }

                var coords = new[]
                {
                    new Tuple<int, int>(x,y+1), //top
                    new Tuple<int, int>(x - 1,y+1), //top-left
                    new Tuple<int, int>(x-1,y), //left
                    new Tuple<int, int>(x-1,y-1), //bottom-left
                    new Tuple<int, int>(x,y-1), //bottom
                    new Tuple<int, int>(x+1,y-1), //bottom-right
                    new Tuple<int, int>(x+1,y), //right
                    new Tuple<int, int>(x+1,y+1) //top-right
                };

                int total = coords.Where(grid.ContainsKey).Sum(xy => grid[xy]);

                grid[new Tuple<int, int>(x,y)] = total;

                if (total >= _input)
                    return total;
            }  


            return -1;
        }
    }
}