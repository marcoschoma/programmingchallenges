using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromNight
{
    class PromNightProgram
    {
        static void Main(string[] args)
        {
            var line = System.Console.ReadLine().Trim();
            var T = Int32.Parse(line);
            for (var i = 0; i < T; i++)
            {
                line = System.Console.ReadLine().Trim();
                var data = line.Split(' ');
                var M = int.Parse(data[0]);
                var N = int.Parse(data[1]);

                line = System.Console.ReadLine().Trim();
                data = line.Split(' ');
                int[] boys = data.Select(s => int.Parse(s)).OrderBy(s => s).ToArray<int>();

                line = System.Console.ReadLine().Trim();
                data = line.Split(' ');
                int[] girls = data.Select(s => int.Parse(s)).OrderBy(s => s).ToArray<int>();

                if (Calcular(boys, girls, M, N))
                    YES();
                else
                    NO();
            }
        }

        private static bool Calcular(int[] boys, int[] girls, int M, int N)
        {
            if (M > N)
            {
                return false;
            }
            else
            {
                int j = 0;
                for (int i = 0; i < M; i++)
                {
                    if (j == N)
                        break;

                    if (girls[i] < boys[i])
                    {
                        j++;
                        continue;
                    }
                }
                return j == M;
            }
        }

        private static void NO()
        {
            Console.WriteLine("NO");
        }
        private static void YES()
        {
            Console.WriteLine("YES");
        }
    }
}
