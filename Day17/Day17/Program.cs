namespace Day17
{
    internal class Program
    {
        public static void Main(string[] args)
        {           
            var sol = new Day17();

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(337, 2018), sol.PartTwoOptimised(337, 50000000));
        }
    }
}