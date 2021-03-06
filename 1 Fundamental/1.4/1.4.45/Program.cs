﻿using System;

namespace _1._4._45
{
    class Program
    {
        // HN 指的是调和级数
        static void Main(string[] args)
        {
            var random = new Random();
            var N = 10000;
            var a = new bool[N];
            var randomSize = 0;
            var times = 0;
            for (times = 0; times < 20; times++)
            {
                for (var i = 0; i < N; i++)
                {
                    a[i] = false;
                }
                for (var i = 0; true; i++)
                {
                    var now = random.Next(N);
                    a[now] = true;
                    if (IsAllGenerated(a))
                    {
                        randomSize += i;
                        Console.WriteLine($"生成{i}次后所有可能均出现过了");
                        break;
                    }
                }
            }
            Console.WriteLine($"\nNHN={N * HarmonicSum(N)}，平均生成{randomSize / times}个数字后所有可能都出现");
        }

        /// <summary>
        /// 计算 N 阶调和级数的和。
        /// </summary>
        /// <param name="N">调和级数的 N 值</param>
        /// <returns>N 阶调和级数的和。</returns>
        static double HarmonicSum(int N)
        {
            double sum = 0;
            for (var i = 1; i <= N; i++)
            {
                sum += 1.0 / i;
            }
            return sum;
        }

        /// <summary>
        /// 检查所有数字是否都生成过了。
        /// </summary>
        /// <param name="a">布尔数组。</param>
        /// <returns>全都生成则返回 true，否则返回 false。</returns>
        static bool IsAllGenerated(bool[] a)
        {
            foreach (var i in a)
            {
                if (!i)
                    return false;
            }
            return true;
        }
    }
}
