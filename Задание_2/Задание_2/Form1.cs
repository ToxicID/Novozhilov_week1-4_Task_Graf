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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = (double)numericUpDown1.Value;
            var y = (double)numericUpDown2.Value;
            //первая проверка для того чтобы понимать находится ли введённая точка в зоне
            if (y <= -Math.Abs(x) && x * x + y * y <= 625)
            {
                //Строгая проверка, на случай если в первой числа были равны окончанию "диапозона"
                if (y < -Math.Abs(x) && x * x + y * y < 625)
                   textBox1.Text = $"Выбранная точка с координатами x={x} и y={y} находится в зашрихованной области";
                //если проверка ложная, тогда на границе
                else
                    textBox1.Text = $"Выбранная точка с координатами x={x} и y={y} находится на границе зашрихованной области";
            }
            //если if ложно, тогда точка вне области
            else
                textBox1.Text = $"Выбранная точка с координатами x={x} и y={y} находится не в зашрихованной области"; ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
    }
}
