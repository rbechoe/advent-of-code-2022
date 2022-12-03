namespace AdventOfCode
{
    public class Day2
    {
        string[] lines;
        int pointSum; 
        public Day2()
        {
            lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 2\\Day2.txt");

            foreach (string line in lines)
            {
                string[] moves = ReMapMoves(line.Split(' '));
                // 1 is elf, 2 is player
                pointSum += MatchPoints(moves);
            }
        }

        ~Day2()
        {

        }

        private string[] ReMapMoves(string[] moves)
        {
            switch(moves[1])
            {
                case "X":
                    // X = lose
                    switch(moves[0])
                    {
                        case "A":
                            moves[1] = "Z";
                            break;
                        case "B":
                            moves[1] = "X";
                            break;
                        case "C":
                            moves[1] = "Y";
                            break;
                    }
                    break;
                case "Y":
                    // Y = draw
                    switch (moves[0])
                    {
                        case "A":
                            moves[1] = "X";
                            break;
                        case "B":
                            moves[1] = "Y";
                            break;
                        case "C":
                            moves[1] = "Z";
                            break;
                    }
                    break;
                case "Z":
                    // Z = win
                    switch (moves[0])
                    {
                        case "A":
                            moves[1] = "Y";
                            break;
                        case "B":
                            moves[1] = "Z";
                            break;
                        case "C":
                            moves[1] = "X";
                            break;
                    }
                    break;
            }

            return moves;
        }

        private int MatchPoints(string[] moves)
        {
            // A - X = Rock
            // B - Y = Paper
            // C - Z = Sciccors

            int points = 0;
            string elfMove = moves[0];
            string playerMove = moves[1];

            //The score for a single round is the score for the shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors)
            switch (playerMove)
            {
                case "X":
                    points += 1;
                    break;
                case "Y":
                    points += 2;
                    break;
                case "Z":
                    points += 3;
                    break;
            }

            //plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won).
            switch (elfMove)
            {
                case "A":
                    switch (playerMove)
                    {
                        case "X":
                            points += 3;
                            break;
                        case "Y":
                            points += 6;
                            break;
                        case "Z":
                            points += 0;
                            break;
                    }
                    break;
                case "B":
                    switch (playerMove)
                    {
                        case "X":
                            points += 0;
                            break;
                        case "Y":
                            points += 3;
                            break;
                        case "Z":
                            points += 6;
                            break;
                    }
                    break;
                case "C":
                    switch (playerMove)
                    {
                        case "X":
                            points += 6;
                            break;
                        case "Y":
                            points += 0;
                            break;
                        case "Z":
                            points += 3;
                            break;
                    }
                    break;
            }

            return points;
        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + pointSum);
        }

    }
}
