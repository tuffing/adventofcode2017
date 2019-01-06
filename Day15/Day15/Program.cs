namespace Day15
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*Generator A starts with 516
            Generator B starts with 190
            */
            var sol = new Day15( 516, 190);

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), sol.PartTwo());
        }
    }
}