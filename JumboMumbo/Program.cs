using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumboMumbo
{
    class Program
    {
        const decimal startRate = 2;

        static void Main(string[] args)
        {
            var line = System.Console.ReadLine().Trim();
            var N = Int32.Parse(line);
            for (var i = 0; i < N; i++)
            {
                line = System.Console.ReadLine().Trim();
                var data = line.Split(' ');
                var C = decimal.Parse(data[0]);
                var F = decimal.Parse(data[1]);
                var X = decimal.Parse(data[2]);
                Console.WriteLine(String.Format("Case #{0}: {1:0.0000000}", i+1, Calcular(C, F, X)));
            }
        }

        static decimal Calcular(decimal costFarm, decimal farmRate, decimal target)
        {
            var currentTime = target / startRate;
            
            decimal nextStepTime, previousTime = 0, currentRate = startRate;

            while (true)
            {
                nextStepTime = previousTime + GetNextStep(costFarm, currentRate);
                previousTime = nextStepTime;
                currentRate += farmRate;
                if ((nextStepTime + target / currentRate) > currentTime)
                    return currentTime;
                else
                    currentTime = (nextStepTime + target / currentRate);
            }
        }

        static decimal GetNextStep(decimal costFarm, decimal currentRate)
        {
            return costFarm / currentRate;
        }
    }
}
