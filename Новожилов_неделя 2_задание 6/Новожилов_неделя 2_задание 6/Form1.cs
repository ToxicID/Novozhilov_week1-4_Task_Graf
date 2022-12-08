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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        int[] Input(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-100, 100);
            }

            return array;
        }

        void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                textBox1.Text += array[i] + "\t";
            }
            textBox1.Text += "" + Environment.NewLine;
        }
        static int Counting(int[] array)
        {
            int CountingNums = 0;
            foreach (int c in array)
            {
                if (c > 0 && c % 2 != 0)
                    CountingNums++;
                if (c < 0 && -c % 2 != 0)
                    CountingNums++;
            }
            return CountingNums;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int n;
            if (!int.TryParse(numericUpDown1.Text, out n) || n <= 0)
            {
                MessageBox.Show("Некорректный ввод данных. Попробуйте снова",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            int[] newArray = Input(n);

            Print(newArray);
            textBox1.Text += $"Количество нечётных элементов в массиве равняется:{Counting(newArray)}";

        }
    }
}
