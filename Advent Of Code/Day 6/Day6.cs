namespace AdventOfCode
{
    public class Day6
    {
        string[] lines;
        int containCount = 0;
        int bufferSize = 14; // 4 = part 1, 14 = part 2

        public Day6()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 6\\day6.txt"); //pc
            //lines = File.ReadAllLines("C:\\Users\\rbech\\HKU\\advent-of-code-2022\\Advent Of Code\\Day 6\\day6.txt"); //laptop

            Part1();
        }

        ~Day6()
        {

        }

        private void Part1()
        {
            Queue<string> buffer = new Queue<string>();
            for (int i = 0; i < lines[0].Count(); i++)
            {
                containCount++;
                buffer.Enqueue(lines[0][i].ToString());
                if (buffer.Count > bufferSize) buffer.Dequeue();
                if (buffer.Count > bufferSize - 1 && LetterCheck(buffer))
                {
                    break;
                }
            }
        }

        private bool LetterCheck(Queue<string> buffer)
        {
            string[] bufferCol = buffer.ToArray();

            for (int i = 0; i < buffer.Count; i++)
            {
                if (i != buffer.Count - 1)
                {
                    for (int j = i + 1; j < buffer.Count; j++)
                    {
                        if (bufferCol[i] == bufferCol[j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + containCount);
        }
    }
}
