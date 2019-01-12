namespace Day24
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sol = new Day24(@"inputs.input.txt");

            // System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), false);
            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(out var longest), longest);
        }
    }
}