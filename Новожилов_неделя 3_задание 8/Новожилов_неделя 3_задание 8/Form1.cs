using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Новожилов_неделя_3_задание_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string text = textBox1.Text;
            Regex regex = new Regex(@"\b[уеёыаоэяию][а-я]+\b", RegexOptions.IgnoreCase);
            // \b -начало на границе слова
            // RegexOptions.IgnoreCase - игнорирует регистр
            var result = regex.Replace(text, "");

            // строчка означает то, что один или более пробелов в строке result заменяются на один пробел
            result = Regex.Replace(result, @"\s+", " ");
            textBox2.Text = result;
        }
    }
}
