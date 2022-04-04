using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOP_5
{
    public partial class Form1 : Form
    {
        private Library demoLibrary = 
            new Library("Демонстрационная библиотека", 
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selected = comboBox1.SelectedIndex; // 0 - учебник, 1 - книга
            string author = textBox3.Text;
            string title = textBox4.Text;
            string publisher = textBox5.Text;
            int year = (int) numericUpDown1.Value;
            string type = comboBox1.Text;
            if (selected == 0)
            {
                string subject = textBox6.Text;
                int clas = (int)numericUpDown2.Value;
                Book book = new Textbook(author, title, publisher, year, type, subject, clas);
                demoLibrary += book;
            }
            else if (selected == 1)
            {
                string genre = textBox6.Text;
                string mainCharacter = textBox7.Text;
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
            int selected = comboBox1.SelectedIndex; // 0 - учебник, 1 - книга
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
            foreach (var book in lib.Books)
            {
                textBox2.Text += book.ToString();
            }
            label1.Text = demoLibrary.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
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

            Book readingBook = demoLibrary.Books.Single(b => b.Title == name);

            if (readingBook.Type.Equals("Учебник"))
            {
                Textbook readingTextBook = (Textbook) readingBook;
                readingTextBook.ReadBook();
            }
            if (readingBook.Type.Equals("Художественная книга"))
            {
                ArtBook readingArtBook = (ArtBook) readingBook;
                readingArtBook.ReadBook();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
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
            Random rnd = new Random();
            int type = rnd.Next(0, 2);
            string author = Path.GetRandomFileName();
            string title = Path.GetRandomFileName();
            string publisher = Path.GetRandomFileName();
            int year = rnd.Next(1900, 2023);
            if (type == 0)
            {
                string subject = Path.GetRandomFileName();
                int clas = rnd.Next(1, 11);
                Book book = new Textbook(author, title, publisher, year, "Учебник", subject, clas);
                demoLibrary += book;
            }
            else if (type == 1)
            {
                string genre = Path.GetRandomFileName();
                string mainCharacter = Path.GetRandomFileName();
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
            timer1.Enabled = true;  // Делаем таймер доступным
            timer1.Start();         // Запускаем таймер

            timer2.Enabled = true;  // Делаем таймер доступным
            timer2.Start();         // Запускаем таймер
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;

            label9.Text = "Генерируются";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();          // Останавливаем таймер
            timer1.Enabled = false; // Снова делаем таймер недоступным

            timer2.Stop();          // Останавливаем таймер
            timer2.Enabled = false; // Снова делаем таймер недоступным

            label9.Text = "НЕ генерируются";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
