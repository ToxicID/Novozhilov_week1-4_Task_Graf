using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_3
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
        static double fun(double x)
        {
            double y;
            if (x < 0)
                y = -4.0;
            else if (x >= 1.0)
                y = 2.0;
            else
                y = Math.Pow(x, 2.0) + 3.0 * x + 4.0;
            return y;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            double a, b, h;
            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                MessageBox.Show("Начало диапозона не может быть больше конца диапозона",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);

                return;
            }
            else if (numericUpDown3.Value <= 0)
            {
                MessageBox.Show("Шаг не может быть отрицательным или равным 0.\nПовторите попытку.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            a = (double)numericUpDown1.Value;
            b = (double)numericUpDown2.Value;
            h = (double)numericUpDown3.Value;

            for (double i = a; i <= b; i += h)
            {
                textBox1.Text += $"f({i:f2})={fun(i):f2}" + Environment.NewLine;
            }

        }
    }
}
