using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataList
{
    /// <summary>
    /// Класс-структура для хранения пар "слово-суффиксный массив"
    /// </summary>
    internal class ListWords : IEnumerable<string>
    {
        private Dictionary<String, int[]> list;

        /// <summary>
        /// Конструктор по умолчанию, создающий словарь базы данных
        /// </summary>
        public ListWords()
        {
            list = new Dictionary<string, int[]>();
        }

        /// <summary>
        /// Добавление текста в структуру (с одновременным созданием суффиксного массива)
        /// </summary>
        /// <param name="word">текст</param>
        public void AddWord(String word)
        {
            int[] suffixes = SuffixArray.CreateSuffixArray(word);
            list[word] = suffixes;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return list.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int[] this[string word]
        {
            get { return list[word]; }
        }

        public override string ToString()
        {
            String s = "";
            foreach (var d in list)
            {
                s += "[ " + d.Key + ", {";
                s = d.Value.Aggregate(s, (current, i) => current + (i + " "));
                s += "} ]";
            }
            return s;
        }    
    }
}