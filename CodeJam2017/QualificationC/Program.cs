using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationC
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve(500000, 500000 / 2);

            string file = "C-large-practice";//606 578 = -1?
            //string file = "sample";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var line = reader.ReadLine().Split(' ');
                        var result = Solve(long.Parse(line[0]), long.Parse(line[1]));
                        stream.WriteLine("Case #{0}: {1} {2}", i + 1, result.Item1, result.Item2);
                    }
                }
            }
        }

        public static Tuple<long, long> Solve(long N, long K)
        {
            if (N == K)
            {
                return new Tuple<long, long>(0, 0);
            }
            var count = new Dictionary<long, long>();
            count[N] = 1;
            HashSet<long> seats = new HashSet<long>
            {
                N
            };
            long max = long.MaxValue, min = long.MaxValue;
            for (long i = 0; ;)
            {
                var newN = seats.Max();
                i += count[newN];

                max = (long)Math.Ceiling((decimal)(newN - 1) / 2);
                min = (long)Math.Floor((decimal)(newN - 1) / 2);
                if (i >= K)
                {
                    return new Tuple<long, long>(max, min);
                }
                else
                {
                    seats.Remove(newN);
                    seats.Add(max);
                    seats.Add(min);
                    if (!count.ContainsKey(max))
                        count.Add(max, count[newN]);
                    else
                        count[max] += count[newN];

                    if (!count.ContainsKey(min))
                        count.Add(min, count[newN]);
                    else
                        count[min] += count[newN];
                    //Console.WriteLine(max + " " + min);
                }
            }
        }
    }
}
