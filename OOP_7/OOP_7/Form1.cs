using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP_7
{
    public partial class Form1 : Form
    {
        private Library demoLibrary =
            new("Демонстрационная библиотека",
                "Некоторая улица",
                "Неизвестный библиотекарь",
                2, 300, 27.5f);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = demoLibrary.ToString();
            demoLibrary.Add += DisplayMessage;
            demoLibrary.Remove += (message, heading) => MessageBox.Show(this, message, heading);
        }

        /// <summary>
        ///     Добавление книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedIndex; // 0 - учебник, 1 - книга
            var author = textBox3.Text;
            var title = textBox4.Text;
            var publisher = textBox5.Text;
            var year = (int)numericUpDown1.Value;
            var type = comboBox1.Text;
            if (selected == 0)
            {
                var subject = textBox6.Text;
                var clas = (int)numericUpDown2.Value;
                Book book = new Textbook(author, title, publisher, year, type, subject, clas);
                demoLibrary += book;
            }
            else if (selected == 1)
            {
                var genre = textBox6.Text;
                var mainCharacter = textBox7.Text;
                Book book = new ArtBook(author, title, publisher, year, type, genre, mainCharacter);
                demoLibrary += book;
            }
            else
            {
                MessageBox.Show(
                    "Выберите тип книги",
                    "Ошибка добавления книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }

            ShowBooks(demoLibrary);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedIndex; // 0 - учебник, 1 - книга
            if (selected == 0)
            {
                label7.Text = "Предмет";
                label7.Visible = true;

                textBox6.PlaceholderText = "Предмет";
                textBox6.Visible = true;

                label8.Text = "Класс";
                label8.Visible = true;

                numericUpDown2.Visible = true;
                textBox7.Visible = false;
            }

            if (selected == 1)
            {
                label7.Text = "Жанр";
                label7.Visible = true;

                textBox6.PlaceholderText = "Жанр";
                textBox6.Visible = true;

                label8.Text = "Главный герой";
                label8.Visible = true;

                textBox7.PlaceholderText = "Главный герой";
                textBox7.Visible = true;
                numericUpDown2.Visible = false;
            }
        }

        private void ShowBooks(Library lib)
        {
            textBox2.Text = "";
            foreach (var book in lib.Books) textBox2.Text += book.ToString();
            label1.Text = demoLibrary.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            if (demoLibrary.Books.All(b => b.Title != name))
            {
                MessageBox.Show(
                    "Книга не найдена! Возможно Вы сделали опечатку в названии",
                    "Ошибка чтения книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            var readingBook = demoLibrary.Books.Single(b => b.Title == name);

            if (readingBook.Type.Equals("Учебник"))
            {
                var readingTextBook = (Textbook)readingBook;
                readingTextBook.ReadBook();
            }

            if (readingBook.Type.Equals("Художественная книга"))
            {
                var readingArtBook = (ArtBook)readingBook;
                readingArtBook.ReadBook();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            if (demoLibrary.Books.All(b => b.Title != name))
            {
                MessageBox.Show(
                    "Книга не найдена! Возможно Вы сделали опечатку в названии",
                    "Ошибка удаления книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            demoLibrary -= demoLibrary.Books.Single(b => b.Title == name);
            ShowBooks(demoLibrary);
        }

        private void AddRandomBook()
        {
            var rnd = new Random();
            var type = rnd.Next(0, 2);
            var author = Path.GetRandomFileName();
            var title = Path.GetRandomFileName();
            var publisher = Path.GetRandomFileName();
            var year = rnd.Next(1900, 2024);
            if (type == 0)
            {
                var subject = Path.GetRandomFileName();
                var clas = rnd.Next(1, 12);
                Book book = new Textbook(author, title, publisher, year, "Учебник", subject, clas);
                demoLibrary += book;
            }
            else if (type == 1)
            {
                var genre = Path.GetRandomFileName();
                var mainCharacter = Path.GetRandomFileName();
                Book book = new ArtBook(author, title, publisher, year, "Художественная книга", genre, mainCharacter);
                demoLibrary += book;
            }

            ShowBooks(demoLibrary);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AddRandomBook();
            progressBar1.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; // Делаем таймер доступным
            timer1.Start(); // Запускаем таймер

            timer2.Enabled = true; // Делаем таймер доступным
            timer2.Start(); // Запускаем таймер
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;

            label9.Text = "Генерируются";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // Останавливаем таймер
            timer1.Enabled = false; // Снова делаем таймер недоступным

            timer2.Stop(); // Останавливаем таймер
            timer2.Enabled = false; // Снова делаем таймер недоступным

            label9.Text = "НЕ генерируются";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void DisplayMessage(string message, string heading)
        {
            MessageBox.Show(this, message, heading);
        }
    }
}