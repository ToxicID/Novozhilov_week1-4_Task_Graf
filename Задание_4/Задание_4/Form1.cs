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
        static double rec(double x, int n)
        {
            if (n == 0)
                return 1;
            else if (n < 0)
            {
                return 1 / Math.Pow(x, Math.Abs(n));
            }
            //Если n>0 
            return x * rec(x, n - 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            int n;

            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Число x, не может быть равно 0. Попробуйте попытку, введя другое число",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            x = (double)numericUpDown1.Value;
            n = (int)numericUpDown2.Value;

            textBox1.Text = $"x^n = {Math.Round(rec(x, n),5)}";

        }
    }
}

