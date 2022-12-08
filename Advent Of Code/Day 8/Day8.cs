namespace AdventOfCode
{
    public class Day8
    {
        string[] lines;

        List<List<int>> forrest = new List<List<int>>();

        int visibleCount = 0;

        public Day8()
        {
            //lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 8\\day8.txt"); //pc
            lines = File.ReadAllLines("C:\\Users\\rbech\\HKU\\advent-of-code-2022\\Advent Of Code\\Day 8\\day8.txt"); //laptop

            foreach (string line in lines)
            {
                forrest.Add(new List<int>());
                for (int i = 0; i < line.Length; i++)
                {
                    forrest[forrest.Count - 1].Add(int.Parse(line[i].ToString()));
                }
            }

            //Part1();
            Part2();
        }

        ~Day8()
        {

        }

        private void Part1()
        {
            // all edge numbers are visible
            // start and end numbers per int list
            // tree can be visible per direction (top, bottom, right, left)
            // tree is invisible if same height is blocking
            for (int column = 0; column < forrest.Count; column++)
            {
                for (int row = 0; row < forrest[column].Count; row++)
                {
                    if (column == 0 || row == 0 || column == forrest.Count - 1 || row == forrest[column].Count - 1)
                    {
                        visibleCount++;
                    }
                    else
                    {
                        // if any side visible, continue to next tree
                        int count = 4;
                        // check left side
                        for (int i = 0; i < row; i++)
                        {
                            if (forrest[column][row] <= forrest[column][i])
                            {
                                count--;
                                break;
                            }
                        }
                        // check right side
                        for (int i = row + 1; i < forrest[column].Count; i++)
                        {
                            if (forrest[column][row] <= forrest[column][i])
                            {
                                count--;
                                break;
                            }
                        }
                        // check top side
                        for (int i = 0; i < column; i++)
                        {
                            if (forrest[column][row] <= forrest[i][row])
                            {
                                count--;
                                break;
                            }
                        }
                        // check bottom side
                        for (int i = column + 1; i < forrest.Count; i++)
                        {
                            if (forrest[column][row] <= forrest[i][row])
                            {
                                count--;
                                break;
                            }
                        }

                        if (count > 0)
                        {
                            visibleCount++;
                        }
                    }
                }
            }
        }

        void Part2()
        {
            for (int column = 0; column < forrest.Count; column++)
            {
                for (int row = 0; row < forrest[column].Count; row++)
                {
                    if (column == 0 || row == 0 || column == forrest.Count - 1 || row == forrest[column].Count - 1)
                    {
                        //visibleCount++;
                    }
                    else
                    {
                        // if any side visible, continue to next tree
                        int leftScore = 0, rightScore = 0, topScore = 0, bottomScore = 0;

                        // check left side
                        for (int i = row - 1; i > 0; i--)
                        {
                            leftScore++;
                            if (forrest[column][row] <= forrest[column][i])
                            {
                                break;
                            }
                        }
                        // check right side
                        for (int i = row + 1; i < forrest[column].Count; i++)
                        {
                            rightScore++;
                            if (forrest[column][row] <= forrest[column][i])
                            {
                                break;
                            }
                        }
                        // check top side
                        for (int i = column - 1; i > 0; i--)
                        {
                            topScore++;
                            if (forrest[column][row] <= forrest[i][row])
                            {
                                break;
                            }
                        }
                        // check bottom side
                        for (int i = column + 1; i < forrest.Count; i++)
                        {
                            bottomScore++;
                            if (forrest[column][row] <= forrest[i][row])
                            {
                                break;
                            }
                        }

                        int totalScore = leftScore * rightScore * topScore * bottomScore;
                        if (totalScore > visibleCount)
                        {
                            Console.WriteLine(leftScore + " - " + rightScore + " - " + topScore + " - " + bottomScore);
                            Console.WriteLine(column + " - " + row);
                            Console.WriteLine(forrest[column][row]);
                            visibleCount = totalScore;
                        }
                    }
                }
            }
        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + visibleCount);
        }
    }
}
