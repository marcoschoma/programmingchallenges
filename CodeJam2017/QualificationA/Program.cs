using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationA
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "A-large";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var param = reader.ReadLine().Split(' ');
                        var result = Solve(int.Parse(param[1]), param[0].ToCharArray());
                        if (result == -1)
                        {
                            stream.WriteLine("Case #{0}: IMPOSSIBLE", i+1);
                        }
                        else
                        {
                            stream.WriteLine("Case #{0}: {1}", i+1, result);
                        }
                    }
                }
            }
            //Console.ReadKey();
        }

        public static int Solve(int k, char[] S)
        {
            if (S.Length < k)
            {
                return -1;
            }
            var flips = 0;

            if (CheckFinish(S))
            {
                return 0;
            }

            for (int i = 0; i < S.Length && !CheckFinish(S); i++)
            {
                if (S[i] == '-')
                {
                    for (int j = i; (i + k) <= S.Length && j < i + k; j++)
                    {
                        S[j] = S[j] == '+' ? '-' : '+';
                    }
                    flips++;
                }
            }
            if (!CheckFinish(S))
            {
                return -1;
            }
            return flips;
        }

        private static bool CheckFinish(char[] s)
        {
            return !s.Contains('-');
        }
    }
}
