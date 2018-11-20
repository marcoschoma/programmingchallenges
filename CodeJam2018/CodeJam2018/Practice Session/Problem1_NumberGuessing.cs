using System;
using System.IO;

namespace CodeJam2018
{
    public class Problem1_NumberGuessing
    {
        public static void Main(string[] args)
        {
            string file = "sample";
            using (var reader = Console.In)
            {
                using (var writer = Console.Out)
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var result = Solve(reader, writer);
                        writer.Flush();
                    }
                }
            }
        }

        private static int Solve(TextReader reader, TextWriter writer)
        {
            var bounds = reader.ReadLine().Split(' ');
            var lower = int.Parse(bounds[0]);
            var upper = int.Parse(bounds[1]);

            var line = reader.ReadLine();
            var guesses = int.Parse(line);

            var guess = (lower + upper) / 2;
            for (int i = 0; i < guesses; i++)
            {
                writer.WriteLine(guess);
                var judgeAnswer = reader.ReadLine();
                if (judgeAnswer == "TOO_BIG")
                {
                    upper = guess;
                } else if (judgeAnswer == "TOO_SMALL")
                {
                    lower = guess;
                }
                else if (judgeAnswer == "WRONG_ANSWER")
                {
                    return -1;
                }
                else if (judgeAnswer == "CORRECT")
                {
                    break;
                }
                guess = (lower + upper) / 2;
            }
            return guess;
        }
    }
}
