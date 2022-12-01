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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int m;
              if (numericUpDown1.Value<=0)
                {
                MessageBox.Show("Вы ввели неверное число. Повторите попытку\nЧисло не может быть меньше или равным 0",
                                "Ошибка", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                    return;
                }
            m = (int)numericUpDown1.Value;
            DateTime dt = new DateTime(1990, 1, 1);
            int x = dt.Month + m % 12;
            string month = "";
            switch (x)
            {

                case 1:
                    month = "Январь";
                    break;
                case 2:
                    month = "Февраль";
                    break;
                case 3:
                    month = "Март";
                    break;
                case 4:
                    month = "Апрель";
                    break;
                case 5:
                    month = "Май";
                    break;
                case 6:
                    month = "Июнь";
                    break;
                case 7:
                    month = "Июль";
                    break;
                case 8:
                    month = "Август";
                    break;
                case 9:
                    month = "Сентябрь";
                    break;
                case 10:
                    month = "Октябрь";
                    break;
                case 11:
                    month = "Ноябрь";
                    break;
                case 12:
                    month = "Декабрь";
                    break;
            }

            textBox1.Text = $"Сейчас: {month}";
            
        }
    }
}
