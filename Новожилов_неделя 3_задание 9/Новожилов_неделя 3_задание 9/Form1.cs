using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Новожилов_неделя_3_задание_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(numericUpDown1.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Некорректный ввод данных, повторите попытку ещё раз\n", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] array = new int[n];
            try
            {


                string[] text = textBox1.Text.Split(' ');

                for (int i = 0; i < n; i++)
                {
                    if (text.Length != n) throw new Exception();
                    array[i] = int.Parse(text[i]);

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при вводе данных. Заполните все поля правильно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Console.Write("Введите число, исходя из которого в файл будет записываться определённые числа: ");
           

            if (!int.TryParse(numericUpDown2.Text, out int number) || number<=0)
            {
                MessageBox.Show("Некорректный ввод данных, повторите попытку ещё раз\n", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            FileStream f = new FileStream("text.dat", FileMode.Create);
            BinaryWriter fOut = new BinaryWriter(f);

            foreach (var s in array)
            {
                if (s % number != 0)
                    fOut.Write(s);
            }

            fOut.Close();

            f = new FileStream("text.dat", FileMode.Open);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            using (BinaryReader fIn = new BinaryReader(f))
            {
                using (StreamWriter wr = new StreamWriter(File.Open(filename, FileMode.Create), Encoding.UTF8))
                {
                    while (fIn.PeekChar() > -1)
                    {
                        int num = fIn.ReadInt32();
                        wr.Write(num + " ");
                    }
                }

            }
            f.Close();

            using (StreamReader fRead = new StreamReader(filename))
            {
                string? s = fRead.ReadLine();
                textBox2.Text = "Запись в файле: " + s;
            }

            Console.ReadLine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }
    }
    }

