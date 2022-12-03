namespace AdventOfCode
{
    public class Day1
    {
        string[] lines;
        List<int> calories = new List<int>();

        public Day1()
        {
            // construct
            FindMostCalories();
        }

        ~Day1()
        {
            // destruct
        }

        public void FindMostCalories()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 1\\part1.txt");

            // add first value
            calories.Add(0);

            // convert strings to calory count
            foreach (string line in lines)
            {
                if (line != "")
                    calories[calories.Count - 1] += int.Parse(line);
                else
                    calories.Add(0);
            }
            calories.Sort();
        }

        public void PrintResult()
        {
            // first half answer
            //Console.WriteLine("Done: " + calories[calories.Count - 1]);

            // seocnd half answer
            int sum = calories[calories.Count - 1] + calories[calories.Count - 2] + calories[calories.Count - 3];
            Console.WriteLine("Done: " + sum);
        }
    }
}
