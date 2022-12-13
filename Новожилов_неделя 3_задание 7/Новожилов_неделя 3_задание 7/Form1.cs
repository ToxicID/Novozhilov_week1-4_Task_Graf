using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Новожилов_неделя_3_задание_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)) throw new Exception();
                string? str = textBox1.Text;
                string x = textBox3.Text;
                StringBuilder stringBuilder = new StringBuilder(str);
                stringBuilder.Replace(x, x + x);
                string res = stringBuilder.ToString();
                textBox2.Text = res;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при работе программы. Заполните все поля.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
