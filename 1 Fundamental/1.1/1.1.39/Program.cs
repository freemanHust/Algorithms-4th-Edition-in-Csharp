﻿using System;

namespace _1._1._39
{
    class Program
    {
        // 需要 6 秒左右的运算时间
        static void Main(string[] args)
        {
            var r = new Random();
            var baseNum = 10;
            var powNum = 3;
            var T = 10;
            var M = 4;

            var Matrix = new double[M, 2];

            for (var i = 0; i < M; i++)
            {
                var N = (int)Math.Pow(baseNum, powNum + i);
                double sum = 0;
                for (var j = 0; j < T; j++)
                {
                    sum += Test(N, r.Next());
                }
                Matrix[i, 0] = N;
                Matrix[i, 1] = sum / T;
            }

            PrintMatrix(Matrix);
        }

        /// <summary>
        /// 执行一次“实验”，返回相同数字的数目。
        /// </summary>
        /// <param name="N">数组的大小。</param>
        /// <param name="seed">随机种子。</param>
        /// <returns></returns>
        static int Test(int N, int seed)
        {
            var random = new Random(seed);
            var a = new int[N];
            var b = new int[N];
            var count = 0;

            for (var i = 0; i < N; i++)
            {
                a[i] = random.Next(100000, 1000000);
                b[i] = random.Next(100000, 1000000);
            }

            for (var i = 0; i < N; i++)
            {
                if (rank(a[i], b) != -1)
                    count++;
            }

            return count;
        }

        // 重载方法，用于启动二分查找
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1, 1);
        }

        // 二分查找
        public static int rank(int key, int[] a, int lo, int hi, int number)
        {
            if (lo > hi)
            {
                return -1;
            }

            var mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1, number + 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi, number + 1);
            }
            else
            {
                return mid;
            }
        }

        /// <summary>
        /// 在控制台上输出矩阵。
        /// </summary>
        /// <param name="a">需要输出的矩阵。</param>
        public static void PrintMatrix(double[,] a)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"\t{a[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}