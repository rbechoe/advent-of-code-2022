namespace AdventOfCode
{
    public class Day9
    {
        string[] lines;

        List<List<int>> forest = new List<List<int>>();

        int visibleCount = 0;

        public Day9()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 9\\day9.txt"); //pc
            //lines = File.ReadAllLines("C:\\Users\\rbech\\HKU\\advent-of-code-2022\\Advent Of Code\\Day 9\\day9.txt"); //laptop

            Part1();
        }

        ~Day9()
        {

        }

        private void Part1()
        {

        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + visibleCount);
        }
    }
}
