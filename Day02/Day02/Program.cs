namespace Day02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sol = new Day02(@"/home/logan/projects/adventofcode2017/Day02/inputs/input.txt");

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), sol.PartTwo());
        }
    }
}