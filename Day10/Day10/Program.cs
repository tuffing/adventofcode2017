﻿namespace Day10
{
    internal class Program
    {
        public static void Main(string[] args)
        {            
            var sol = new Day10(@"Inputs.input.txt", 256);

            System.Console.Write("Part 1: {0}, Part 2: {1}", sol.PartOne(), sol.PartTwo());
        }
    }
}