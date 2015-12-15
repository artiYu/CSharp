using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DataList
{
    public partial class Form1 : Form
    {
        private ListWords dictionary = new ListWords();
        private bool isLoadedDB = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            if (!isLoadedDB)
            {
                MessageBox.Show(this, "База данных не создана.\nСоздайте базу данных.", "Внимание!");
                btnCreateDB_Click(this, e);
                return;
            }

            String line;
            StreamReader file = new StreamReader(ofd.FileName);

            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    dictionary.AddWord(line);
                }
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("База данных не загружена.", ex);
            }

            MessageBox.Show(this, "База данных из файла \"" + ofd.FileName + "\" успешно загружена.",
                "База данных загружена");

            tbSearch.Text = "";
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text files (*.txt) |*.txt| All files (*.*)|*.*";
            ofd.Title = "Выберите базу данных";
            ofd.FileName = "";
            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (ofd.ShowDialog() == DialogResult.OK)
                isLoadedDB = true;

            tbSearch.Text = "";
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!isLoadedDB)
            {
                MessageBox.Show("База данных не загружена. Создайте новую базу и загрузите ее.");
                btnCreateDB_Click(this, e);
                return;
            }

            CollectSearchedWords(tbSearch.Text);
        }

        /// <summary>
        /// Метод сбора слов с заданной подстрокой из загруженного словаря
        /// </summary>
        /// <param name="searchWord">заданная подстрока</param>
        private void CollectSearchedWords(string searchWord)
        {
            //для избежания повторов выбранных слов используется структура HashSet<string>
            HashSet<string> wordSet = new HashSet<string>();

            foreach (var word in dictionary)
            {
                if (SuffixArray.SearchSubstring(searchWord, word, dictionary[word]))
                {
                    wordSet.Add(word);
                }
            }

            FillRichTextBox(searchWord, wordSet);
        }

        /// <summary>
        /// Заполнение блока в соответствии с заданным строковым шаблоном
        /// </summary>
        /// <param name="searchWord">подстрока, которая ищется (шаблон)</param>
        /// <param name="wordSet">набор слов, которым заполняется блок</param>
        private void FillRichTextBox(string searchWord, HashSet<string> wordSet)
        {
            rtbWords.Text = "";

            if (wordSet.Count == 0 || String.IsNullOrEmpty(searchWord))
            {
                rtbWords.Text = "";
                return;
            }

            foreach (var word in wordSet)
            {
                rtbWords.Text += word + "\n";
            }
        }
    }
}