﻿namespace _3._2._24
{
    class Program
    {
        static void Main(string[] args)
        {
            // 根据命题 D （英文版 P404，中文版 P255），一次插入所需的比较次数平均为 1.39\lg N。
            // (我们这里要求和，因此可以直接使用平均值进行计算）
            // 于是构造一棵二叉查找树所需的比较次数为：
            // 1.39 x (lg1 + lg2 +...+ lgN)=1.39lg(N!)>lg(N!)
        }
    }
}
