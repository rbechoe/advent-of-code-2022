
namespace AdventOfCode
{
    public class Day4
    {
        string[] lines;
        int containCount = 0;

        public Day4()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 4\\day4.txt");

            //Part1();
            Part2();
        }

        ~Day4()
        {

        }

        private void Part1()
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] tasks = lines[i].Split(',');
                int elfAmin = int.Parse(tasks[0].Split('-')[0]);
                int elfAmax = int.Parse(tasks[0].Split('-')[1]);
                int elfBmin = int.Parse(tasks[1].Split('-')[0]);
                int elfBmax = int.Parse(tasks[1].Split('-')[1]);

                // A contains B
                if (elfBmin >= elfAmin && elfBmax <= elfAmax)
                {
                    containCount++;
                }
                else if (elfAmin >= elfBmin && elfAmax <= elfBmax)
                {
                    containCount++;
                }

                //Console.WriteLine("Pair: " + elfAmin + " . " + elfAmax + " -- " + elfBmin + " . " + elfBmax);
            }
        }

        private void Part2()
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] tasks = lines[i].Split(',');
                int elfAmin = int.Parse(tasks[0].Split('-')[0]);
                int elfAmax = int.Parse(tasks[0].Split('-')[1]);
                int elfBmin = int.Parse(tasks[1].Split('-')[0]);
                int elfBmax = int.Parse(tasks[1].Split('-')[1]);

                if (elfBmin >= elfAmin && elfBmin <= elfAmax)
                {
                    containCount++;
                }
                else if (elfAmin >= elfBmin && elfAmin <= elfBmax)
                {
                    containCount++;
                }
                else if (elfAmax >= elfBmin && elfAmax <= elfBmax)
                {
                    containCount++;
                }
                else if (elfBmax >= elfAmin && elfBmax <= elfAmax)
                {
                    containCount++;
                }
            }
        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + containCount);
        }

    }
}
