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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int n;
            int mn = 2;
            int i = 1;
            textBox1.Text = "";
            if (numericUpDown1.Value > 6 || numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Произошла ошибка при заполнении данных. Попробуйте ещё раз.\n Минимальное число 1, максимальное 6",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            n = (int)numericUpDown1.Value;


            textBox1.Text += "while" + Environment.NewLine;

            float InchInCentimeters = 2.54f;
            textBox1.Text += "Таблица перевода дюймов в сантиметры, слева дюймы, справа сантиметры" + Environment.NewLine;
            while (i <= n)
            {
                textBox1.Text += $"{mn}\t{mn * InchInCentimeters}" + Environment.NewLine;
                i++;
                mn += 2;
            }

            textBox1.Text += Environment.NewLine + "do...while" + Environment.NewLine;
            textBox1.Text += "Таблица перевода дюймов в сантиметры, слева дюймы, справа сантиметры" + Environment.NewLine;
            mn = 2;
            i = 1;
            do
            {

                textBox1.Text += $"{mn}\t{mn * InchInCentimeters}" + Environment.NewLine;
                i++;
                mn += 2;
            } while (i <= n);


            textBox1.Text += Environment.NewLine + "for" + Environment.NewLine;
            textBox1.Text += "Таблица перевода дюймов в сантиметры, слева дюймы, справа сантиметры" + Environment.NewLine;
            for (i = 1, mn = 2; i <= n; i++, mn += 2)
                textBox1.Text += $"{mn}\t{mn * InchInCentimeters}" + Environment.NewLine;


        }
    }
}
