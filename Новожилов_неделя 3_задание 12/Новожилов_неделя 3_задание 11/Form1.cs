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
            //Двухмерный индексатор
            public double this[int n, int m]
            {
                get { return DoubleArray[n][m]; }
            }
            //Перегруженный оператор позволяющий увеличить значение всех элементов на 1
            public static MyNewClass operator ++(MyNewClass myNewClass)
            {
                for (int i = 0; i < myNewClass.DoubleArray.Length; i++)
                {
                    for (int j = 0; j < myNewClass.DoubleArray[i].Length; j++)
                    {
                        myNewClass.DoubleArray[i][j] += 1;
                    }

                }
                return myNewClass;
            }
            //Перегруженный оператор позволяющий уменьшить значение всех элементов на 1
            public static MyNewClass operator --(MyNewClass myNewClass)
            {
                for (int i = 0; i < myNewClass.DoubleArray.Length; i++)
                {
                    for (int j = 0; j < myNewClass.DoubleArray[i].Length; j++)
                    {
                        myNewClass.DoubleArray[i][j] -= 1;
                    }

                }
                return myNewClass;
            }
            //констант true и false:
            //обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию,
            ///иначе false.
            public static bool operator true(MyNewClass myNewClass)
            {
                int res = 0;
                for (int r = 0; r < myNewClass.DoubleArray.Length; r++)
                {
                    for (int i = 0; i < myNewClass.DoubleArray[r].Length; i++)
                    {
                        for (int j = 0; j < myNewClass.DoubleArray[r].Length - 1; j++)
                        {
                            if (myNewClass.DoubleArray[r][j] < myNewClass.DoubleArray[r][j + 1])
                            {

                                res++;
                            }
                        }
                    }
                }
                if (res == 0)
                    return true;
                else return false;
            }

            //констант true и false:
            //обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию,
            ///иначе false.
            public static bool operator false(MyNewClass myNewClass)
            {
                int res = 0;
                for (int r = 0; r < myNewClass.DoubleArray.GetLength(0); r++)
                {
                    for (int i = 0; i < myNewClass.DoubleArray.GetLength(1); i++)
                    {
                        for (int j = 0; j < myNewClass.DoubleArray.GetLength(1) - 1; j++)
                        {
                            if (myNewClass.DoubleArray[r][j] < myNewClass.DoubleArray[r][j + 1])
                            {

                                res++;
                            }
                        }
                    }
                }
                if (res != 0)
                    return false;
                else return true;
            }
            public static MyNewClass operator *(MyNewClass A, MyNewClass B)
            {

                MyNewClass array = new MyNewClass(A.n, A.m);

                for (int i = 0; i < array.DoubleArray.Length; i++)
                {
                    array.DoubleArray[i] = new double[array.m];
                    for (int j = 0; j < array.DoubleArray[i].Length; j++)
                    {
                        for (int k = 0; k < array.DoubleArray[i].Length; k++)
                        {
                            array.DoubleArray[i][j] += A[i, k] * B[k, j];
                        }

                    }
                }

                return array;
            }
            //Преобразования в двухмерный массив (неявное преобразование)
            public static implicit operator MyNewClass(double[][] mx)
            {
                return new MyNewClass(mx);

            }
            //Преобразования в ступенчатый массив (явное преобразование)
            public static explicit operator double[][](MyNewClass mx)
            {
                return mx.DoubleArray;
            }
            //Заполнение двухмерного массива исходя из уже заполненного ступенчатого
            public MyNewClass(double[][] mx)
            {
                DoubleArray = new double[mx.Length][];
                for (int i = 0; i < mx.Length; ++i)
                {
                    DoubleArray[i] = new double[mx[i].Length];
                    for (int j = 0; j < mx[i].Length; ++j)
                    {
                        DoubleArray[i][j] = mx[i][j];
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

                        if (!double.TryParse(numericUpDown3.Text, out scalar))
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
                    case 5:
                        int row, col;


                        if (!int.TryParse(numericUpDown4.Text, out row) || row <= -1)
                        {
                            MessageBox.Show("Ошибка,неправильно введено количество строк", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        if (!int.TryParse(numericUpDown5.Text, out col) || col <= -1)
                        {
                            MessageBox.Show("Ошибка,неправильно введено количество столбцов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            textBox1.Text = $"Элемент под индексом [{row},{col}]: " + newClass[row, col];
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка, попробуйте ещё раз", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case 6:

                        newClass++;
                        MessageBox.Show("Все элементы увеличены на 1");
                        textBox1.Text = "Массив:" + Environment.NewLine;
                        newClass.Print(textBox1);
                        break;
                    case 7:
                        newClass--;
                        MessageBox.Show("Все элементы уменьшены на 1");
                        textBox1.Text = "Массив:" + Environment.NewLine;
                        newClass.Print(textBox1);
                        break;
                    case 8:
                    case 9:

                        if (newClass) MessageBox.Show("Строки массива упорядочены по возростаню.");
                        else
                            MessageBox.Show("Строки массива не упорядочены по возростанию.");

                        break;

                    case 10:

                        int a, b;

                        if (!int.TryParse(numericUpDown4.Text, out a) || a <= -1)
                        {
                            MessageBox.Show("Ошибка, неправильно введено количество строк", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        if (!int.TryParse(numericUpDown5.Text, out b) || b <= -1)
                        {
                            MessageBox.Show("Ошибка, неправильно введено количество столбцов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MyNewClass myNewClass;

                        if (n == a && m == b)
                        {
                            myNewClass = new MyNewClass(a, b);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка, попробуйте ещё раз", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        myNewClass.FillingTheArray(textBox2);
                        newClass *= myNewClass;
                        textBox1.Text = "Массив:" + Environment.NewLine;
                        newClass.Print(textBox1);
                        break;

                    case 11:
                        MyNewClass array = newClass;
                        textBox1.Text = "Массив преобразованный в двухмерный" + Environment.NewLine;
                        array.Print(textBox1);
                        break;

                    case 12:
                        MyNewClass array1 = (double[][])newClass;
                        textBox1.Text = "Массив преобразованный в ступенчатый" + Environment.NewLine;
                        array1.Print(textBox1);
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
