﻿using System;

namespace _1._4._19
{
    class Program
    {
        // 先查找 N/2 行中的最小元素，并令其与上下元素比较，
        // 如果不满足题意，则向相邻的最小元素靠近再次查找
        static void Main(string[] args)
        {
            var matrix = new int[5, 5]
            {
                { 26, 3, 4 , 10, 11 },
                { 5, 1, 6, 12, 13 },
                { 7, 8, 9 , 14, 15 },
                { 16, 17, 18, 27, 20 },
                { 21, 22, 23, 24, 25 }
            };
            Console.WriteLine(MinimumRow(matrix, 0, 5, 0, 5));
        }

        /// <summary>
        /// 在矩阵中间行查找局部最小。
        /// </summary>
        /// <param name="matrix">矩阵。</param>
        /// <param name="rowStart">实际查找范围的行起始。</param>
        /// <param name="rowLength">实际查找范围的行结尾。</param>
        /// <param name="colStart">实际查找范围的列起始。</param>
        /// <param name="colLength">实际查找范围的列结尾。</param>
        /// <returns>矩阵中的局部最小元素。</returns>
        static int MinimumRow(int[,] matrix, int rowStart, int rowLength, int colStart, int colLength)
        {
            var min = int.MaxValue;
            if (rowLength < 3)
                return int.MaxValue;
            var mid = rowStart + rowLength / 2;
            var minCol = 0;
            // 获取矩阵中间行的最小值
            for (var i = 0; i < colLength; i++)
            {
                if (min > matrix[mid, colStart + i])
                {
                    min = matrix[mid, colStart + i];
                    minCol = i;
                }
            }
            // 检查是否满足条件
            if (matrix[mid, minCol] < matrix[mid - 1, minCol] && matrix[mid, minCol] < matrix[mid + 1, minCol])
            {
                return matrix[mid, minCol];
            }
            // 如果不满足则向较小一侧移动
            if (matrix[mid - 1, minCol] > matrix[mid + 1, minCol])
            {
                return MinimumCol(matrix, rowStart, rowLength, mid + 1, colLength / 2 + 1);
            }
            else
            {
                return MinimumCol(matrix, rowStart, rowLength, colStart, colLength / 2 + 1);
            }
        }

        /// <summary>
        /// 在矩阵中间列查找局部最小。
        /// </summary>
        /// <param name="matrix">矩阵。</param>
        /// <param name="rowStart">实际查找范围的行起始。</param>
        /// <param name="rowLength">实际查找范围的行结尾。</param>
        /// <param name="colStart">实际查找范围的列起始。</param>
        /// <param name="colLength">实际查找范围的列结尾。</param>
        /// <returns>矩阵中的局部最小元素。</returns>
        static int MinimumCol(int[,] matrix, int rowStart, int rowLength, int colStart, int colLength)
        {
            var min = int.MaxValue;
            var n = matrix.GetLength(0);
            var mid = n / 2;
            var minRow = 0;

            // 获取矩阵中间列最小值
            for (var i = 0; i < n; i++)
            {
                if (min > matrix[i, mid])
                {
                    min = matrix[i, mid];
                    minRow = i;
                }
            }
            // 检查是否满足条件
            if (matrix[minRow, mid] < matrix[minRow, mid - 1] && matrix[minRow, mid] < matrix[minRow, mid + 1])
            {
                return matrix[minRow, mid];
            }
            // 如果不满足则向较小一侧移动
            if (matrix[minRow, mid - 1] > matrix[minRow, mid + 1])
            {
                return MinimumRow(matrix, mid + 1, rowLength / 2 + 1, colStart, colLength);
            }
            else
            {
                return MinimumRow(matrix, rowStart, rowLength / 2 + 1, colStart, colLength);
            }
        }
    }
}
