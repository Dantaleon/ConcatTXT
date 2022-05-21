using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ConcatTXT
{
    public partial class Form1 : Form
    {
        private string rootPath; // для пути до папки
        private List<string> listPaths = new List<string>(); // для путей txt файлов
        private string rootPathOut; // для пути до выходного файла

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            rootPath = textBoxPath.Text;
            // определяем путь выходного файла
            rootPathOut = rootPath + "\\output567.txt";

            // если есть директория по указанному пути
            if (Directory.Exists(rootPath))
            {
                richTextBoxLog.Text += "\nПапка существует.";

                btnClearAll.Enabled = true;
                btnStart.Enabled = false;

                // вызываем рекурсивную функцию
                FindTxtFiles(rootPath, listPaths);
            }
            else
            {
                // иначе выводим проблему в label
                richTextBoxLog.Text += "\nПапка не найдена.";
            }

            if (listPaths.Count > 0)
            {
                richTextBoxLog.Text += "\nТекстовые файлы найдены.";
                // сортируем лист по алфавиту (в листе указаны полные пути, начиная с диска)
                listPaths.Sort();

                // выводим массив в текстовое поле
                foreach (string str in listPaths)
                {
                    richTextBoxOut.Text += str + "\n";
                }
                // вызываем функцию для объединения файлов в один файл
                ConcatTxtFiles(listPaths, rootPath);
            }
            else
            {
                richTextBoxLog.Text += "\nТекстовые файлы не найдены.";
            }
            if (File.Exists(rootPathOut))
                richTextBoxLog.Text += "\nВыходной файл сформирован."
                                       + "\nПуть: " + rootPathOut;

        }
        // функция принимает на вход путь до папки, в которой ищем текстовики,
        // и лист для записи путей
        private void FindTxtFiles(string path, List<string> listOut)
        {
            // добавляем каждый найденный файл в лист
            foreach(string filepath in Directory.GetFiles(path))
            {
                listOut.Add(filepath);
            }
            // для каждой найденной папки вызываем эту же функцию
            foreach(string subpath in Directory.GetDirectories(path))
            {
                FindTxtFiles(subpath, listOut);
            }
        }

        // функция объединяет найденные ранее файлы в один файл
        private void ConcatTxtFiles(List<string> txtPaths, string pathOut)
        {
            // создаем писаря для нового файла по пути пользователя
            StreamWriter writer = new StreamWriter(rootPath + "\\output567.txt", false);
            try
            {
                // для каждого пути из собранного листа
                foreach (string path in txtPaths)
                {
                    // используем чтеца
                    using (StreamReader reader = new StreamReader(path))
                    {
                        // читаем файл до конца
                        string text = reader.ReadToEnd();
                        // и передаем писарю
                        writer.WriteLine(text);
                    }
                }
            }
            catch (IOException)
            {
                richTextBoxLog.Text += "Не удается записать или прочитать выходной файл.\n"
                                        +"Убедитесь, что отсутствует файл по пути :\n"
                                        +rootPathOut
                                        + "и не используются любые файлы по пути :\n"
                                        + rootPath;
            }
            finally
            {
                writer.Close();
            }
        }

        // Удаляем файл и очищаем все переменные и поля
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (File.Exists(rootPathOut)) File.Delete(rootPath + "\\output567.txt");

            rootPath = "";
            rootPathOut = "";
            listPaths.Clear();

            textBoxPath.Text = "";
            richTextBoxOut.Text = "";
            richTextBoxLog.Text = "Состояние :";

            btnStart.Enabled = true;
            btnClearAll.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
