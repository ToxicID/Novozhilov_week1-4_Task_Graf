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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        static int[][] Input(int n)
        {
            
            int[][] array = new int[n][];
            Random random = new Random();
            for (int j = 0; j < n; j++)
            {
                array[j] = new int[n];
                for (int i = 0; i < n; i++)
                {
                    
                    array[j][i] = random.Next(-50,100);
                }
            }

            return array;
        }

         void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                textBox1.Text += array[i] + "\t";
            }
            textBox1.Text += Environment.NewLine;
        }
         void Print(int[][] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array[j].Length; i++)
                {
                    textBox1.Text += array[j][i] + "\t";
                }
                textBox1.Text += Environment.NewLine;
            }
        }

        static int[] Sum(int[][] array, int n)
        {

            int[] sum = new int[n];
            for (int j = 0; j < array.Length; j++)
            {
                int res = 0;
                for (int i = 0; i < array[j].Length; i++)
                {
                    if (array[i][j] > 0 && array[i][j] % 2 == 0)
                    {
                        res += array[i][j];
                    }

                }
                sum[j] = res;

            }

            return sum;
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

            int[][] newArray = Input(n);
            textBox1.Text += "Ступенчатый массив" + Environment.NewLine;
            Print(newArray);
            int[] sum = Sum(newArray, n);
            textBox1.Text += "Массив с суммами" + Environment.NewLine;
            Print(sum);
        }
    }
}
