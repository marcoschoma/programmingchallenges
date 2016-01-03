using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR1_A
{
    class QR1_A_Program
    {
        static void Main(string[] args)
        {
            var line = System.Console.ReadLine().Trim();
            var data = line.Split(' ');
            int initialValue = int.Parse(data[0]);
            int lockValue = int.Parse(data[1]);

            line = System.Console.ReadLine().Trim();

            Console.WriteLine(Calcular().ToString());
        }

        private static int Calcular()
        {
            return 0;
        }
    }
}
