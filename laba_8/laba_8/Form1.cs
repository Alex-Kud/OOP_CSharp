using System.Text.Json;

namespace laba_8
{
    public partial class Form1 : Form
    {
        private LibraryCollection<Library>[] containerLibraries = new LibraryCollection<Library>[10];
        private LibraryCollection<string> lines = new LibraryCollection<string>();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < containerLibraries.Length; i++)
            {
                containerLibraries[i] = new LibraryCollection<Library>();
                Random rnd = new Random();
                for (int j = 0; j < rnd.Next(5, 20); ++j)
                {
                    containerLibraries[i].Add(GenerateRandomLibrary());
                }
            }
        }

        private static Library GenerateRandomLibrary()
        {
            Random rnd = new Random();

            string name = Path.GetRandomFileName();
            string street = Path.GetRandomFileName();
            string librarian = Path.GetRandomFileName();
            int numberOfBooks = rnd.Next(1, 100000);
            int numberOfHalls = rnd.Next(1, 10);
            int numberOfSeatsInTheHall = rnd.Next(10, 500);
            float visitorsPerDay = rnd.Next(0, 2000);

            return new Library(name, street, librarian, numberOfBooks, numberOfHalls, numberOfSeatsInTheHall, visitorsPerDay);
        }

        private void Show(LibraryCollection<Library>? library)
        {
            textBox1.Text = "";
            textBox1.Text += $"### Размер коллекции: {library.Count} ###" + Environment.NewLine;
            foreach (var cont in library)
            {
                textBox1.Text += cont.ToString();
            }
        }

        private void SortLibrariesFromFirstCollection(object sender, EventArgs e)
        {
            Show(new LibraryCollection<Library> (containerLibraries[0].OrderBy(l => l.Name).ToArray()));
        }

        private void GetCollectionWithTenLength(object sender, EventArgs e)
        {
            var libraries = containerLibraries.Where(libraries => libraries.Count == (int) numericUpDown1.Value).ToList();
            if (libraries.Count == 0)
            {
                textBox1.Text = "Коллекция заданной длины не найдена";
                return;
            }

            textBox1.Text = "";
            foreach (var library in libraries)
            {
                textBox1.Text += $"### Размер коллекции: {library.Count} ###" + Environment.NewLine;
                foreach (var cont in library)
                {
                    textBox1.Text += cont.ToString();
                }
            }
        }

        private void MaxCollection(object sender, EventArgs e)
        {
            Show(containerLibraries.OrderByDescending(library => library.Count).ToList().FirstOrDefault());
        }

        private void MinCollection(object sender, EventArgs e)
        {
            Show(containerLibraries.OrderBy(library => library.Count).ToList().FirstOrDefault());
        }

        private void WriteToFile(object sender, EventArgs e)
        {
            string Path = Directory.GetCurrentDirectory() + "/Libraries.txt";
            FileInfo treeJsonFile = new FileInfo(Path);

            if (!treeJsonFile.Exists)
                File.Create(Path).Close();

            string serializedTree = "[";

            foreach (var library in containerLibraries)
            {
                serializedTree += "[{size:" + library.Count.ToString() + "},";

                foreach (var cont in library)
                {
                    serializedTree += JsonSerializer.Serialize(cont) + ",";
                }
                serializedTree += "],";
            }
            serializedTree += "]";

            StreamWriter jsonWriter = new StreamWriter(Path, false);
            jsonWriter.WriteLine(serializedTree);
            jsonWriter.Flush();
            jsonWriter.Close();
            MessageBox.Show("Запись в файл Libraries.txt успешно осуществлена!", "Система");
        }

        private void InputLines(object sender, EventArgs e)
        {
            lines.Add(textBox2.Text);
            ShowLines(sender, e);
        }

        private void ShowLines(object sender, EventArgs e)
        {
            textBox4.Text = "";
            foreach (var line in lines)
            {
                textBox4.Text += line + Environment.NewLine;
            }
        }

        private void FindLineWithText(object sender, EventArgs e)
        {
            textBox4.Text = "Строки, включающие подстроку " + textBox3.Text + Environment.NewLine;
            foreach (var line in lines)
            {
                if (line.Contains(textBox3.Text))
                {
                    textBox4.Text += line + Environment.NewLine;
                }
            }
        }

        private void CountWithLength(object sender, EventArgs e)
        {
            int lengthLine = (int)numericUpDown2.Value;
            int quantity = lines.Where(l => l.Length == lengthLine).Count();
            MessageBox.Show($"Количество строк с длинной {lengthLine}: {quantity}", "Информация");
        }

        private void SortLinesBy(object sender, EventArgs e)
        {
            var sortedLines = lines.OrderBy(line => line); // from p in lines orderby line select line;
            textBox4.Text = "";
            foreach (var line in sortedLines)
            {
                textBox4.Text += line + Environment.NewLine;
            }
        }

        private void SortLinesByDescending(object sender, EventArgs e)
        {
            var sortedLines = lines.OrderByDescending(line => line);
            textBox4.Text = "";
            foreach (var line in sortedLines)
            {
                textBox4.Text += line + Environment.NewLine;
            }
        }

        private void WriteLineIntoFile(object sender, EventArgs e)
        {
            string Path = Directory.GetCurrentDirectory() + "/Strings.txt";
            FileInfo treeJsonFile = new FileInfo(Path);

            if (!treeJsonFile.Exists)
                File.Create(Path).Close();

            StreamWriter writer = new StreamWriter(Path, false);
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
            
            writer.Flush();
            writer.Close();
            MessageBox.Show("Запись в файл Strings.txt успешно осуществлена!", "Система");
        }

        private void ShowAllLibraries(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (var container in containerLibraries)
            {
                textBox1.Text += $"### Размер коллекции: {container.Count} ###" + Environment.NewLine;
                foreach (var cont in container)
                {
                    textBox1.Text += cont.ToString();
                }
                textBox1.Text += Environment.NewLine;
            }
        }
    }
}