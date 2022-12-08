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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
        static double[] Input(int n)
        {

            double[] array = new double[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(random.NextDouble() * 100,3);
            }

            return array;
        }
         void Print(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                textBox1.Text += array[i] + "\t";
            }
            textBox1.Text += Environment.NewLine;
        }
        static int IndexOf(double[] array, double value)
        {
            int s = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    s = i;
                }
            }
            return s;
        }
        static double Search(double[] array)
        {
            double col = array[0];

            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (col < array[i])
                    col = array[i];
            }
            return col;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (!int.TryParse(numericUpDown1.Text, out int n) || n <= 0)
            {
               MessageBox.Show("Некорректный ввод данных. Попробуйте снова",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            double[] array = Input(n);

            double num = Search(array);
            textBox1.Text += "Массив:" + Environment.NewLine;
            Print(array);
            textBox1.Text += $"Последний максимальный элемент:{num} его индект {IndexOf(array, num)}";
        }
    }
}
