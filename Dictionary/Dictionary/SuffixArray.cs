using System;

namespace DataList
{
    /// <summary>
    /// Вспомогательный класс для удобного поиска подстроки в тексте
    /// </summary>
    class SuffixArray
    {
        /// <summary>
        /// Построение суффиксного массива путем сортировки циклических сдвигов строки
        /// </summary>
        /// <param name="S">исходная строка</param>
        /// <returns>суффиксный массив</returns>
        public static int[] CreateSuffixArray(String S)
        {
            int n = S.Length;
            int[] orderCh = new int[n];
            for (int i = 0; i < n; i++)
                orderCh[i] = n - 1 - i;

            Array.Sort(orderCh, (x, y) => String.Compare(S[x].ToString(), S[y].ToString(), StringComparison.CurrentCultureIgnoreCase));
           
            //массив индексов отсортированных циклических подстрок размера 2^i
            int[] sa = new int[n];

            //номера классов эквивалентности, которому принадлежит подстрока
            int[] classEq = new int[n];

            for (int i = 0; i < n; i++)
            {
                sa[i] = orderCh[i];
                classEq[i] = S[i];
            }

            for (int dt = 1; dt < n; dt *= 2)
            {
                //int[] c = (int[])classEq.Clone();
                int[] c = new int[classEq.Length];
                Array.Copy(classEq, c, classEq.Length);

                //заполнение классов эквивалентности для каждой подстроки
                for (int i = 0; i < n; i++)
                {
                    classEq[sa[i]] = i > 0 && 
                        c[sa[i - 1]] == c[sa[i]] && 
                        sa[i - 1] + dt < n && 
                        c[sa[i - 1] + dt / 2] == c[sa[i] + dt / 2] ? classEq[sa[i - 1]] : i;
                }
                 //сортировка по следующим 2*dt символам
                int[] ord = new int[n];
                for (int i = 0; i < n; i++)
                    ord[i] = i;
                int[] s = new int[sa.Length];
                Array.Copy(sa, s, sa.Length);
                //в s сортировка по первым dt элементам

                for (int i = 0; i < n; i++)
                {
                    //вычисление "первого" элемента, с которого нужно начинать следующую сортировку (после dt)
                    int s1 = s[i] - dt;

                    if (s1 >= 0)
                        sa[ord[classEq[s1]]++] = s1;
                }
            }
            return sa;
        }

        /// <summary>
        /// Поиск подстроки в тексте (с препроцессингом)
        /// </summary>
        /// <param name="pattern">подстрока, которая ищется</param>
        /// <param name="text"></param>
        /// <param name="suffArr"></param>
        /// <returns></returns>
        public static bool SearchSubstring(String pattern, String text, int[] suffArr)
        {
            int patternLength = pattern.Length;
            int textLength = text.Length;
            int comp = 0;

            //двоичный поиск по суффиксам: ищем префикс, совпадающий с pattern
            int left = 0, right = textLength - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;


                int len = text.Substring(suffArr[mid]).Length;
                patternLength = len < pattern.Length ? len : pattern.Length;
                comp = String.Compare(pattern, text.Substring(suffArr[mid], patternLength), StringComparison.InvariantCultureIgnoreCase);

                if (comp == 0)
                {
                    return true;
                }

                if (comp < 0) right = mid - 1;

                else left = mid + 1;
            }

            return false;
        }
    }
}
