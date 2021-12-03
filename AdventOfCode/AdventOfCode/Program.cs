using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true){
                int years = 1;
                int selectedYear = 0;
                while (true)
                {
                    Console.WriteLine("Type in a number corrosponding to a year:");
                    Console.WriteLine("[1]: 2018");
                    var val = Console.ReadLine();

                    try
                    {
                        selectedYear = Convert.ToInt32(val);
                    }
                    catch (Exception){}
                    if (selectedYear < 1 || selectedYear > years)
                    {
                        Console.WriteLine("No valid number entered, try again");
                        Console.ReadKey();
                    } else break;
                    Console.Clear();
                }
                int days = 5;
                int selectedDay = 0;
                while (true)
                {
                    Console.WriteLine("Type in a number corrosponding to a day:");
                    Console.WriteLine($"[1-{days}]");

                    var val = Console.ReadLine();
                    try
                    {
                        selectedDay = Convert.ToInt32(val);
                    }
                    catch (Exception) { }
                    if (selectedDay < 1 || selectedDay > days)
                        Console.WriteLine("No valid number entered, try again");
                    else
                        break;
                }
                switch (selectedYear)
                {
                    case 1:
                        Y2018(selectedDay);
                        break;
                }
                Console.WriteLine("Press any key to restart");
                Console.ReadKey();
                Console.Clear();
            }

            void Y2018(int day)
            {
                DateTime start = DateTime.Now;
                switch (day)
                {
                    case 1:
                        AOC2018D1.Solve2();
                        break;
                    case 2:
                        AOC2018D2.Solve2();
                        break;
                    case 3:
                        AOC2018D3.Solve2();
                        break;
                    case 4:
                        AOC2018D4.Solve();
                        break;
                    case 5:
                        AOC2018D5.Solve2();
                        break;
                }
                TimeSpan total = DateTime.Now - start;
                Console.WriteLine($"Solution took: {total.TotalMilliseconds} ms");
            }
        }


    }
}
