using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class AOC2018D3
    {

        static Claim[] LoadInputs(string path)
        {
            string[] claims = File.ReadAllText(path).Split("\n");
            Claim[] claimList = new Claim[claims.Length-1];
            var reg = new Regex(@"(\d+)");
            for (int i = 0; i < claims.Length-1; i++)
            {
                var matches = reg.Matches(claims[i]);
                Claim newClaim = new Claim(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value), Convert.ToInt32(matches[3].Value), Convert.ToInt32(matches[4].Value));
                claimList[i] = newClaim;
            }
            return claimList;
        }

        public static void Solve()
        {
            Claim[] claims = LoadInputs(input1);

            int[,] overlapping = new int[1000,1000];
            for (int claimNr = 0; claimNr < claims.Length; claimNr++)
            {
                Claim claim = claims[claimNr];
                for (int x = claim.x; x < claim.x + claim.width; x++)
                {
                    for (int y = claim.y; y < claim.y + claim.height; y++)
                    {
                        overlapping[x, y] += 1;
                    }
                }
            }


            int overlaps = 0;
            for (int gridX = 0; gridX < 1000; gridX++)
                for (int gridY = 0; gridY < 1000; gridY++)
                    if (overlapping[gridX, gridY] > 1) overlaps++;

            Console.WriteLine($"Result: {overlaps}");
        }

        public static void Solve2()
        {
            Claim[] claims = LoadInputs(input1);

            Claim[,] grid = new Claim[1000, 1000];

            for (int claimNr = 0; claimNr < claims.Length; claimNr++)
            {
                Claim claim = claims[claimNr];
                for (int x = claim.x; x < claim.x + claim.width; x++)
                {
                    for (int y = claim.y; y < claim.y + claim.height; y++)
                    {
                        if (grid[x, y] == null)
                        {
                            grid[x, y] = claim;
                        }
                        else
                        {
                            claim.overlaps = true;
                            grid[x, y].overlaps = true;
                        }
                    }
                }
            }

            Console.WriteLine($"Result: {Array.Find<Claim>(claims,(x) => !x.overlaps).id}");
        }

        public static string input1 = @"C:\Users\creat\source\repos\AdventOfCode\AdventOfCode\Inputs\aoc2018d3i1.txt";


    }

    class Claim
    {
        public int id;
        public int x;
        public int y;
        public int width;
        public int height;
        public bool overlaps = false;
        public Claim(int id, int x, int y, int width, int height)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

}
