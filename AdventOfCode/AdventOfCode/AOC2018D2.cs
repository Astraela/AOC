using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class AOC2018D2
    {

        static string[] LoadInputs(string path)
        {
            return File.ReadAllText(path).Split("\n");
        }

        public static void Solve()
        {
            string[] ids = LoadInputs(input1);
            int twice = 0;
            int thrice = 0;
            for (int i = 0; i < ids.Length-1; i++)
            {
                HashSet<char> readLetters = new HashSet<char>();
                string id = ids[i];
                int hasTwice = 0;
                int hasThrice = 0;
                for (int nr = 0; nr < id.Length;nr++)
                {
                    char letter = id[nr];
                    if (readLetters.Contains(letter)) continue;
                    int dupes = GetDuplicates(id, letter, nr + 1);
                    if (dupes == 2) hasTwice = 1;
                    if (dupes == 3) hasThrice = 1;
                    readLetters.Add(letter);
                }
                twice += hasTwice;
                thrice += hasThrice;
            }
            Console.WriteLine($"Result: {twice*thrice}");
        }

        public static void Solve2()
        {
            string[] ids = LoadInputs(input1);
            bool found = false;
            for (int i = 0; i < ids.Length - 1; i++)
            {
                for (int y = i+1; y < ids.Length - 1; y++)
                {
                    (string result, bool correct) = Compare(ids[i], ids[y]);
                    if (correct)
                    {
                        found = true;
                        Console.WriteLine($"Result: {result}");
                        break;
                    }
                }
                if (found) break;
            }
        }

        static (string corrects, bool fits) Compare(string s1, string s2)
        {
            int wrongs = 0;
            string full = "";
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    wrongs++;
                    if (wrongs > 1) break;
                }
                else
                {
                    full += s1[i];
                }
            }
            return (full, wrongs == 1);
        }

        static int GetDuplicates(string s, char c, int start)
        {
            int duplicates = 1;

            for (int i = start; i < s.Length; i++)
            {
                if (s[i] == c) duplicates++;
            }

            return duplicates;
        }

        public static string input1 = @"C:\Users\creat\source\repos\AdventOfCode\AdventOfCode\Inputs\aoc2018d2i1.txt";


    }
}
