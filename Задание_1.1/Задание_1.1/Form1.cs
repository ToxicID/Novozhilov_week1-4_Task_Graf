namespace Задание_1._1
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            var a = (double)numericUpDown1.Value;
                    var b = (double)numericUpDown2.Value;
          
            var P = Math.Round(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) + b + a, 4);

            textBox1.Text = $"Периметр прямоугольного треугольника с катетами {a} и {b} равен: {P}";
        }
    }
}