using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_4
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

        void rec(int n, int kol)
        {
            //Проверка на то что начальное число дошло до числа введённого пользователем
            if (kol > n)
                return;
            //Присваивание значение переменной kol, потому что к этом числу идёт прибавление в повторном вызове метода
            //Вычитание i , потому что числа должны выводиться от наибольшего до наименьшего
            for (int i = kol; i > 0; --i)
            {
                textBox1.Text += "  " + i;
            }
            textBox1.Text += " " + Environment.NewLine;
            rec(n, kol + 1);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int n;

            Console.Write("Введите n=");
            if (numericUpDown2.Value <= 0)
            {
                MessageBox.Show("Ошибка при вводе данных, число n не может быть меньше или равным 0",
                    "Произошла ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            n = (int)numericUpDown2.Value;
            rec(n, 1);
   
        }
    }
}

