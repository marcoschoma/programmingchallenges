using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace CodeJam2018
{
    public class Problem2_SenateEvacuation
    {
        static void Main2(string[] args)
        {
            var fileName = "sample";
            using (var reader = new StreamReader(fileName + ".in"))
            {
                using (var writer = new StreamWriter(fileName + ".out"))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var parties = reader.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        
                        var result = Solve(parties);
                        writer.WriteLine("Case #" + (i + 1) + ": " + result);
                        writer.Flush();
                    }
                }
            }
        }

        private static int Solve(int[] parties)
        {
            var l = new SortedList();
            //l.Add()

            var total = parties.Sum();
            return 0;
        }
    }
}
