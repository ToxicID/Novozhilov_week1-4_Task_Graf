using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Новожилов_неделя_2_задание_6
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
         int[,] Input(int n, string[,] sNums)
        {
            int[,] array = new int[n, n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int g = 0; g < n; g++)
                    {
                        array[i, g] = int.Parse(sNums[i, g]);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод данных. Попробуйте снова",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBox1.Text = "";
            }

            return array;
        }
        void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++, textBox1.Text += Environment.NewLine)
                for (int j = 0; j < array.GetLength(1); j++)
                    textBox1.Text += $"\t {array[i, j]} ";
        }

        static int[,] Exchange(int[,] array, int n)
        {
            //Клонирование исходного массива
            int[,] arrayCopy = (int[,])array.Clone();
            if (n % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        array[i, n / 2] = arrayCopy[i, (n / 2) - 1];
                        array[i, (n / 2) - 1] = arrayCopy[i, (n / 2)];
                    }
            }

            else if (n == 3 || n == 7 || n == 11 || n == 15)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        array[i, 0] = arrayCopy[i, (int)Math.Round(n / 2.0) - 1];
                        array[i, (int)Math.Round(n / 2.0) - 1] = arrayCopy[i, 0];
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        array[i, 0] = arrayCopy[i, (int)Math.Round(n / 2.0)];
                        array[i, (int)Math.Round(n / 2.0)] = arrayCopy[i, 0];
                    }
            }

            return array;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (!int.TryParse(numericUpDown1.Text, out int n) || n <= 1)
            {
                MessageBox.Show("Некорректный ввод данных. Попробуйте снова\nМинимальное число 2, поскольку массив двухмерный и если число меньше 2 то программа не имеет смысла",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {



                var sNums = new string[n, n];

                var arr1 = textBox2.Text.Split('\n');
                if(arr1.Length != n)
                {
                    MessageBox.Show("Длина массива не соответствует введенному!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    var arr2 = arr1[i].Split(' ');
                    if(arr2.Length != n)
                    {
                        MessageBox.Show("Длина массива не соответствует введенному!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int j = 0; j < n; j++)
                    {
                       
                        sNums[i, j] = arr2[j];
                    }
                }
                //Проперка на количество знаков
                if (sNums.Length > n * n)
                {
                    MessageBox.Show("Длина массива не соответствует введенному!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                int[,] myArray = Input(n, sNums);
                textBox1.Text += "Исходный массив:" + Environment.NewLine;
                Print(myArray);
                myArray = Exchange(myArray, n);
                Console.WriteLine();
                textBox1.Text += "Изменённый массив" + Environment.NewLine;
                Print(myArray);
            }
            catch (Exception)
            {
                    MessageBox.Show("Длина массива не соответствует введенному!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }
    }
}
