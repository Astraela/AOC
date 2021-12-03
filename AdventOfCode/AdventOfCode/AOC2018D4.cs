using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class AOC2018D4
    {

        static Record[] LoadInputs(string path)
        {
            string[] records = File.ReadAllText(path).Split("\n");
            Record[] recordList = new Record[records.Length - 1];
            var reg = new Regex(@"(\d+)");
            for (int i = 0; i < records.Length - 1; i++)
            {
                var matches = reg.Matches(records[i]);
                DateTime time = new DateTime(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value), Convert.ToInt32(matches[3].Value), Convert.ToInt32(matches[4].Value),0);
                recordList[i] = new Record(time, records[i].Substring(19));
            }
            return recordList;
        }

        public static void Solve()
        {
            Record[] records = LoadInputs(input1);
            Array.Sort(records,delegate(Record a, Record b) { return a.time.CompareTo(b.time); });

            int[,] guardMinutes = new int[5000,60];
            int[] guardTotalMinutes = new int[5000];
            int currentGuard = 0;
            int sleeptime = 0;
            for (int i = 0; i < records.Length; i++)
            {
                if (records[i].action.Contains("Guard"))
                {
                    var reg = new Regex(@"(\d+)");
                    int id = Convert.ToInt32(reg.Match(records[i].action).Value);
                    currentGuard = id;
                }
                else if(records[i].action == "falls asleep")
                {
                    sleeptime = records[i].time.Minute;
                }else if(records[i].action == "wakes up")
                {
                    guardTotalMinutes[currentGuard] += records[i].time.Minute - sleeptime;
                    for (int minute = sleeptime; minute < records[i].time.Minute; minute++) {
                        guardMinutes[currentGuard,minute]++;
                    }
                }
            }
            int bestGuard = 0;
            for (int i = 0; i < 5000; i++)
            {
                if(guardTotalMinutes[i] != 0 && guardTotalMinutes[i] > guardTotalMinutes[bestGuard])
                {
                    bestGuard = i;
                }
            }

            int bestMinute = 0;
            for (int i = 0; i < 59; i++)
            {
                if (guardMinutes[bestGuard, i] > guardMinutes[bestGuard, bestMinute]) {
                    bestMinute = i;
                }
            }
            Console.WriteLine($"Result: {bestGuard * bestMinute}");
        }

        public static void Solve2()
        {
            Record[] records = LoadInputs(input1);
            Array.Sort(records, delegate (Record a, Record b) { return a.time.CompareTo(b.time); });

            int[,] guardMinutes = new int[5000, 60];
            int[] guardTotalMinutes = new int[5000];

            int currentGuard = 0;
            int sleeptime = 0;
            for (int i = 0; i < records.Length; i++)
            {
                if (records[i].action.Contains("Guard"))
                {
                    var reg = new Regex(@"(\d+)");
                    int id = Convert.ToInt32(reg.Match(records[i].action).Value);
                    currentGuard = id;
                }
                else if (records[i].action == "falls asleep")
                {
                    sleeptime = records[i].time.Minute;
                }
                else if (records[i].action == "wakes up")
                {
                    guardTotalMinutes[currentGuard] += records[i].time.Minute - sleeptime;
                    for (int minute = sleeptime; minute < records[i].time.Minute; minute++)
                    {
                        guardMinutes[currentGuard, minute]++;
                    }
                }
            }

            int bestGuard = 0;
            int bestMinute = 0;
            for (int i = 0; i < 59; i++)
            {
                for (int y = 0; y < 5000; y++)
                {
                    if (guardMinutes[y, i] > guardMinutes[bestGuard, bestMinute])
                    {
                        bestGuard = y;
                        bestMinute = i;
                    }
                }
            }
            Console.WriteLine($"Result: {bestGuard * bestMinute}");
        }

        public static string input1 = @"C:\Users\creat\source\repos\AdventOfCode\AdventOfCode\Inputs\aoc2018d4i1.txt";


    }



    class Record
    {
        public DateTime time;
        public string action;
        public Record(DateTime time, string action)
        {
            this.time = time;
            this.action = action;
        }
    }

}
