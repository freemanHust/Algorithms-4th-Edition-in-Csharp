﻿using System;
using Quick;

namespace _2._3._27
{
    
    class Program
    {
        static void Main(string[] args)
        {
            QuickSortInsertion insertion = new QuickSortInsertion();
            QuickSortIgnore ignore = new QuickSortIgnore();
            int arraySize = 20000;                          // 初始数组大小。
            const int mSteps = 1;                           // M 值的递增次数。
            const int trialTimes = 4;                       // 每次实验的重复次数。
            const int trialLevel = 10;                      // 双倍递增的次数。

            Console.WriteLine("M\tn\t\tignore\tinsert\tratio");
            for (int i = 0; i < mSteps; i++)
            {
                int array = arraySize;
                for (int j = 0; j < trialLevel; j++)
                {
                    double timeIgnore = 0;
                    double timeInsertion = 0;
                    for (int k = 0; k < trialTimes; k++)
                    {
                        int[] a = SortCompare.GetRandomArrayInt(array);
                        int[] b = new int[a.Length];
                        a.CopyTo(b, 0);
                        timeInsertion += SortCompare.Time(insertion, b);
                        timeIgnore += SortCompare.Time(ignore, a);

                    }
                    timeIgnore /= trialTimes;
                    timeInsertion /= trialTimes;
                    if (arraySize < 10000000)
                        Console.WriteLine(ignore.M + "\t" + array + "\t\t" + timeIgnore + "\t" + timeInsertion + "\t" + timeIgnore / timeInsertion);
                    else
                        Console.WriteLine(ignore.M + "\t" + array + "\t" + timeIgnore + "\t" + timeInsertion + "\t" + timeIgnore / timeInsertion);
                    array *= 2;
                }
                ignore.M++;
            }
        }
    }
}
