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
        static double f(double n)
        {

            return Math.Sqrt(n) + n;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            double res = f(6) / 2 + f(13) / 2 + f(21) / 2;
           
            textBox1.Text = "Результат вычисления=" + Math.Round(res, 5);
        }
    }
}
