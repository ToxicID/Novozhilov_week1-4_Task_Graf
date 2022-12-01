using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Задание 4
            textBox1.Text = "";
            int v;
            int l = 6;
            for (int a = 1; a <= 5; ++a, textBox1.Text+=" "+Environment.NewLine)
            {
                for (v = 6 - a; v >= 1; --v)
                {
                    textBox1.Text += "       " + l;
                }
                l++;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
    }
}
