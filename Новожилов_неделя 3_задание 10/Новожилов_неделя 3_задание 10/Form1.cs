using System.Diagnostics;

namespace Новожилов_неделя_3_задание_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            if (Directory.Exists("C:\\temp")) { Directory.Delete("C:\\temp", true); }
            else
                Directory.CreateDirectory("C:\\temp");


            Directory.CreateDirectory("C:\\temp\\K1");
            Directory.CreateDirectory("C:\\temp\\K2");
            //t1.txt
            using (StreamWriter sw = new StreamWriter("C:\\temp\\K1\\t1.txt", false))
            {
                sw.WriteLine("Новожилов Илья Александрович, 1965 года рождения, место жительства г. Саратов");
           
            }
            //t2.txt
            using (StreamWriter sw = new StreamWriter("C:\\temp\\K1\\t2.txt", false))
            {
                sw.WriteLine("Новожилов Илья Александрович, 1966 года рождения, место жительства г.Энгельс");
                
            }
            //Запись в один файл - t3.txt
            using (StreamWriter sw = new StreamWriter("C:\\temp\\K2\\t3.txt", false))
            {
                string str;
                using (StreamReader sr = new StreamReader("C:\\temp\\K1\\t1.txt"))
                {
                    str = sr.ReadToEnd();
                }
                sw.WriteLine(str);
                using (StreamReader sr = new StreamReader("C:\\temp\\K1\\t2.txt"))
                {
                    str = sr.ReadToEnd();
                }
                sw.WriteLine(str);
            }
            //Информация о файлах
            DirectoryInfo dir1 = new DirectoryInfo("C:\\temp\\K1");
            DirectoryInfo dir2 = new DirectoryInfo("C:\\temp\\K2");

            FileInfo[] info = dir1.GetFiles();
            foreach (FileInfo file in info)
            {
                textBox1.Text += "Путь к файлу: " + file.FullName.ToString() + Environment.NewLine +
                    "Имя файла: " + file.Name.ToString() + Environment.NewLine +
                   "Расширение файла: " + file.Extension.ToString() + Environment.NewLine +
                    "Размер файла (в байтах): " + file.Length.ToString() + Environment.NewLine +
                    "Время создания файла: " + file.CreationTime.ToString() + Environment.NewLine +
                    "Последнее время записи файла: " + file.LastWriteTime.ToString();
                textBox1.Text += Environment.NewLine + Environment.NewLine;
            }
            
            FileInfo[] info2 = dir2.GetFiles();
            foreach (FileInfo file in info2)
            {
                textBox2.Text += "Путь к файлу: " + file.FullName.ToString() + Environment.NewLine +
                    "Имя файла: " + file.Name.ToString() + Environment.NewLine +
                   "Расширение файла: " + file.Extension.ToString() + Environment.NewLine +
                    "Размер файла (в байтах): " + file.Length.ToString() + Environment.NewLine +
                    "Время создания файла: " + file.CreationTime.ToString() + Environment.NewLine +
                    "Последнее время записи файла: " + file.LastWriteTime.ToString();
                textBox2.Text += Environment.NewLine + Environment.NewLine;
            }
            //Перемещение
            File.Move("C:\\temp\\K1\\t2.txt", "C:\\temp\\K2\\t2.txt");
            //Копирование с перезаписью(если файл есть)
            File.Copy("C:\\temp\\K1\\t1.txt", "C:\\temp\\K2\\t1.txt", true);
            //Переменование файла K2 в ALL
            Directory.Move("C:\\temp\\K2", "C:\\temp\\ALL");
            //Удаление папки K1 и все файлы в нём
            Directory.Delete("C:\\temp\\K1", true);

          
            DirectoryInfo dir3 = new DirectoryInfo("C:\\temp\\ALL");
            FileInfo[] info3 = dir3.GetFiles();

            foreach (FileInfo file in info3)
            {
                textBox3.Text += "Путь к файлу: " + file.FullName.ToString() + Environment.NewLine +
                    "Имя файла: " + file.Name.ToString() + Environment.NewLine +
                   "Расширение файла: " + file.Extension.ToString() + Environment.NewLine +
                    "Размер файла (в байтах): " + file.Length.ToString() + Environment.NewLine +
                    "Файл доступен только для чтения или нет (True - Только для чтения, False - для чтения и записи): " + file.IsReadOnly.ToString() + Environment.NewLine +
                    "Атрибут файла: " + file.Attributes.ToString() + Environment.NewLine +
                   "Время создания файла: " + file.CreationTime.ToString() + Environment.NewLine +
                    "Последнее время записи файла: " + file.LastWriteTime.ToString();
                textBox3.Text += Environment.NewLine + Environment.NewLine;
            }
            //Запуск Проводника с путём C:\\temp
            Process.Start("explorer", "C:\\temp");
        }
    }
}