using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class AOC2018D5
    {

        static string LoadInputs(string path)
        {
            return File.ReadAllText(path);
        }

        public static void Solve()
        {
            string key = LoadInputs(input1);
            List<char> chars = key.ToList();

            int letter = 0;
            while(letter < chars.Count - 1)
            {
                int ascii = Convert.ToInt32(chars[letter]);
                bool explosion = false;
                if (ascii > 90)
                {
                    explosion = Convert.ToInt32(chars[letter + 1]) == ascii - 32;
                }
                else
                {
                    explosion = Convert.ToInt32(chars[letter + 1]) == ascii + 32;
                }
                if (explosion)
                {
                    chars.RemoveAt(letter + 1);
                    chars.RemoveAt(letter);
                    if(letter > 0)
                    {
                        letter -= 1;
                    }
                }
                else
                    letter++;
            }

            Console.WriteLine($"Result: {string.Join("",chars.Count)}");
        }

        public static void Solve2()
        {
            string key = LoadInputs(input1);
            List<char> chars = key.ToList();

            int[] units = new int[26];
            for (int i = 97; i < 97+26; i++)
            {
                List<char> newChars = chars.ToList();
                newChars.RemoveAll(delegate (char a) { return a == (char)i; });
                newChars.RemoveAll(delegate (char a) { return a == (char)i-32; });
                int letter = 0;
                while (letter < newChars.Count - 1)
                {
                    int ascii = Convert.ToInt32(newChars[letter]);
                    bool explosion = false;
                    if (ascii > 90)
                    {
                        explosion = Convert.ToInt32(newChars[letter + 1]) == ascii - 32;
                    }
                    else
                    {
                        explosion = Convert.ToInt32(newChars[letter + 1]) == ascii + 32;
                    }
                    if (explosion)
                    {
                        newChars.RemoveAt(letter + 1);
                        newChars.RemoveAt(letter);
                        if (letter > 0)
                        {
                            letter -= 1;
                        }
                    }
                    else
                        letter++;
                }
                units[i - 97] = newChars.Count;
            }

            Console.WriteLine($"Result: {units.Min()}");
        }

        public static string input1 = @"C:\Users\creat\source\repos\AdventOfCode\AdventOfCode\Inputs\aoc2018d5i1.txt";


    }

}
