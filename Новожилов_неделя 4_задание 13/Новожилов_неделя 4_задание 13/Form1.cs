namespace Новожилов_неделя_4_задание_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class Tovar
        {
            abstract public void PRINT(TextBox text);
            abstract public bool TYPE(string temp);
        }
        //класс игрушка
        class Toy : Tovar
        {
            string type = "Toy";
            string name;
            double price;
            string madein;
            string material;
            int age;
            public Toy(string name, double price, string madein, string material, int age)
            {
                this.name = name;
                this.price = price;
                this.madein = madein;
                this.material = material;
                this.age = age;
            }
            public override void PRINT(TextBox text)
            {
                text.Text += "Тип товара:" + type + Environment.NewLine + "Название:" + name + Environment.NewLine + "Цена:" + price + Environment.NewLine + "Производитель:" + madein + Environment.NewLine + "Материал:" + material + Environment.NewLine + "Возраст:" + age + Environment.NewLine;
                text.Text += "______________________" + Environment.NewLine;
            }
            public override bool TYPE(string temp)
            {
                return temp.Contains(type);
            }
        }
        //Класс книга
        class Book : Tovar
        {
            string type = "Book";
            string name;
            string author;
            double price;
            string madein;
            int age;
            public Book(string name, string author, double price, string madein, int age)
            {
                this.name = name;
                this.author = author;
                this.price = price;
                this.madein = madein;
                this.age = age;
            }
            public override void PRINT(TextBox text)
            {
                text.Text += "Тип товара:" + type + Environment.NewLine + "Название:" + name + Environment.NewLine + "Автор:" + author + Environment.NewLine + "Цена:" + price + Environment.NewLine + "Издательство:" + madein + Environment.NewLine + "Возраст:" + age + Environment.NewLine;
                text.Text += "______________________" + Environment.NewLine;
            }
            public override bool TYPE(string temp)
            {
                return temp.Contains(type);
            }
        }
        //Класс спорт-инвертарь
        class Sport : Tovar
        {
            string type = "Sport";
            string name;
            double price;
            string madein;
            int age;
            public Sport(string name, double price, string madein, int age)
            {
                this.name = name;
                this.price = price;
                this.madein = madein;
                this.age = age;
            }
            public override void PRINT(TextBox text)
            {
                text.Text += "Тип товара:" + type +Environment.NewLine+"Название:" + name + Environment.NewLine + "Цена:" + price + Environment.NewLine + "Производитель:" + madein + Environment.NewLine + "Возраст:" + age + Environment.NewLine;
                text.Text += "______________________" + Environment.NewLine;
            }
            public override bool TYPE(string temp)
            {
                return temp.Contains(type);
            }
        }

        Tovar[] newObj;
        int countLines = File.ReadAllLines("text.txt").Length;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox1.ReadOnly = true;
            int count;
            string? temp;

            //Запись из файла
            string[] str1;
            

            newObj = new Tovar[countLines];
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                int i = 0;
                while (sr.Peek() > -1)
                {
                    str1 = sr.ReadLine().Split(':');

                    if (str1[0] == "Toy")
                        newObj[i] = new Toy(str1[1], double.Parse(str1[2]), str1[3], str1[4], int.Parse(str1[5]));
                    else if (str1[0] == "Book")
                        newObj[i] = new Book(str1[1], str1[2], double.Parse(str1[3]), str1[4], int.Parse(str1[5]));
                    else if (str1[0] == "Sport")
                        newObj[i] = new Sport(str1[1], double.Parse(str1[2]), str1[3], int.Parse(str1[4]));
                    i++;
                }
            }

            textBox1.Text = "Из файла";
            for (int i = 0; i < countLines; i++)
                newObj[i].PRINT(textBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
           int count = 0;
            string temp = textBox2.Text;
            for (int i = 0; i < countLines; i++)
                if (newObj[i].TYPE(temp))
                {
                    newObj[i].PRINT(textBox3);
                    count++;
                }

            if (count == 0)
                MessageBox.Show("Такого типа товаров в базе нет");

        }
    }
}
