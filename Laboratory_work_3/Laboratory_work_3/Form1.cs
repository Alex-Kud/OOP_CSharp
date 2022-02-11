using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Laboratory_work_3
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Library> librariesDictionary = new Dictionary<int, Library>();
        private Dictionary<int, Library> libraries = new Dictionary<int, Library>();
        private Library[] librariesArray = new Library[N];
        private const int N = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; ++i)
                listView1.Items.Add(new ListViewItem());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long allTimeArray1 = 0, allTimeDicrionary1 = 0;
            Random rnd = new Random(DateTime.Now.Millisecond);
            // Заполнение данных
            for (int i = 0; i < N; i++)
            {
                Stopwatch iterationTimeArray = new Stopwatch(), iterationTimeDicrionary = new Stopwatch();
                
                string name = "Library_" + rnd.Next();
                string street = "Street_" + rnd.Next();
                string librarian = "Librarian_" + rnd.Next();
                int books = rnd.Next(0, 100000);
                int halls = rnd.Next(0, 100);
                int seats = rnd.Next(0, 1000);
                float visitors = rnd.Next(0, 100);
                iterationTimeDicrionary.Start();
                librariesDictionary.Add(Library.QuantityLibraries,
                    new Library(name, street, librarian, books, halls, seats, visitors));
                iterationTimeDicrionary.Stop();
                allTimeDicrionary1 += iterationTimeDicrionary.ElapsedTicks;
                iterationTimeArray.Start();
                librariesArray[i] = new Library(name, street, librarian, books, halls, seats, visitors);
                iterationTimeArray.Stop();
                allTimeArray1 += iterationTimeArray.ElapsedTicks;
            }

            // Последовательная выборка
            Stopwatch allTimeArray2 = new Stopwatch(), allTimeDicrionary2 = new Stopwatch();
            Library temp;
            allTimeArray2.Start();
            for (int i = 0; i < N; i++)
                temp = librariesArray[i];
                allTimeArray2.Stop();
            allTimeDicrionary2.Start();
            foreach (var pair in librariesDictionary)
                temp  = pair.Value;
            allTimeDicrionary2.Stop();

            // Случайная выборка
            Stopwatch allTimeArray3 = new Stopwatch(), allTimeDicrionary3 = new Stopwatch();
            allTimeArray3.Start();
            for (int i = 0; i < N; i++)
                temp = librariesArray[rnd.Next(0, N)];
            allTimeArray3.Stop();
            allTimeDicrionary3.Start();
            foreach (var pair in librariesDictionary)
                temp = pair.Value;
            allTimeDicrionary3.Stop();

            // Формирование таблицы
            ListViewItem lv1 = new ListViewItem();
            lv1.Text = "Вставка";
            lv1.SubItems.Add(allTimeArray1.ToString());
            lv1.SubItems.Add(allTimeDicrionary1.ToString());

            ListViewItem lv2 = new ListViewItem();
            lv2.Text = "Последовательная выборка";
            lv2.SubItems.Add(allTimeArray2.ElapsedTicks.ToString());
            lv2.SubItems.Add(allTimeDicrionary2.ElapsedTicks.ToString());

            ListViewItem lv3 = new ListViewItem();
            lv3.Text = "Случайная выборка";
            lv3.SubItems.Add(allTimeArray3.ElapsedTicks.ToString());
            lv3.SubItems.Add(allTimeDicrionary3.ElapsedTicks.ToString());

            listView1.Items[0] = lv1;
            listView1.Items[1] = lv2;
            listView1.Items[2] = lv3;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string street = textBox2.Text;
            string librarian = textBox3.Text;
            int books = (int)numericUpDown1.Value;
            int halls = (int)numericUpDown2.Value;
            int seats = (int)numericUpDown3.Value;
            float visitors = (float)numericUpDown4.Value;
            libraries.Add(Library.QuantityLibraries, new Library(name, street, librarian, books, halls, seats, visitors));
            ShowLibraries();
        }

        private void ShowLibraries()
        {
            textBox4.Text = "";
            if (libraries.Count == 0)
                textBox4.Text = "Библиотек не обнаружено";
            else foreach (var pair in libraries)
                textBox4.Text += pair.Value.ToString() + Environment.NewLine + Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string needDelete = textBox5.Text;
            foreach (var pair in libraries)
            {
                if (needDelete == pair.Value.Name)
                {
                    libraries.Remove(pair.Key);
                    break;
                }

            }
            ShowLibraries();
        }

  
    }
}
