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
        private int[ , ] reqMatrix; // 2-мерная матрица для зависимостей
        private bool isCycle = false; // флаг для циклической зависимости

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

                // вызываем рекурсивную функцию по поиску текстовиков
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

                // инициализируем квадратную матрицу на кол-во путей
                reqMatrix = new int[listPaths.Count, listPaths.Count];

                // формируем матрицу зависимостей
                FillReqMatrix(listPaths,reqMatrix);

                // проверяем матрицу на наличие циклических зависимостей
                for (int i = 0; i < reqMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < reqMatrix.GetLength(1); j++)
                    {
                        // если единицы зеркально расположены (диагональ считается)
                        if (reqMatrix[i,j] == reqMatrix[j, i] && reqMatrix[i,j] == 1)
                        {
                            isCycle = true;
                            richTextBoxOut.Text += "\n Циклическа зависимость: \n"
                                                   + listPaths.ElementAt(i) + "\n"
                                                   + listPaths.ElementAt(j);
                        }
                    }
                }

                // если не нашли циклическую зависимость
                if (isCycle == false)
                {
                    // сортируем список путей
                    // пробегаем по матрице
                    for (int i = 0; i < reqMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < reqMatrix.GetLength(1); j++)
                        {
                            // если нашли зависимость
                            if (reqMatrix[i,j] == 1)
                            {
                                // и если зависимый элемент выше главного (индекс меньше)
                                if(i < j)
                                {
                                    // перемещаем его ниже главного
                                    string temp = listPaths[i];
                                    listPaths.RemoveAt(i);
                                    listPaths.Insert(j, temp);
                                }
                            }
                        }
                    }
                }
                foreach(string path in listPaths)
                {
                    richTextBoxOut.Text += "\n" + path;
                }
                // вызываем метод для объединения файлов в один файл
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
        // метод принимает на вход путь до папки, в которой ищем текстовики,
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

        // метод объединяет найденные ранее файлы в один файл
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
            isCycle = false;
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

        // метод заполняет матрицу зависимостей
        private void FillReqMatrix(List<string> paths, int[,] matrix)
        {
            // для каждого пути
            for (int i = 0; i < paths.Count; i++)
            {
                // создаем лист для require строк
                List<string> rStr = new List<string>();
                // находим строки и заполняем лист
                // для каждой строки в файле текущего пути
                foreach (string line in File.ReadAllLines(paths[i]))
                {
                    // если находится строка со словом require
                    if (line.Contains("require"))
                    {
                        // определяем границы подстроки для line
                        int strInit = line.IndexOf('"') + 1;
                        int strEnd = line.IndexOf('"', strInit);
                        // выделяем подстроку, соединяя с корневым каталогом и расширением
                        string strAdd = rootPath + "\\" + line.Substring(strInit, strEnd - strInit) + ".txt";
                        // добавляем в лист для require
                        rStr.Add(strAdd);
                    }
                }
                // если удалось собрать строки require
                if(rStr.Count > 0)
                {
                    // для каждой собранной строки
                    for (int n = 0; n < rStr.Count; n++)
                    {
                        // пробегаем по всем путям
                        for (int k = 0; k < paths.Count; k++)
                        {
                            // и если находим совпадение
                            if(rStr[n].Equals(paths[k]))
                            {
                                // записываем в матрицу 1 на месте k-того столбца (строка определяется i)
                                matrix[i, k] = 1;
                            }
                        }
                    }
                }
            }
        }
        

        
    }
}
