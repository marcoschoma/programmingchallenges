using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationB
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "B-small-attempt1";
            using (var reader = new StreamReader(file + ".in"))
            {
                using (var stream = new StreamWriter(file + ".out", false))
                {
                    int T = int.Parse(reader.ReadLine());
                    for (int i = 0; i < T; i++)
                    {
                        var result = Solve(long.Parse(reader.ReadLine()));
                        stream.WriteLine("Case #{0}: {1}", i + 1, result);
                    }
                }
            }
        }

        public static long Solve(long N)
        {
            if (N < 10)
            {
                return N;
            }
            if (CheckFinish(N))
            {
                return N;
            }
            //brute force:
            for (long i = N - 1; i >= (N - N / 10); i--)
            {
                if (CheckFinish(i))
                {
                    return i;
                }
            }
            return N;
            /*long n = N;
            char[] digits = n.ToString().ToCharArray();
            for (int i = 0; i < digits.Length; i++)
            {
                int j = digits.Length-1;
                if (digits[i] > digits[j])
                {
                    digits[i] = (char)(digits[i] - '1');
                    if (digits[i] == '0')
                    {
                        digits[i + 1] = '9';
                    }
                    //digits[j] = '9';
                    //n = long.Parse(new string(digits));
                    //if (n > N)
                    //{
                        
                    //}
                }
            }*/
            /*n[j] = 9--5549
            if (n > N) --5549 > 5544
                n[i] = n[i] - 1--n: 5449
                if n[i] < 0
                    n[i - 1] = n[i - 1] - 1
                    */
            //for (long i = (N - N / 10); i < N; i++)
            //{
            //    if (!CheckFinish(i))
            //        return i-1;
            //}
            //return n;
        }

        private static bool CheckFinish(long N)
        {
            var digits = N.ToString().ToCharArray();
            return new String(digits.OrderBy(i => i).ToArray()) == N.ToString();
            /*for (int i = 0; i < digits.Length-1; i++)
            {
                if (digits[i] > digits[i+1])
                {
                    return false;
                }
            }*/
            //return true;
        }
    }
}
/*
1000
 999

5432 = 4999

5554 = 4999

5564 = 5559

5544 = 5499, i = 0, j = 3
n[i] = 5
n[j] = 4
if n[i] > n[j]
    n[j] = 9 --5549
    if(n > N) --5549 > 5544
        n[i] = n[i]-1  --n: 5449
        if n[i] < 0
            n[i-1] = n[i - 1]-1


5494 > 5544
blz, bora 5494, i = 0
5494
*/
/*
    5544
    5444 -> 
5 >= 5
55 >= 54
554 >= 544

132
1 > 3
13 > 32
132 > 132*/