namespace AdventOfCode
{
    public class Day5
    {
        string[] lines;
        int containCount = 0;

        public List<Stack<string>> stackCollection = new List<Stack<string>>();

        public Day5()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 5\\day5.txt");
            PopulateStacks();

            //Part1();
            Part2();
        }

        ~Day5()
        {

        }

        private void PopulateStacks()
        {
            stackCollection.Add(new Stack<string>());
            stackCollection[0].Push("B");
            stackCollection[0].Push("S");
            stackCollection[0].Push("V");
            stackCollection[0].Push("Z");
            stackCollection[0].Push("G");
            stackCollection[0].Push("P");
            stackCollection[0].Push("W");

            stackCollection.Add(new Stack<string>());
            stackCollection[1].Push("J");
            stackCollection[1].Push("V");
            stackCollection[1].Push("B");
            stackCollection[1].Push("C");
            stackCollection[1].Push("Z");
            stackCollection[1].Push("F");

            stackCollection.Add(new Stack<string>());
            stackCollection[2].Push("V");
            stackCollection[2].Push("L");
            stackCollection[2].Push("M");
            stackCollection[2].Push("H");
            stackCollection[2].Push("N");
            stackCollection[2].Push("Z");
            stackCollection[2].Push("D");
            stackCollection[2].Push("C");

            stackCollection.Add(new Stack<string>());
            stackCollection[3].Push("L");
            stackCollection[3].Push("D");
            stackCollection[3].Push("M");
            stackCollection[3].Push("Z");
            stackCollection[3].Push("P");
            stackCollection[3].Push("F");
            stackCollection[3].Push("J");
            stackCollection[3].Push("B");

            stackCollection.Add(new Stack<string>());
            stackCollection[4].Push("V");
            stackCollection[4].Push("F");
            stackCollection[4].Push("C");
            stackCollection[4].Push("G");
            stackCollection[4].Push("J");
            stackCollection[4].Push("B");
            stackCollection[4].Push("Q");
            stackCollection[4].Push("H");

            stackCollection.Add(new Stack<string>());
            stackCollection[5].Push("G");
            stackCollection[5].Push("F");
            stackCollection[5].Push("Q");
            stackCollection[5].Push("T");
            stackCollection[5].Push("S");
            stackCollection[5].Push("L");
            stackCollection[5].Push("B");

            stackCollection.Add(new Stack<string>());
            stackCollection[6].Push("L");
            stackCollection[6].Push("G");
            stackCollection[6].Push("C");
            stackCollection[6].Push("Z");
            stackCollection[6].Push("V");

            stackCollection.Add(new Stack<string>());
            stackCollection[7].Push("N");
            stackCollection[7].Push("L");
            stackCollection[7].Push("G");

            stackCollection.Add(new Stack<string>());
            stackCollection[8].Push("J");
            stackCollection[8].Push("F");
            stackCollection[8].Push("H");
            stackCollection[8].Push("C");
        }

        private void PrintContent()
        {
            foreach (var item in stackCollection[0])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[1])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[2])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[3])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[4])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[5])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[6])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[7])
                Console.Write(item + ",");
            Console.WriteLine("");
            foreach (var item in stackCollection[8])
                Console.Write(item + ",");
            Console.WriteLine("");
        }

        private void Part1()
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] instruction = lines[i].Split(' ');
                // 1 select quantity
                // 3 select row
                // 5 drop items
                for (int j = 0; j < int.Parse(instruction[1]); j++)
                {
                    string block = stackCollection[int.Parse(instruction[3])-1].Pop();
                    stackCollection[int.Parse(instruction[5])-1].Push(block);
                }
            }
        }

        private void Part2()
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] instruction = lines[i].Split(' ');
                // 1 select quantity
                // 3 select row
                // 5 drop items
                Stack<string> blockStack = new Stack<string>();
                for (int j = 0; j < int.Parse(instruction[1]); j++)
                {
                    string block = stackCollection[int.Parse(instruction[3]) - 1].Pop();
                    blockStack.Push(block);
                }
                for (int j = 0; j < int.Parse(instruction[1]); j++)
                {
                    stackCollection[int.Parse(instruction[5]) - 1].Push(blockStack.Pop());
                }
            }
        }

        public void PrintResult()
        {
            PrintContent();
            Console.WriteLine("Done: " + containCount);
        }

    }
}
