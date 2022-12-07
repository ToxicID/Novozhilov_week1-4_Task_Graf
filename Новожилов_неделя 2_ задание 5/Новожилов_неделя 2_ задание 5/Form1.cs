namespace Новожилов_неделя_2__задание_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static double f(double x)
        {
            try
            {
                //Данное условие используется для того чтобы под корнем не было 0 или отрицательного числа
                if (x <= 0.5) throw new Exception();
                else return Math.Round(x / Math.Sqrt(2 * x - 1), 5);
            }
            catch
            {
                throw;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {

                if (numericUpDown1.Value > numericUpDown2.Value) throw new Exception("Ошибка!!\nНачало диапозона не может быть больше конца диапозона.");
                else if (numericUpDown3.Value <= 0) throw new Exception("Ошибка!!\nШаг не может быть отрицательным или равным 0.");

                double start = (double)numericUpDown1.Value;
                double finish = (double)numericUpDown2.Value;


                double h = (double)numericUpDown3.Value;



                for (double i = start; i <= finish; i += h)
                    try
                    {
                        textBox1.Text += $"y({i:f2})={f(i):f4}" + Environment.NewLine;
                    }
                    catch
                    {
                        textBox1.Text += $"y({i})=error" + Environment.NewLine;
                    }

            }

            //при возникномении ошибки не связанной с форматом, выводим данные о ошибке указанные в скобках
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
    }
}