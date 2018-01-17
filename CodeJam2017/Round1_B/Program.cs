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
            string file = "sample";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var line = reader.ReadLine().Split(' ');
                        stream.WriteLine(Solve(long.Parse(line[0])));
                    }
                }
            }
        }

        public static string Solve(long N)
        {
            return "ok " + N;
        }
    }
}
