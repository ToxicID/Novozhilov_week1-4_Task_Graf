using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_1._1
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

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (!(numericUpDown1.Value >= -99 && numericUpDown1.Value<=-10 || numericUpDown1.Value <= 99 && numericUpDown1.Value>=10)) {
                MessageBox.Show("Произошла ошибка. Вы ввели не двухзначное число", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;        
            }
            int num = (int)numericUpDown1.Value;
            bool res = num % 11 == 0 ? true : false;
            if (res)
                textBox1.Text = $"Цифры числа {numericUpDown1.Value} одинаковы";
            else
                textBox1.Text = $"Цифры числа {numericUpDown1.Value} неодинаковы";
        }
    }
}
