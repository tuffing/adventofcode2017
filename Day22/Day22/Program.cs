namespace Day22
{
    internal class Program
    {
        public static void Main(string[] args)
        {            
            var sol = new Day22(@"inputs.input.txt");

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(10000), sol.PartTwo(10000000));
        }
    }
}