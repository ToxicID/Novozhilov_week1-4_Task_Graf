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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBox1.Text)) throw new Exception();
                string str = textBox1.Text;
                string[] slova = str.Split(' ');
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < slova.Length; ++i)
                {
                    //Если условие истинно в строчке есть одинаковые слова вне зависимости от регистра
                    //Если равняется -1, тогда просто идёт запись в переменную sb класса StringBilder
                    //Если не равняется -1 тогда слово, не записывается
                    if (sb.ToString().ToLower().IndexOf(slova[i].ToLower()) == -1)
                        sb.Append(slova[i] + " ");
                }
                textBox2.Text = sb.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Введите данные в textBox и повторите попытку ещё раз.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }
    }
}
