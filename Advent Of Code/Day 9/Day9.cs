namespace AdventOfCode
{
    public class Day9
    {
        string[] lines;

        static int length = 10;
        public bool[,] visitedPositions = new bool[length, length];
        int headPosX = 0;
        int headPosY = 0;
        int tailPosX = 0;
        int tailPosY = 0;

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
            // head follows instructions
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                string[] instruction = line.Split(' ');
                for (int i = 0; i < int.Parse(instruction[1]); i++)
                {
                    switch (instruction[0])
                    {
                        case "U":
                            headPosY += 1;
                            break;
                        case "D":
                            headPosY -= 1;
                            break;
                        case "L":
                            headPosX -= 1;
                            break;
                        case "R":
                            headPosX += 1;
                            break;
                    }

                    // tail follows head
                    UpdateTail();
                }
            }
        }

        private void UpdateTail()
        {
            int valY = headPosY - tailPosY;
            int valX = headPosX - tailPosX;
            // if value is 2 distance is too big
            // if value is 1 they are touching
            // move +1 into direction of the +2 or -2

            if (Math.Abs(valY) > 0 && Math.Abs(valX) > 0)
            {
                // move diagonally
                if (valY > 0)
                {
                    tailPosY += 1;
                }
                if (valY < 0)
                {
                    tailPosY -= 1;
                }
                if (valX > 0)
                {
                    tailPosX += 1;
                }
                if (valX < 0)
                {
                    tailPosX -= 1;
                }
            }
            else
            {
                // move vertically
                if (valY > 1)
                {
                    tailPosY += 1;
                }
                if (valY < -1)
                {
                    tailPosY -= 1;
                }
                // move horizontally
                if (valX > 1)
                {
                    tailPosX += 1;
                }
                if (valX < -1)
                {
                    tailPosX -= 1;
                }
            }

            // update visited position
            visitedPositions[tailPosX, tailPosY] = true;
        }

        public void PrintResult()
        {
            Console.WriteLine("Head: " + headPosX + " " + headPosY);
            Console.WriteLine("Tail: " + tailPosX + " " + tailPosY);

            int count = 0;
            for(int x = 0; x < length; x++)
            {
                Console.WriteLine("");
                for (int y = 0; y < length; y++)
                {
                    if (visitedPositions[x, y])
                    {
                        count++;
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
            }
            // rotate 90 degrees CW from console
            Console.WriteLine("Count: " + count);
        }
    }
}
