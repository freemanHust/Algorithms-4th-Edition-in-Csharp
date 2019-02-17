﻿using System;
using System.IO;

namespace SymbolTable
{
    /// <summary>
    /// 计算文本文档中出现次数最高的字符串，
    /// 用于测试符号表的 Get 和 Put 方法。
    /// </summary>
    public class FrequencyCounter
    {
        /// <summary>
        /// 这个类不能被初始化。
        /// </summary>
        private FrequencyCounter() { }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串。</returns>
        public static string MostFrequentlyWord(string filename, int minLength, IST<string, int> st)
        {
            int distinct = 0, words = 0;
            StreamReader sr = new StreamReader(File.OpenRead(filename));

            string[] inputs = 
                sr
                .ReadToEnd()
                .Split(new char[] { ' ', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in inputs)
            {
                if (s.Length < minLength)
                    continue;
                words++;
                if (st.Contains(s))
                {
                    st.Put(s, st.Get(s) + 1);
                }
                else
                {
                    st.Put(s, 1);
                    distinct++;
                }
            }

            string max = "";
            st.Put(max, 0);
            foreach (string s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }
    }
}
