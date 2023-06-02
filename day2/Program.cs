using System;
using Utils;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = 
            Utils.Input.getInput();
            

            using (StreamReader sr = new StreamReader(input))
            {
                String? line;
                int score = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    score += RockPaperScissors.playGame(line);
                }

                Console.WriteLine("Final Score: " + score);
            }
        }

        class RockPaperScissors
        {
            enum SYMBOL
            {
                ROCK = 1,
                PAPER = 2,
                SCISSORS = 3,
                X = 4,
                Y = 5,
                Z = 6
            }

            enum OUTCOME
            {
                WIN = 6,
                DRAW = 3,
                LOSS = 0
            }

            static Dictionary<string, int> lookup_part1 =
                new Dictionary<string, int>() {
                    {"A X", 4 }, // rock v rock (draw - 3) 4
                    {"A Y", 8 }, // rock v paper (win - 6) 8
                    {"A Z", 3 }, // rock v scissors (loss - 0) 3
                    {"B X", 1 }, // paper v rock (loss - 0) 1
                    {"B Y", 5 }, // paper v paper (draw - 3) 5
                    {"B Z", 9 }, // paper v scissors (win - 6) 9
                    {"C X", 7 }, // scissors v rock (win - 6) 7
                    {"C Y", 2 }, // scissors v paper (loss - 0) 2
                    {"C Z", 6 }, // scissors v scissors (draw - 3) 6
                };

            static Dictionary<string, int> lookup_part2 =
                new Dictionary<string, int>() {
                    {"A X", 3 }, // rock v rock (draw) 4 (lose - scissors - 3)
                    {"A Y", 4 }, // rock v paper (win) 8 (draw - rock - 4)
                    {"A Z", 8 }, // rock v scissors (loss) 3 (win - paper - 8)
                    {"B X", 1 }, // paper v rock (loss) 1
                    {"B Y", 5 }, // paper v paper (draw) 5
                    {"B Z", 9 }, // paper v scissors (win) 9
                    {"C X", 2 }, // scissors v rock (win) 7 (loss - paper - 2)
                    {"C Y", 6 }, // scissors v paper (loss) 2 (draw - scissors - 6)
                    {"C Z", 7 }, // scissors v scissors (draw) 6 (win - rock - 7)
                };

            public static int playGame(string key)
            {
                return lookup_part2[key];
            }

        }
    }
}