using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round1_A
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "A-large-practice";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var line = reader.ReadLine().Split(' ');
                        var R = int.Parse(line[0]);
                        var C = int.Parse(line[1]);

                        char[][] matrix = new char[R][];

                        for (int j = 0; j < R; j++)
                        {
                            matrix[j] = reader.ReadLine().ToCharArray();
                        }

                        matrix = Solve(R, C, matrix);
                        stream.WriteLine("Case #" + (i+1) + ":");
                        for (int x = 0; x < R; x++)
                        {
                            stream.Write(matrix[x]);
                            stream.Write(Environment.NewLine);
                        }
                    }
                }
            }
        }
        
        public static char[][] Solve(int R, int C, char[][] matrix)
        {
            for (int i = 0; i < R; i++)
            {
                char last = '?';
                for (int j = 0; j < C; j++)
                {
                    if (matrix[i][j] != '?') last = matrix[i][j];
                    matrix[i][j] = last;
                }
            }

            for (int i = 0; i < R; i++)
            {
                char last = '?';
                for (int j = C - 1; j >= 0; j--)
                {
                    if (matrix[i][j] != '?') last = matrix[i][j];
                    matrix[i][j] = last;
                }
            }

            for (int j = 0; j < C; j++)
            {
                char last = '?';
                for (int i = 0; i < R; i++)
                {
                    if (matrix[i][j] != '?') last = matrix[i][j];
                    matrix[i][j] = last;
                }
            }
            for (int j = 0; j < C; j++)
            {
                char last = '?';
                for (int i = R - 1; i >= 0; i--)
                {
                    if (matrix[i][j] != '?') last = matrix[i][j];
                    matrix[i][j] = last;
                }
            }
            return matrix;
        }
    }
}
