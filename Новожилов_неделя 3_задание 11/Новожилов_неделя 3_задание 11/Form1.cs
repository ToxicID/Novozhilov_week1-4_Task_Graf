using System.Windows.Forms;

namespace Новожилов_неделя_3_задание_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class MyNewClass
        {
            double[][] DoubleArray;
            int n, m;
            //Создание массива
            public MyNewClass(int rows, int cols)
            {
                n = rows;
                m = cols;
                DoubleArray = new double[n][];
            }
            //Заполнение массива с проверкой на пустоту в textBox2
            //Массив создаётся из textBox2 записывая его в строчный двухмерный с проверкой на возможность парса
            //А так же с проверкой на соответствие количества строк и столбцов
            public void FillingTheArray(TextBox textBox2)
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Введите элементы массива.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var sNums = new string[n, m];
                var arr1 = textBox2.Text.Split('\n');
                if (arr1.Length != n)
                {
                    MessageBox.Show("Длина массива не соответствует введенному!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    var arr2 = arr1[i].Split(' ');
                    if (arr2.Length != m)
                    {
                        MessageBox.Show("Длина массива не соответствует введенному!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int j = 0; j < m; j++)
                    {

                        sNums[i, j] = arr2[j];
                    }
                }
                
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        DoubleArray[i] = new double[m];
                        for (int j = 0; j < m; j++)
                        {


                            DoubleArray[i][j] = double.Parse(sNums[i, j]);
                        }
                    }
                    MessageBox.Show("Массив заполнен");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некорректный ввод данных. Попробуйте снова",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            //Вывод массива на экран
            public void Print(TextBox textBox1)
            {
                for (int i = 0; i < DoubleArray.Length; i++)
                {
                    for (int j = 0; j < DoubleArray[i].Length; j++)
                    {
                        textBox1.Text += DoubleArray[i][j] + "\t";
                    }
                    textBox1.Text += Environment.NewLine;
                }

            }
            //Сортировка массива
            public void Sort()
            {
                for (var i = 0; i < DoubleArray.Length; ++i)
                {
                    Array.Sort(DoubleArray[i]);
                    Array.Reverse(DoubleArray[i]);
                }
            }
            //Количество элементов
            //Свойство доступное только для чтения
            public int CountElem
            {
                get { return n * m; }
            }
            //Увеличение на скаляр
            //Свойство доступное только для записи
            public double ZoomScalar
            {
                set
                {
                    for (int i = 0; i < DoubleArray.Length; i++)
                    {
                        for (int j = 0; j < DoubleArray[i].Length; j++)
                        {
                            DoubleArray[i][j] += value;
                        }

                    }
                }
            }
        }
        MyNewClass newClass;
        int n, m;

        //Кнопка для создания массива с проверкой на введённое количество строк и столбцов
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(numericUpDown1.Text, out n) || n <= 0)
            {
                MessageBox.Show("Некорректный ввод данных. Количество строк не может быть меньше или равным 0",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(numericUpDown2.Text, out m) || m <= 0)
            {
                MessageBox.Show("Некорректный ввод данных. Количество столбцов не может быть меньше или равным 0",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            //Выделение памяти под массив
            newClass = new MyNewClass(n, m);
            MessageBox.Show("Был создан новый массив");
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    //Заполнение массива
                    case 0:

                        newClass.FillingTheArray(textBox2);

                        break;


                    case 1:

                        textBox1.Text = "";
                        textBox1.Text += "Массива:" + Environment.NewLine;
                        newClass.Print(textBox1);

                        break;


                    case 2:

                        newClass.Sort();
                        MessageBox.Show("Массива отсортирован");

                        break;


                    case 3:

                        textBox1.Text = $"Количество элементов в массиве: {newClass.CountElem}";

                        break;

                    case 4:

                        Console.Write("Введите скаляр: ");
                        double scalar;

                        if (!double.TryParse(numericUpDown3.Text, out scalar) || scalar <= 0)
                        {
                            MessageBox.Show("Произошла ошибка. Попробуйте ещё раз.\nСкаляр не может быть меньше или равным 0",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }
                        
                        newClass.ZoomScalar = scalar;
                        MessageBox.Show("Все элементы увеличины на скаляр");

                        break;

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка.Сначала создайте массив", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}