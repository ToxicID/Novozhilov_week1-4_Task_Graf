using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Новожилов_неделя_3_задание_9
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;


            string[] lines = File.ReadAllLines(filename);
            textBox1.Text = "Символ из каждой строки:\n";
            int i = 1;
            foreach (string line in lines)
            {
                try
                {
                    if (line[0] == ' ')
                        textBox1.Text += $"Строка №{i}:" + "Пробел" + Environment.NewLine;
                    else textBox1.Text += $"Строка №{i}:" + line[0] + Environment.NewLine;
                    i++;
                }
                catch (Exception)
                {
                    textBox1.Text += $"Строка №{i}:" +"Пустая строка" + Environment.NewLine;
                    i++;
                }
            }
        }
    }
}

