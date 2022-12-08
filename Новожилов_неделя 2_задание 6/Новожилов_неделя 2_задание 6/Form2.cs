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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        static int[,] Input(int n, int m)
        {
            
            int[,] array = new int[n, m];

            Random random = new Random();
            for (int i = 0; i < n; i++)
            {

                for (int g = 0; g < m; g++)
                {
                    array[i, g] = random.Next(-100, 100);
                    
                }


            }

            return array;
        }

         void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    textBox1.Text += array[i, j] + "\t";
                }
                textBox1.Text += Environment.NewLine;
            }

        }
        static int Counting(int[,] array)
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
            int n, m;
            
                
                if (!int.TryParse(numericUpDown1.Text, out n) || n <= 0)
                {
                    MessageBox.Show("Некорректный ввод данных. Попробуйте снова"
                        ,"Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
               

                Console.Write("Введите количество элементов в каждой строке:");
                if (!int.TryParse(numericUpDown2.Text, out m) || m <= 0)
                {
                    MessageBox.Show("Некорректный ввод данных. Попробуйте снова"
                        , "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
               
            int[,] newArray = Input(n,m);
                Console.WriteLine();
               textBox1.Text +="Массив:" + Environment.NewLine;
                Print(newArray);
               textBox1.Text +=$"Количество нечётных элементов в массиве равняется:{Counting(newArray)}";
              
            
        }
    }
}
