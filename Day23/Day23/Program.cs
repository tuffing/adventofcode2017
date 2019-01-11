namespace Day23
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sol = new Day23(@"inputs.input.txt");

           // System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), false);
            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), sol.partTwo());

        }
    }
}