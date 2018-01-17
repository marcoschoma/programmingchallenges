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
            string file = "A-small-attempt0";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var line = reader.ReadLine().Split(' ');

                        var D = long.Parse(line[0]);
                        var N = long.Parse(line[1]);

                        List<Tuple<long, long>> horses = new List<Tuple<long, long>>();
                        for (int j = 0; j < N; j++)
                        {
                            var h_line = reader.ReadLine().Split(' ');
                            horses.Add(Tuple.Create(long.Parse(h_line[0]), long.Parse(h_line[1])));
                        }

                        var result = Solve(D, N, horses);
                        stream.WriteLine(String.Format("Case #{0}: {1}", (i + 1), result.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture)));
                    }
                }
            }
        }

        /*private static decimal Solve(long d, long n, List<Tuple<long, long>> horses)
        {
            horses = horses.OrderBy(x => x.Item1).ToList();
            //var minSpeed = horses.Min(x => x.Item2);

            return 0;
        }*/
        
        private static decimal Solve(long d, long n, List<Tuple<long, long>> horses)
        {
            var maxD = d;

            if (horses.Count == 1)
            {
                return d / ((decimal) (maxD - horses[0].Item1) / horses[0].Item2 );
            }
            decimal time = 0; // (maxD - horses[0].Item1) / horses[0].Item2;

            horses = horses.OrderBy(x => x.Item1).ToList();
            for (int i = 0; i < horses.Count - 1; i++)
            {
                var h = horses[i];
                maxD = d - horses[i].Item1;
                for (int j = i+1; j < horses.Count; j++)
                {
                    if (h.Item2 < horses[j].Item2)
                    {
                        horses.Remove(horses[j]);
                    }
                    else
                    {
                        maxD = d - horses[i].Item1;
                        break;
                    }
                }

                time += (decimal)maxD / h.Item2;
            }
            return d / Math.Ceiling(time);
        }
    }
}
