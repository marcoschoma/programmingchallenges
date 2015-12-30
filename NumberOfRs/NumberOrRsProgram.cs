using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRs
{
    class NumberOrRsProgram
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Trim();
            var N = int.Parse(line);
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(MaxRs(Console.ReadLine().Trim()));
            }
            Console.ReadKey();
        }

        static int MaxRs(string input)
        {
            int[] a = new int[1000003];
            int[] dp = new int[1000003];

            int inputLength = input.Length;
            int countBeforeFlip = 0, maxCountOfRs;
            for (int i = 0; i < inputLength; i++)
            {
                if (input[i] == 'R')
                {
                    a[i] = -1;
                    countBeforeFlip++;
                }
                else a[i] = 1;
            }
            maxCountOfRs = dp[0] = a[0];
            for (int i = 1; i < inputLength; i++)
            {
                dp[i] = Math.Max(a[i], a[i] + dp[i - 1]);
                maxCountOfRs = Math.Max(dp[i], maxCountOfRs);
            }
            return maxCountOfRs + countBeforeFlip;
        }
    }
}
