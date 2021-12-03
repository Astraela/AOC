using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    static class AOC2018D1
    {

        static int[] LoadInputs(string path)
        {
            int[] inputs;
             var result = File.ReadAllText(path).Split("\n");
            inputs = new int[result.Length-1];
            for (int i = 0; i < result.Length-1; i++)
            {
                inputs[i] = Convert.ToInt32(result[i]);
            }

            return inputs;
        }

        public static void Solve()
        {
            int[] frequencies = LoadInputs(input1);
            DateTime start = DateTime.Now;
            int nr = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                nr += frequencies[i];
            }
            Console.WriteLine($"Result: {nr}");
        }

        public static void Solve2()
        {
            int[] frequencies = LoadInputs(input1);
            int nr = 0;
            HashSet<int> reachedints = new HashSet<int>();

            int iteration = 0;

            while (true)
            {

                nr += frequencies[iteration];
                if (reachedints.Contains(nr))
                {
                    Console.WriteLine($"Result: {nr}");
                    break;
                }
                reachedints.Add(nr);
                if (iteration++ >= frequencies.Length - 1)
                    iteration = 0;
            }
        }

        public static string input1 = @"C:\Users\creat\source\repos\AdventOfCode\AdventOfCode\Inputs\aoc2018d1i1.txt";


    }
}
