using System.Linq;

namespace Day16
{
    internal class Program
    {
        public static void Main(string[] args)
        {           
            var sol = new Day16(@"inputs.input.txt", "abcdefghijklmnop".ToCharArray().ToList());

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), sol.PartTwo());

            sol.PartTwo();
        }
    }
}