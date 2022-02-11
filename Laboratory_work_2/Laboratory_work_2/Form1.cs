using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_work_2
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Library> libraries = new Dictionary<int, Library>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected = comboBox1.SelectedIndex;
            if (selected == -1) return;
            libraries[selected].SetName(textBox1.Text);
            libraries[selected].SetStreet(textBox2.Text);
            libraries[selected].SetLibrarian(textBox3.Text);
            libraries[selected].SetNumberOfBooks((int)numericUpDown1.Value);
            libraries[selected].SetNumberOfHalls((int)numericUpDown2.Value);
            libraries[selected].SetNumberOfSeatsInTheHall((int)numericUpDown3.Value);
            libraries[selected].SetVisitorsPerDay((float)numericUpDown4.Value);
            label2.Text = libraries[selected].ToString();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = comboBox1.SelectedIndex;
            label2.Text = libraries[selected].ToString();
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
            ChangeComboBox1();
            label10.Text = "Добавлено библиотек: " + Library.QuantityLibraries;
        }

        private void ChangeComboBox1()
        {
            if (libraries.Count == 0)
                label2.Text = "";
            else
            {
                int selected = comboBox1.SelectedIndex;
                comboBox1.Items.Clear();
                foreach (var pair in libraries)
                    comboBox1.Items.Add(pair.Value.Name);
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(selected);
            }
        }
    }
}
