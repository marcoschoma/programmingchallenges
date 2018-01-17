using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round2_A
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
                        //var line = reader.ReadLine().Split(' ');
                        var line = reader.ReadLine();
                        var N = long.Parse(line);

                        var result = Solve(N);
                        stream.WriteLine("Case #" + (i + 1) + ": " + result);
                    }
                }
            }
        }

        private static long Solve(long n)
        {
            return n;
        }
    }
}
