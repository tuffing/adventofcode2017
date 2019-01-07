using System.Collections.Generic;

namespace Day17
{
    public class Day17
    {
        public int PartOne(int steps, int max)
        {
            var sol = new CIntLinkedList(0);
            
            for (var i = 1; i < max; i++)
            {
                sol.Rotate(steps);
                sol.InsertAfter(i);
            }
            
            sol.Rotate(1);
            return sol.CurrentVal();
        }

        public int PartTwo(int steps, int max)
        {
            var sol = new LinkedList<int>(new [] {0});
            var curr = sol.First;
            var ori = sol.First;
            
            for (var i = 1; i < max; i++)
            {

                for (var j = 0; j < steps; j++)
                {
                    curr = curr.Next ?? sol.First;
                }

                sol.AddAfter(curr, new LinkedListNode<int>(i));
                curr = curr.Next;
            }

            return ori.Next.Value;
        }

        public int PartTwoOptimised(int steps, int max)
        {
            int answer = 0;
            int pos = 0;

            for (var i = 1; i <= max; i++)
            {
                pos = (pos + steps) % i + 1;
                if (pos == 1)
                    answer = i;
            }

            return answer;
        }

    }
}