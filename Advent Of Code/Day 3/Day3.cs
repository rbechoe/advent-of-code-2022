using System;
using System.Linq;

namespace AdventOfCode
{
    public class Day3
    {
        string[] lines;
        int prioritySum = 0;

        List<string> alphabet = new List<string>()
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z",
        };

        public Day3()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 3\\Day3.txt");

            // part 1
            /*foreach (string line in lines)
            {
                string left = line.Substring(0, line.Length / 2);
                string right = line.Substring(line.Length / 2, line.Length / 2);

                string letter = GetMatch(left, right);
                prioritySum += GetPoints(letter);
            }*/

            // part 2
            for(int group = 0; group < (lines.Count() + 1) / 3; group++)
            {
                int val = group * 3;
                string letter = GetTrippleMatch(lines[val], lines[val + 1], lines[val + 2]);
                prioritySum += GetPoints(letter);
            }
        }

        ~Day3()
        {

        }

        public string GetMatch(string left, string right)
        {
            string letter = "";

            for (int i = 0; i < left.Length; i++)
            {
                for (int j = 0; j < right.Length; j++)
                {
                    if (left[i] == right[j])
                    {
                        letter = left.Substring(i, 1);
                        return letter;
                    }
                }
            }

            return letter;
        }

        public string GetTrippleMatch(string a, string b, string c)
        {
            string letter = "";

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    for (int k = 0; k < c.Length; k++)
                    {
                        if (a[i] == b[j] && a[i] == c[k])
                        {
                            letter = a.Substring(i, 1);
                            return letter;
                        }
                    }
                }
            }

            Console.WriteLine("no match?\n" + a + "\n" + b + "\n" + c);
            return letter;
        }

        public int GetPoints(string letter)
        {
            int points = alphabet.FindIndex(str => str.Contains(letter.ToLower())) + 1;
            int increment = Char.IsUpper(letter.ToCharArray()[0]) ? 26 : 0;
            return points + increment;
        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + prioritySum);
        }
    }
}
