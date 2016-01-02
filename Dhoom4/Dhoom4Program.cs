﻿using System;
using System.Collections;
using System.Linq;

namespace Dhoom4
{
    class Dhoom4Program
    {
        static void Main(string[] args)
        {
            var line = System.Console.ReadLine().Trim();
            //var line = "18023 15115";
            //var line = "3 30";
            var data = line.Split(' ');
            int initialValue = int.Parse(data[0]);
            int lockValue = int.Parse(data[1]);

            line = System.Console.ReadLine().Trim();
            line = System.Console.ReadLine().Trim();
            //line = "18121 1326 22175 6108 24870 5429 25714 8945 22404 19339 21602 31878 10196 14252 7186 6020 15854 2140 6205 25226 32646 14294 6218 30002 21596 17190 18465 8855 32436 28884 27710 5396 22534 27330 9219 22350 17910 12119 9811 28276 31622 7645 11356 27077 23179 8744 32436 2899 2398 17273 22696 28167 4307 6818 5585 19686 5743 29546 24040 20370 1749 7474 17114 20 17538 11993 1311 19928 11962 16862 29256 16889 5314 26820 4568 18624 26960 25787 5205 13415 19008 24188 14495 23842 12424 9845 7040 608 23662 16422 9603 20813 20985 15563 2826 13468 31141 10555 4763 20869 14682 4880 5499 22025 6559 26888 28286 31869 19212 15019 19229 26694 8189 6958 4809 16354 20110 11160 22655 10280 3779 4131 2717 1232 26886 21733 21748 8757 18647 1455 26910 11354 10175 32054 8465 5931 25733 12144 12277 23558 6821 29505 21811 12410 3582 3927 17871 6735 32459 3667 16375 1222 31188 7721 31964 15137 30950 32457 29888 27750 26496 17407 10576 7265 24527 28311 27189 9704 13276 8390 18406 12899 5893 29125 10432 19083 31658 9407 13400 25713 31016 18157 2320 4802 19979 30976 28648 14666 21119 26559 663 27320 28424 14321 30683 21409 27507 27005 2573 22215 10765 30160 11256 16026 8978 11647 32747 10239 13416 6445 17677 2641 6541 25008 12017 165 8143 879 23402 14419 27323 20750 23201 10418 23767 2382 32100 30754 30868 1070 24001 12880 19838 15191 21972 13237 17846 12726 22749 28256 26530 32363 25237 27638 24547 32482 28867 12535 26503 29759 15114 25922 23168 4096 7429 26076 4693 13277 26262 9197 22808 26867 1658 29963 2200 21026 17185 14523 10711 7604 30141 30517 10431 14911 31642 23912 28688 21196 20909 14910 413 22072 3695 24865 24248 3547 11756 5566 21739 1896 25622 25865 745 22036 26976 3969 10691 28411 30088 26805 7775 9407 23732 20487 28455 1650 705 9904 4606 9654 6360 26372 11896 2082 22850 16631 22602 18408 13693 24545 19967 10165 10895 15742 4077 7641 12186 9785 25448 6824 29361 21162 5685 3616 22506 14941 5697 28876 28340 981 12691 21479 20843 13776 4736 15557 9002 3533 19486 20335 8161 8140 2811 3214 29351 9045";
            //line = "2 5 7";
            data = line.Split(' ');
            int[] keys = data.Select(s => int.Parse(s)).OrderBy(s => s).ToArray<int>();
            Console.WriteLine(String.Format("{0}", Calcular(initialValue, lockValue, keys)));
            //Console.ReadKey();
        }

        private static int Calcular(int currentKey, int lockValue, int[] keys)
        {
            int modulos = 100000;

            var queue = new Queue(keys.Length);
            queue.Enqueue(currentKey);

            int[] states = new int[modulos];
            for (int i = 0; i < states.Length; i++)
            {
                states[i] = -1;
            }
            states[currentKey] = 0;

            while (queue.Count > 0)
            {
                int popedKey = (int)queue.Dequeue();
                if (popedKey == lockValue)
                {
                    break;
                }
                for (int i = 0; i < keys.Length; i++)
                {
                    currentKey = (popedKey * keys[i]) % modulos;
                    if (currentKey < 0) continue;
                    if (currentKey == modulos)
                        currentKey = modulos;
                    else if (states[currentKey] == -1)
                    {
                        states[currentKey] = states[popedKey] + 1;
                        queue.Enqueue(currentKey);
                    }
                }
            }
            return states[lockValue];
        }
    }
}
