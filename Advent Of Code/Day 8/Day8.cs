namespace AdventOfCode
{
    public class Day8
    {
        string[] lines;

        List<List<int>> forest = new List<List<int>>();

        int visibleCount = 0;

        public Day8()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 8\\day8.txt"); //pc
            //lines = File.ReadAllLines("C:\\Users\\rbech\\HKU\\advent-of-code-2022\\Advent Of Code\\Day 8\\day8.txt"); //laptop

            foreach (string line in lines)
            {
                forest.Add(new List<int>());
                for (int i = 0; i < line.Length; i++)
                {
                    forest[forest.Count - 1].Add(int.Parse(line[i].ToString()));
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
            for (int column = 0; column < forest.Count; column++)
            {
                for (int row = 0; row < forest[column].Count; row++)
                {
                    if (column == 0 || row == 0 || column == forest.Count - 1 || row == forest[column].Count - 1)
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
                            if (forest[column][row] <= forest[column][i])
                            {
                                count--;
                                break;
                            }
                        }
                        // check right side
                        for (int i = row + 1; i < forest[column].Count; i++)
                        {
                            if (forest[column][row] <= forest[column][i])
                            {
                                count--;
                                break;
                            }
                        }
                        // check top side
                        for (int i = 0; i < column; i++)
                        {
                            if (forest[column][row] <= forest[i][row])
                            {
                                count--;
                                break;
                            }
                        }
                        // check bottom side
                        for (int i = column + 1; i < forest.Count; i++)
                        {
                            if (forest[column][row] <= forest[i][row])
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
            for (int column = 0; column < forest.Count; column++)
            {
                for (int row = 0; row < forest[column].Count; row++)
                {
                    if (column == 0 || row == 0 || column == forest.Count - 1 || row == forest[column].Count - 1)
                    {
                        //visibleCount++;
                    }
                    else
                    {
                        // if any side visible, continue to next tree
                        int leftScore = 0, rightScore = 0, topScore = 0, bottomScore = 0;

                        // check left side
                        for (int i = row - 1; i >= 0; i--)
                        {
                            leftScore++;
                            if (forest[column][row] <= forest[column][i])
                            {
                                break;
                            }
                        }
                        // check right side
                        for (int i = row + 1; i < forest[column].Count; i++)
                        {
                            rightScore++;
                            if (forest[column][row] <= forest[column][i])
                            {
                                break;
                            }
                        }
                        // check top side
                        for (int i = column - 1; i >= 0; i--)
                        {
                            topScore++;
                            if (forest[column][row] <= forest[i][row])
                            {
                                break;
                            }
                        }
                        // check bottom side
                        for (int i = column + 1; i < forest.Count; i++)
                        {
                            bottomScore++;
                            if (forest[column][row] <= forest[i][row])
                            {
                                break;
                            }
                        }

                        int totalScore = leftScore * rightScore * topScore * bottomScore;
                        if (totalScore > visibleCount)
                        {
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
