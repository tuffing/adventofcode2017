namespace Day19App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sol = new Day19(@"inputs.input.txt", 19, 0);

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(out var count), count);
        }
    }
}