using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationD
{
    class Program
    {
        private static int TestNumber;
        static void Main(string[] args)
        {
            string file = "sample";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    var T = int.Parse(reader.ReadLine());
                    for (TestNumber = 0; TestNumber < T; TestNumber++)
                    {
                        var line = reader.ReadLine().Split(' ');
                        var N = long.Parse(line[0]);
                        var M = long.Parse(line[1]);

                        var matrix = new char[N,N];

                        for (int j = 0; j < M; j++)
                        {
                            line = reader.ReadLine().Split(' ');
                            matrix[int.Parse(line[1])-1, int.Parse(line[2])-1] = line[0][0];
                        }


                        Solve(N, matrix);
                    }
                }
            }
            Console.ReadKey();
        }

        public static void Solve(long N, char[,] matrix)
        {
            int points = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    points += GetPoints(matrix[i, j]);
                }
            }
            Console.WriteLine("Case #" + TestNumber + ": " + points + " " + 0);
        }
        private static int GetPoints(char c)
        {
            return c == 0 ? 0 : c == 'x' || c == '+' ? 1 : 2;
        }
    }
}
